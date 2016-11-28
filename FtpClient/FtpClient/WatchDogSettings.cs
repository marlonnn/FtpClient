using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClient
{
    [Serializable]
    public class WatchDogSettings
    {
        public bool FileMode;
        public bool DirectoryMode;
        public bool IncludeSubFolders;

        public string FileFullName;

    }
}
