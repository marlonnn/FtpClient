using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClient.Binary
{
    public class OriginalImage
    {
        public DateTime DetectedTime { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public OriginalImage (DateTime detectedTime, string fileName, string FilePath)
        {
            this.DetectedTime = detectedTime;
            this.FileName = fileName;
            this.FilePath = FilePath;
        }
    }
}
