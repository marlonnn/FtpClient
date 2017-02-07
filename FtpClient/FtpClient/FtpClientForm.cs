using DotNetRemoting;
using EnterpriseDT.Net.Ftp;
using FtpClient.Binary;
using FtpClient.Queue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace FtpClient
{
    public partial class FtpClientForm : GenericSaveForm.GenericSavForm
    {
        private FtpSettings ftpSettings;
        private WatchDogForm watchDogForm;

        private UploadImageQueue uploadImageQueue;

        public FtpClientForm()
        {
            InitializeComponent();
            this.listViewData.Timer = this.timer;
        }

        private void FtpClientForm_Load(object sender, EventArgs e)
        {
            ApplySettings();
            this.Focus();
        }

        private void FtpClientForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SaveSettings();
        }


        private void ApplySettings()
        {
            txtBoxServerIp.Text = ftpSettings.ServerIP;
            txtBoxUserId.Text = ftpSettings.UserID;
            txtBoxPort.Text = ftpSettings.Port.ToString();
            txtBoxPassword.Text = ftpSettings.Password;
        }

        /// <summary>
        /// 保存FTP信息
        /// </summary>
        private void SaveSettings()
        {
            ftpSettings.ServerIP = txtBoxServerIp.Text;
            ftpSettings.UserID = txtBoxUserId.Text;
            ftpSettings.Port = int.Parse(txtBoxPort.Text);
            ftpSettings.Password = txtBoxPassword.Text;
        }

        /// <summary>
        /// ftp连接设置
        /// </summary>
        private void SetCredentials()
        {
            if (!ftpCtl1.IsConnected)
            {
                ftpCtl1.RemoteHost = txtBoxServerIp.Text;
                int Port = int.Parse(txtBoxPort.Text);
                ftpCtl1.ControlPort = Port;
                ftpCtl1.Connect();

                if (ftpCtl1.IsConnected)
                {
                    ftpCtl1.Login(txtBoxUserId.Text, txtBoxPassword.Text);

                    //if (checkBox_bin.Checked)
                        ftpCtl1.SetTransferType(FTPTransferType.BINARY);
                    //else
                    //    ftpCtl1.SetTransferType(FTPTransferType.ASCII);

                    //if (checkBox_Passive.Checked)
                    //    ftpCtl1.SetConnectMode(FTPConnectMode.PASV);
                    //else
                    //    ftpCtl1.SetConnectMode(FTPConnectMode.ACTIVE);
                }
                else
                {
                    label_mess.Text = "Not Connected";
                }
            }
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            if (btnUpLoad.Text == "UpLoad")
            {
                SetCredentials();
                string RemoteFile = Path.GetFileName(textBoxLocalFile.Text);
                ftpCtl1.Put(textBoxLocalFile.Text, RemoteFile);
                btnUpLoad.Text = "Abort";
            }
            else
            {
                ftpCtl1.CancelTransfer();
                btnUpLoad.Text = "UpLoad";
            }
        }

        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="fileFullName"></param>
        private void Upload(string fileFullName)
        {
            SetCredentials();
            string RemoteFile = Path.GetFileName(fileFullName);
            ftpCtl1.Put(fileFullName, RemoteFile);
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = ftpSettings.LocalFile;
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBoxLocalFile.Text = openFileDialog1.FileName;
            ftpSettings.LocalFile = textBoxLocalFile.Text;
        }

        /// <summary>
        /// 更新状态栏
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="Status"></param>
        /// <param name="FullSize"></param>
        /// <param name="CurrentBytes"></param>
        /// <param name="EstimatedTimeLeft"></param>
        /// <param name="Speed"></param>
        private void ftpCtl1_StatusUpdateEvent(string Message, DotNetRemoting.DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {
            toolStripLabelStatus.Text = Status.ToString();
            label_mess.Text = Message;
            toolStripLabelTime.Text = BaseDownloader.TimeSpanToString(EstimatedTimeLeft);
            toolStripLabelSpeed.Text = Speed.ToString("F1") + " Kb/s";
            if (Status == DStatus.complete || Status == DStatus.error)
            {
                if (Status == DStatus.complete)
                    listViewData.AppendLog(new string[] { "test", "success" });
                btnUpLoad.Text = "UpLoad";
            }
        }

        private void FtpClientForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == System.Windows.Forms.Keys.Control &&
                e.KeyCode == System.Windows.Forms.Keys.W)
            {
                watchDogForm.Location = this.Location;
                watchDogForm.ShowDialog();
            }
        }

        /// <summary>
        /// 定时器取出队列中图片并上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (uploadImageQueue != null && uploadImageQueue.GetCount() > 0)
            {
                //pop all and upload
                List<OriginalImage> images = uploadImageQueue.PopAll();
                foreach (var image in images)
                {
                    listViewData.AppendLog(new string[] { image.FileName,"uploading..."});
                    Upload(image.FilePath);
                }
            }
        }
    }
}
