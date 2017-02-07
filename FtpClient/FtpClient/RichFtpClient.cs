using DotNetRemoting;
using EnterpriseDT.Net.Ftp;
using FtpClient.Binary;
using FtpClient.Queue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatchDogLib;
using WinSCP;

namespace FtpClient
{
    public partial class RichFtpClient : Form
    {
        private StringBuilder stringBuilder;
        private bool bDirty;
        private System.IO.FileSystemWatcher watcher;
        private bool bIsWatching;

        private UploadImageQueue originalImages;

        private bool isUpLoading;

        private Login loginForm;

        private OriginalImage image;

        private WatchdogWatcher watchdogWatcher;

        private string ftpFolder;

        public RichFtpClient()
        {
            InitializeComponent();
            this.FormClosing += FtpClient_FormClosing;
            stringBuilder = new StringBuilder();
            //bDirty = false;
            //bIsWatching = false;
            originalImages = new UploadImageQueue();
            listViewData.Timer = this.timer;
            EnableStartWatch(false);
            InitializeWatchDog();
        }

        /// <summary>
        /// 初始化看门狗
        /// </summary>
        private void InitializeWatchDog()
        {
            int watchDogMonitorInterval = 5000;

            try
            {
                watchDogMonitorInterval = Convert.ToInt32(ConfigurationManager.AppSettings["WatchDogMonitorInterval"]);
                if (watchDogMonitorInterval != 0)
                {
                    watchDogMonitorInterval = 5000;
                }
            }
            catch (Exception ex)
            {
                watchDogMonitorInterval = 5000;
                MessageBox.Show("Exception WatchdogMonitor1: " + ex.StackTrace);
            }

            watchdogWatcher = new WatchdogWatcher("WatchDog", "WatchDog.exe", watchDogMonitorInterval);
        }

        private void EnableStartWatch(bool isEnable)
        {
            this.btnWatchFile.Enabled = isEnable;
        }

        /// <summary>
        /// 更新上传进度条
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Status"></param>
        /// <param name="FullSize"></param>
        /// <param name="CurrentBytes"></param>
        /// <param name="EstimatedTimeLeft"></param>
        /// <param name="Speed"></param>
        private void FtpClientCtrl_StatusUpdateEvent(string Message, DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {
            toolStripLabelStatus.Text = Status.ToString();
            label_mess.Text = Message;
            toolStripLabelTime.Text = BaseDownloader.TimeSpanToString(EstimatedTimeLeft);
            toolStripLabelSpeed.Text = Speed.ToString("F1") + " Kb/s";
            isUpLoading = true;
            if (Status == DStatus.complete || Status == DStatus.error)
            {
                isUpLoading = false;
                if (Status == DStatus.complete)
                    listViewData.AppendLog(new string[] { image.FileName, Status .ToString()});
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (rdbDir.Checked)
            {
                DialogResult resDialog = dlgOpenDir.ShowDialog();
                if (resDialog.ToString() == "OK")
                {
                    txtFile.Text = dlgOpenDir.SelectedPath;
                }
            }
            else
            {
                DialogResult resDialog = dlgOpenFile.ShowDialog();
                if (resDialog.ToString() == "OK")
                {
                    txtFile.Text = dlgOpenFile.FileName;
                }
            }
        }

        /// <summary>
        /// 监控文件夹中是否穿件新图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!bDirty)
            {
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append(e.FullPath);
                stringBuilder.Append(" ");
                stringBuilder.Append(e.ChangeType.ToString());
                stringBuilder.Append("    ");
                stringBuilder.Append(DateTime.Now.ToString());
                bDirty = true;
                if (e.ChangeType == WatcherChangeTypes.Created)
                {

                    OriginalImage originalImage = new OriginalImage(new DateTime(), e.Name, e.FullPath);
                    originalImages.Push(originalImage);
                }
            }
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="fileFullName"></param>
        private void Upload(string fileFullName)
        {
            if (ftpCtl1 != null && ftpCtl1.IsConnected)
            {
                string RemoteFile = Path.GetFileName(fileFullName);
                ftpCtl1.Put(fileFullName, RemoteFile);
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!bDirty)
            {
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append(e.OldFullPath);
                stringBuilder.Append(" ");
                stringBuilder.Append(e.ChangeType.ToString());
                stringBuilder.Append(" ");
                stringBuilder.Append("to ");
                stringBuilder.Append(e.Name);
                stringBuilder.Append("    ");
                stringBuilder.Append(DateTime.Now.ToString());
                bDirty = true;
                if (rdbFile.Checked)
                {
                    watcher.Filter = e.Name;
                    watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - watcher.Filter.Length);
                }
            }
        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (bDirty)
            {
                lstNotification.BeginUpdate();
                lstNotification.Items.Add(this.stringBuilder.ToString());
                lstNotification.EndUpdate();
                bDirty = false;
            }
        }

        private void ChkSubFolder_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkSubFolder.Checked)
            {
                if (watcher != null)
                    watcher.IncludeSubdirectories = true;
            }
            else
            {
                if (watcher != null)
                    watcher.IncludeSubdirectories = false;
            }
        }


        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            if (bIsWatching)
            {
                bIsWatching = false;
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
                btnWatchFile.BackColor = Color.LightSkyBlue;
                btnWatchFile.Text = "Start Watching";

            }
            else
            {
                bIsWatching = true;
                btnWatchFile.BackColor = Color.Red;
                btnWatchFile.Text = "Stop Watching";

                watcher = new System.IO.FileSystemWatcher();
                if (rdbDir.Checked)
                {
                    watcher.Filter = "*.*";
                    watcher.Path = txtFile.Text + "\\";
                }
                else
                {
                    watcher.Filter = txtFile.Text.Substring(txtFile.Text.LastIndexOf('\\') + 1);
                    watcher.Path = txtFile.Text.Substring(0, txtFile.Text.Length - watcher.Filter.Length);
                }

                if (chkSubFolder.Checked)
                {
                    watcher.IncludeSubdirectories = true;
                }

                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                //watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                //watcher.Deleted += new FileSystemEventHandler(OnChanged);
                //watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.EnableRaisingEvents = true;
            }
        }

        private void rdbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFile.Checked == true)
            {
                chkSubFolder.Enabled = false;
                chkSubFolder.Checked = false;
            }
        }

        private void rdbDir_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDir.Checked == true)
            {
                chkSubFolder.Enabled = true;
            }
        }

        private void FtpClient_Load(object sender, EventArgs e)
        {

        }

        private void FtpClient_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (ftpCtl1 != null && ftpCtl1.IsConnected)
            {
                //ftpCtl1.Abort();
                ftpCtl1.Dispose();
            }
            watchdogWatcher.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //check OriginalImage list
            //1.have original image && not upload
            //then upload
            if (this.ftpCtl1 != null && this.ftpCtl1.IsConnected)
            {
                this.ConnectedStatus.Text = "Conected";
                if (!this.isUpLoading && this.originalImages != null && this.originalImages.Count > 0)
                {
                    image = originalImages.Pop();
                    CheckFTPFolder();
                    Upload(image.FilePath);
                }
            }
            else
            {
                this.ConnectedStatus.Text = "Disconnected";
            }

            //2.have original image && uploading
            //then do nothing
            //3.have no original image 
            //then do nothing
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Login login = SpringHelper.GetObject<Login>("loginForm");
            if (!this.ftpCtl1.IsConnected)
            {
                loginForm = new Login(this.ftpCtl1);
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    EnableStartWatch(true);
                    this.ftpCtl1.FtpToolStripProgressBar = this.toolStripProgressBar;
                }
                else
                {
                    EnableStartWatch(false);
                }
            }

        }

        private void StripMenuItemLogOut_Click(object sender, EventArgs e)
        {
            if (this.ftpCtl1.IsConnected)
            {
                this.ftpCtl1.LogOut();
            }
        }

        /// <summary>
        /// 检查FTP文件夹
        /// </summary>
        private void CheckFTPFolder()
        {
            try
            {
                string[] splitFolders = ftpFolder.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                string currentFolder = "/";
                for (int i = 0; i <= splitFolders.Length - 1; i++)
                {
                    currentFolder += splitFolders[i];
                    if (!HaveFolder(currentFolder))
                    {
                        this.ftpCtl1.MkDir(currentFolder, true);
                    }
                    currentFolder += "/";
                }
                this.ftpCtl1.ChDir(ftpFolder, true);
            }
            catch (Exception ee)
            {
            }
        }

        /// <summary>
        /// 是否存在指定的文件夹
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public bool HaveFolder(string dir)
        {
            bool haveFolder = false;
            string parentFolder = Path.GetDirectoryName(dir).Replace("\\", "/");

            var files = this.ftpCtl1.GetDetails(parentFolder);
            string[] splitDirs = dir.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            string fileFolder = splitDirs[splitDirs.Length - 1];
            if (files != null)
            {
                if (files.Count() == 0)
                {
                    haveFolder = false;
                }
                else
                {
                    foreach (var file in files)
                    {
                        var filePath = file.Path.Replace("\\", "/");
                        if (file.Dir && filePath == dir)
                        {
                            haveFolder = true;
                        }
                    }
                }
            }
            else
            {
                haveFolder = false;
            }
            return haveFolder;
        }

    }
}
