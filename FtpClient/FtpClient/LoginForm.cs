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
    public partial class Login : Form
    {
        private FtpSettings _ftpSettings;
        private Session _ftpSession;

        public Session Session { get { return this._ftpSession; } }
        public Login()
        {
            InitializeComponent();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CreateFtpSession())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private bool CreateFtpSession()
        {
            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions();
                sessionOptions.Protocol = Protocol.Ftp;
                sessionOptions.HostName = txtBoxServerIp.Text;
                sessionOptions.UserName = txtBoxUserId.Text;
                sessionOptions.Password = txtBoxPassword.Text;
                _ftpSession = new Session();
                _ftpSession.Open(sessionOptions);
                return true;
            }
            catch (Exception e)
            {
                _ftpSession.Dispose();
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ApplySettings();
        }
    }
}
