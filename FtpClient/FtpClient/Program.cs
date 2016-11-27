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
                FtpClientForm ftpClientForm = SpringHelper.GetObject<FtpClientForm>("ftpClientForm");
                //Application.Run(new FtpClientForm());
                Application.Run(ftpClientForm);
            }
            catch (Exception ee)
            {
            }
        }
    }
}
