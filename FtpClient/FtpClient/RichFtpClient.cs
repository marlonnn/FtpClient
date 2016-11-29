﻿using DotNetRemoting;
using FtpClient.Binary;
using FtpClient.Queue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace FtpClient
{
    public partial class RichFtpClient : Form
    {
        private Session _session;
        //private FTPClientCtl _ftpClientCtrl;

        private StringBuilder _stringBuilder;
        private bool _bDirty;
        private System.IO.FileSystemWatcher _Watcher;
        private bool _bIsWatching;

        //private List<OriginalImage> _OriginalImages;
        private UploadImageQueue _OriginalImages;

        private bool _isUpLoading;

        private Login login;

        public RichFtpClient()
        {
            InitializeComponent();
            _stringBuilder = new StringBuilder();
            _bDirty = false;
            _bIsWatching = false;
            //_OriginalImages = new List<OriginalImage>();
            _OriginalImages = new UploadImageQueue();
        }

        public RichFtpClient(Session session)
        {
            InitializeComponent();
            this._session = session;
            _stringBuilder = new StringBuilder();
            _bDirty = false;
            _bIsWatching = false;
            //_OriginalImages = new List<OriginalImage>();
            _OriginalImages = new UploadImageQueue();
        }

        public RichFtpClient(FTPClientCtl ftpClientCtrl)
        {
            InitializeComponent();
            //this._ftpClientCtrl = ftpClientCtrl;
            //if (this._ftpClientCtrl != null)
            //{
            //    this._ftpClientCtrl.FtpToolStripProgressBar = this.toolStripProgressBar;
            //    this._ftpClientCtrl.StatusUpdateEvent += FtpClientCtrl_StatusUpdateEvent;
            //}

            _stringBuilder = new StringBuilder();
            _bDirty = false;
            _bIsWatching = false;
            //_OriginalImages = new List<OriginalImage>();
            _OriginalImages = new UploadImageQueue();
        }

        private void FtpClientCtrl_StatusUpdateEvent(string Message, DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {
            toolStripLabelStatus.Text = Status.ToString();
            label_mess.Text = Message;
            toolStripLabelTime.Text = BaseDownloader.TimeSpanToString(EstimatedTimeLeft);
            toolStripLabelSpeed.Text = Speed.ToString("F1") + " Kb/s";
            _isUpLoading = true;
            if (Status == DStatus.complete || Status == DStatus.error)
            {
                _isUpLoading = false;
                if (Status == DStatus.complete)
                    listViewData.AppendLog(new string[] { "test", "success" });
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

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!_bDirty)
            {
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(e.FullPath);
                _stringBuilder.Append(" ");
                _stringBuilder.Append(e.ChangeType.ToString());
                _stringBuilder.Append("    ");
                _stringBuilder.Append(DateTime.Now.ToString());
                _bDirty = true;
                if (e.ChangeType == WatcherChangeTypes.Created)
                {

                    OriginalImage originalImage = new OriginalImage(new DateTime(), e.Name, e.FullPath);
                    //if (_uploadImageQueue != null)
                    //{
                    //    _uploadImageQueue.Push(originalImage);
                    //}
                    _OriginalImages.Push(originalImage);
                    //_OriginalImages.Add(new OriginalImage(DateTime.Now, e.Name, e.FullPath));
                    //UpLoadFile(e.FullPath, "/*.*");
                }
            }
        }

        private void Upload(string fileFullName)
        {
            if (ftpCtl1 != null && ftpCtl1.IsConnected)
            {
                string RemoteFile = Path.GetFileName(fileFullName);
                ftpCtl1.Put(fileFullName, RemoteFile);
            }
        }

        private void UpLoadFile(string localPath, string remotePath, bool remove = false)
        {
            if (_session != null && _session.Opened)
            {
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;
                TransferOperationResult transferResult;
                //remotePath /*.*
                transferResult = _session.PutFiles(localPath, remotePath, remove, transferOptions);

                transferResult.Check();

                // Print results
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    Console.WriteLine("Upload of {0} succeeded", transfer.FileName);
                }
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!_bDirty)
            {
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(e.OldFullPath);
                _stringBuilder.Append(" ");
                _stringBuilder.Append(e.ChangeType.ToString());
                _stringBuilder.Append(" ");
                _stringBuilder.Append("to ");
                _stringBuilder.Append(e.Name);
                _stringBuilder.Append("    ");
                _stringBuilder.Append(DateTime.Now.ToString());
                _bDirty = true;
                if (rdbFile.Checked)
                {
                    _Watcher.Filter = e.Name;
                    _Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - _Watcher.Filter.Length);
                }
            }
        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (_bDirty)
            {
                lstNotification.BeginUpdate();
                lstNotification.Items.Add(this._stringBuilder.ToString());
                lstNotification.EndUpdate();
                _bDirty = false;
            }
        }

        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            if (_bIsWatching)
            {
                _bIsWatching = false;
                _Watcher.EnableRaisingEvents = false;
                _Watcher.Dispose();
                btnWatchFile.BackColor = Color.LightSkyBlue;
                btnWatchFile.Text = "Start Watching";

            }
            else
            {
                _bIsWatching = true;
                btnWatchFile.BackColor = Color.Red;
                btnWatchFile.Text = "Stop Watching";

                _Watcher = new System.IO.FileSystemWatcher();
                if (rdbDir.Checked)
                {
                    _Watcher.Filter = "*.*";
                    _Watcher.Path = txtFile.Text + "\\";
                }
                else
                {
                    _Watcher.Filter = txtFile.Text.Substring(txtFile.Text.LastIndexOf('\\') + 1);
                    _Watcher.Path = txtFile.Text.Substring(0, txtFile.Text.Length - _Watcher.Filter.Length);
                }

                if (chkSubFolder.Checked)
                {
                    _Watcher.IncludeSubdirectories = true;
                }

                _Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                //_Watcher.Changed += new FileSystemEventHandler(OnChanged);
                _Watcher.Created += new FileSystemEventHandler(OnChanged);
                //_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
                //_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                _Watcher.EnableRaisingEvents = true;
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
            //if (_session != null && _session.Opened)
            //{
            //    try
            //    {
            //        _session.Close();
            //        _session.Dispose();
            //    }
            //    catch (Exception exception)
            //    {
            //    }
            //}
            if (ftpCtl1 != null && ftpCtl1.IsConnected)
            {
                //ftpCtl1.Abort();
                ftpCtl1.Dispose();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //check OriginalImage list
            //1.have original image && not upload
            //then upload
            if (!this._isUpLoading && this._OriginalImages != null && this._OriginalImages.Count > 0)
            {
                var images = _OriginalImages.Pop();
                Upload(images.FilePath);
            }
            //2.have original image && uploading
            //then do nothing
            //3.have no original image 
            //then do nothing
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Login login = SpringHelper.GetObject<Login>("loginForm");
            login = new Login(this.ftpCtl1);
            if (login.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
