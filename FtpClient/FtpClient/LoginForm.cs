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
    /// <summary>
    /// 登录FTP服务器
    /// </summary>
    public partial class Login : GenericSaveForm.GenericSavForm
    {
        private FtpSettings ftpSettings;

        public FTPClientCtl ftpClientCtrl;
        public Login()
        {
            InitializeComponent();
        }

        public Login(FTPClientCtl FTPClientCtrl)
        {
            InitializeComponent();
            this.ftpClientCtrl = FTPClientCtrl;
            this.ftpClientCtrl.FtpToolStripProgressBar = this.toolStripProgressBar;
        }

        private void ApplySettings()
        {
            txtBoxServerIp.Text = ftpSettings.ServerIP;
            txtBoxUserId.Text = ftpSettings.UserID;
            txtBoxPort.Text = ftpSettings.Port.ToString();
            txtBoxPassword.Text = ftpSettings.Password;
        }

        private void SaveSettings()
        {
            ftpSettings.ServerIP = txtBoxServerIp.Text;
            ftpSettings.UserID = txtBoxUserId.Text;
            ftpSettings.Port = int.Parse(txtBoxPort.Text);
            ftpSettings.Password = txtBoxPassword.Text;
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

        /// <summary>
        /// 创建FTP连接
        /// </summary>
        /// <returns></returns>
        private bool CreateFtpConection()
        {
            try
            {
                ftpClientCtrl.RemoteHost = txtBoxServerIp.Text;
                int Port = int.Parse(txtBoxPort.Text);
                ftpClientCtrl.ControlPort = Port;
                ftpClientCtrl.Connect();
                if (ftpClientCtrl.IsConnected)
                {
                    ftpClientCtrl.Login(txtBoxUserId.Text, txtBoxPassword.Text);
                    ftpClientCtrl.SetTransferType(FTPTransferType.BINARY);
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
            ftpSettings = (FtpSettings)GetSettingsObject(typeof(FtpSettings));
            ApplySettings();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSettings();
            base.OnFormClosing(e);
        }

    }
}
