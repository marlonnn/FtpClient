using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using EnterpriseDT.Net.Ftp;

namespace DotNetRemoting
{
    public delegate void ButesRxDelegate(int Percent, TimeSpan TimeLeft, double Speed);
    public delegate void FTPCommandDelegate(DStatus stat, object obj, string Mess);

    public class FtpClientEx : FTPClient
    {
        public event ButesRxDelegate BytesTransferredEx;
        long _FSize = 0;
        public event FTPCommandDelegate FTPCommandEvent;
        DateTime start_time;

        public long FSize
        {
            get { return _FSize; }
            set 
            {
                _FSize = value;
                start_time = DateTime.Now;
            }
        }
        
        public FtpClientEx()
        {
            this.BytesTransferred += new BytesTransferredHandler(FtpClientEx_BytesTransferred);
        }

        public override void CancelTransfer()
        {
            base.CancelTransfer();
            if (FTPCommandEvent != null)
            {
                FTPCommandEvent(DStatus.aborted, null, null);
            }
        }

        void FtpClientEx_BytesTransferred(object sender, BytesTransferredEventArgs e)
        {
            long Cnt = e.ByteCount;

            if (BytesTransferredEx != null)
            {
                int Percent = 0;
                if (_FSize != 0)
                {
                    Percent = (int)((double)e.ByteCount / (double)_FSize * 100);
                    TimeSpan ts = BaseDownloader.CalcTimeLeft(start_time, _FSize, Cnt);
                    BytesTransferredEx(Percent, ts, BaseDownloader.CalcSpeed(start_time, Cnt));
                }
                else
                {
                    BytesTransferredEx(0, TimeSpan.Zero, BaseDownloader.CalcSpeed(start_time, Cnt));
                }
            }
        }

        public void GetEx(string localPath, string remoteFile)
        {
            FTPFile[] ff = DirDetails();

            start_time = DateTime.Now;
            _FSize = 0;

            foreach (FTPFile item in ff)
            {
                if (item.Name == remoteFile)
                {
                    _FSize = item.Size;
                    break;
                }
            }

            Get(localPath, remoteFile);
        }
    }
}
