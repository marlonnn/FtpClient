using FtpClient.Binary;
using Summer.System.Collections.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpClient.Queue
{
    /// <summary>
    /// 存放上传图片信息队列
    /// </summary>
    public class UploadImageQueue : ConcurrentQueue<OriginalImage>
    {
        public int GetCount()
        {
            return this.Count;
        }
    }
}
