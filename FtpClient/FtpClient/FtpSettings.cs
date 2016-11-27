using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClient
{
    [Serializable]
    public class FtpSettings
    {
        public string ServerIP;
        public string LocalFolder;
        public int Port = 21;
        public bool Binary = true;
        public bool Passive;
        public string UserID;
        public string Password;
        public string LocalFile;
    }
}
