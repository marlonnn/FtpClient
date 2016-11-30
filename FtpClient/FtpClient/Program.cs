using Summer.System.Core;
using System;
using System.Windows.Forms;

namespace FtpClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                RichFtpClient richFtpClient = SpringHelper.GetObject<RichFtpClient>("richFtpClient");
                //Application.Run(ftpClientForm);
                //Login login = SpringHelper.GetObject<Login>("loginForm");
                //if (login.ShowDialog() == DialogResult.OK)
                //{
                //    login.Dispose();
                //    RichFtpClient ftpClient = new RichFtpClient(login.FTPClientCtrl);
                //    Application.Run(ftpClient);
                //}
                //else
                //{
                //    login.Dispose();
                //}

                //RichFtpClient ftpClient = new RichFtpClient();
                Application.Run(richFtpClient);
            }
            catch (Exception ee)
            {
            }
        }
    }
}
