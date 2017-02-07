using System;

namespace FtpClient
{
    /// <summary>
    /// FTP相关信息类
    /// </summary>
    [Serializable]
    public class FtpSettings
    {
        public string ServerIP;
        public string LocalFolder;
        public int Port;
        public bool Binary = true;
        public bool Passive;
        public string UserID;
        public string Password;
        public string LocalFile;
    }
}
