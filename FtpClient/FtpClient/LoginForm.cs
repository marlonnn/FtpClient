using DotNetRemoting;
using EnterpriseDT.Net.Ftp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace FtpClient
{
    public partial class Login : GenericSaveForm.GenericSavForm
    {
        private FtpSettings _ftpSettings;

        public FTPClientCtl _ftpClientCtrl;
        public Login()
        {
            InitializeComponent();
        }

        public Login(FTPClientCtl FTPClientCtrl)
        {
            InitializeComponent();
            this._ftpClientCtrl = FTPClientCtrl;
            this._ftpClientCtrl.FtpToolStripProgressBar = this.toolStripProgressBar;
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
            //textBox_local_folder.Text = _ftpSettings.LocalFolder;
            _ftpSettings.Password = txtBoxPassword.Text;
            //checkBox_bin.Checked = _ftpSettings.Binary;
            //checkBox_Passive.Checked = _ftpSettings.Passive;
            //textBox_loc_file.Text = _ftpSettings.LocalFile;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CreateFtpConection())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private bool CreateFtpConection()
        {
            try
            {
                _ftpClientCtrl.RemoteHost = txtBoxServerIp.Text;
                int Port = int.Parse(txtBoxPort.Text);
                _ftpClientCtrl.ControlPort = Port;
                _ftpClientCtrl.Connect();
                if (_ftpClientCtrl.IsConnected)
                {
                    _ftpClientCtrl.Login(txtBoxUserId.Text, txtBoxPassword.Text);
                    _ftpClientCtrl.SetTransferType(FTPTransferType.BINARY);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            _ftpSettings = (FtpSettings)GetSettingsObject(typeof(FtpSettings));
            ApplySettings();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSettings();
            base.OnFormClosing(e);
        }

    }
}
