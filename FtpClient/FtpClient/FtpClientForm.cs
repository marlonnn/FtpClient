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
        private FtpSettings _ftpSettings;
        private WatchDogForm _watchDogForm;

        private UploadImageQueue _uploadImageQueue;

        public FtpClientForm()
        {
            InitializeComponent();
            this.listViewData.Timer = this.timer;
        }

        private void FtpClientForm_Load(object sender, EventArgs e)
        {
            //ApplySettings();
            //_ftpSettings = (FtpSettings)GetSettingsObject(typeof(FtpSettings));
            ApplySettings();
            this.Focus();
        }

        private void FtpClientForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SaveSettings();
        }


        private void ApplySettings()
        {
            txtBoxServerIp.Text = _ftpSettings.ServerIP;
            txtBoxUserId.Text = _ftpSettings.UserID;
            txtBoxPort.Text = _ftpSettings.Port.ToString();
            //textBox_local_folder.Text = _ftpSettings.LocalFolder;
            txtBoxPassword.Text = _ftpSettings.Password;
            //checkBox_bin.Checked = _ftpSettings.Binary;
            //checkBox_Passive.Checked = _ftpSettings.Passive;
            //textBox_loc_file.Text = _ftpSettings.LocalFile;
        }

        private void SaveSettings()
        {
            _ftpSettings.ServerIP = txtBoxServerIp.Text;
            _ftpSettings.UserID = txtBoxUserId.Text;
            _ftpSettings.Port = int.Parse(txtBoxPort.Text);
            //_ftpSettings.LocalFolder = txt.Text;
            _ftpSettings.Password = txtBoxPassword.Text;
            //_ftpSettings.Binary = checkBox_bin.Checked;
            //_ftpSettings.Passive = checkBox_Passive.Checked;
            //_ftpSettings.LocalFile = textBox_loc_file.Text;
        }

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


        private void Upload(string fileFullName)
        {
            SetCredentials();
            string RemoteFile = Path.GetFileName(fileFullName);
            ftpCtl1.Put(textBoxLocalFile.Text, RemoteFile);
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = _ftpSettings.LocalFile;
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBoxLocalFile.Text = openFileDialog1.FileName;
            _ftpSettings.LocalFile = textBoxLocalFile.Text;
        }

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
                //button_dnld.Text = "Download";
            }
        }

        private void FtpClientForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Modifiers == System.Windows.Forms.Keys.Control &&
                e.KeyCode == System.Windows.Forms.Keys.W)
            {
                _watchDogForm.Location = this.Location;
                _watchDogForm.ShowDialog();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_uploadImageQueue != null && _uploadImageQueue.GetCount() > 0)
            {
                //pop all and upload
                List<OriginalImage> images = _uploadImageQueue.PopAll();
                foreach (var image in images)
                {
                    listViewData.AppendLog(new string[] { image.FileName,"uploading..."});
                }
            }
        }
    }
}
