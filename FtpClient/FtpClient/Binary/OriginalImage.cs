using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClient.Binary
{
    /// <summary>
    /// 图片信息
    /// </summary>
    public class OriginalImage
    {
        //图片被发现时间
        public DateTime DetectedTime { get; set; }

        //文件名
        public string FileName { get; set; }

        //文件路径
        public string FilePath { get; set; }

        public OriginalImage (DateTime detectedTime, string fileName, string FilePath)
        {
            this.DetectedTime = detectedTime;
            this.FileName = fileName;
            this.FilePath = FilePath;
        }
    }
}
