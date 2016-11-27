// This is a part of DotNetRemoting Library
// Copyright (C) 2002-2008 Amplefile
// All rights reserved.
//
// This source code can be used, distributed or modified
// only under terms and conditions 
// of the accompanying license agreement.

using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace DotNetRemoting
{
    public delegate void UpdateDelegate(string Message, DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed);

    public enum DStatus
    {
        none,
        busy,
        wait,
        started,
        error,
        success,
        complete,
        transferring,
        aborted,
        connecting,
        connected,
        timeout,
        statbar
    };

    public enum FtpAction
    {
        ListDirectory,
        ListDirectoryDetail,
        Upload,
        Download,
        FtpDelete,
        FtpFileExists,
        GetFileSize,
        FtpRename,
        FtpCreateDirectory,
        FtpDeleteDirectory
    };

    public enum UseProxy
    {
        NotProxy,
        UseDefaultProxy,
        UseProxy
    };

    public class BaseDownloader
    {
        public UpdateDelegate UpdateStatusEvent;
        protected bool ThreadStop = false;
        protected DStatus CurrStatus = DStatus.none;
        protected bool AbortFlag = false;
        protected System.Timers.Timer _OpStopTimer;
        protected System.Timers.Timer _TimeoutTimer;
        protected System.Timers.Timer _TickTimer;
        protected long FileLength = 0;
        protected long BytesCounter = 0;
        protected int _TimeOut = 20000;
        protected DateTime TimeStart;
        protected FileStream filestream;
        private Thread fThread;

        protected bool _Busy;

        protected object[] _Params;
        protected object _OutParam;
        string _LocalFolder;

        protected ManualResetEvent OpCompleteEvent = new ManualResetEvent(false);
        
        public BaseDownloader()
        {
            _OpStopTimer = new System.Timers.Timer(500);
            _OpStopTimer.Elapsed += new System.Timers.ElapsedEventHandler(StopTimer_Elapsed);

            _TimeoutTimer = new System.Timers.Timer(_TimeOut);
            _TimeoutTimer.Elapsed += new System.Timers.ElapsedEventHandler(TimeoutTimer_Elapsed);

            _TickTimer = new System.Timers.Timer(50);
            _TickTimer.Elapsed += new System.Timers.ElapsedEventHandler(TickTimer_Elapsed);
            _TickTimer.Start();
        }

        public static string TimeSpanToString(TimeSpan ts)
        {
            DateTime dt = new DateTime(ts.Ticks);
            return dt.ToString("HH:mm:ss");
        }

        public static double CalcSpeed(DateTime start, long CurrentBytes)
        {
            TimeSpan ts = DateTime.Now - start;
            if (ts.TotalMilliseconds == 0)
                return 0;
            double Kd_per_sec = (double)CurrentBytes / (double)ts.TotalMilliseconds;
            return Kd_per_sec;
        }

        public static TimeSpan CalcTimeLeft(DateTime start, long TotalItems, long CurrentItem)
        {
            if (CurrentItem == 0)
                CurrentItem = 1;

            TimeSpan ElapsedTime = DateTime.Now - start;

            long TotalTimeTicks = (long)(ElapsedTime.Ticks * ((double)TotalItems / (double)CurrentItem));
            long TimeLeftTicks = TotalTimeTicks - ElapsedTime.Ticks;

            TimeSpan ts = new TimeSpan(TimeLeftTicks);
            return ts;
        }

        protected void SetProgrBar100()
        {
            DummyProgressStarted = false;
            SetProgrBar(100);
        }

        protected virtual void Worker_Thread_01()
        {
            StartOperation();
        }

        protected void StopTimer()
        {
            _TimeoutTimer.Stop();
            //_Busy = false;
        }

        protected void SetProgrBar(int Percent)
        {
            UpdateStatusEvent("FTP.Operation started", DStatus.statbar, 100, Percent, TimeSpan.Zero, 0);
            Console.WriteLine(Percent.ToString());
        }

        protected virtual void TickTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
        }

        protected virtual void StartASync()
        {
            Worker_Thread_01();
            _Busy = false;
        }

        protected virtual void StartSync()
        {
            OpCompleteEvent.Reset();
            StartOperation();
            bool res = OpCompleteEvent.WaitOne(5000, false);
        }

        protected virtual void StartOperation()
        {
        }

        public string LocalFolder
        {
            set { _LocalFolder = value; }
            get 
            {
                if (_LocalFolder == null)
                    _LocalFolder = Application.StartupPath;

                return _LocalFolder; 
            }
        }

        protected bool DummyProgressStarted = false;
        protected DateTime TimeStarted = DateTime.Now;

        protected void StartDummyProgress()
        {
            DummyProgressStarted = true;
            TimeStarted = DateTime.Now;
        }

        private void StopTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _OpStopTimer.Stop();
            try
            {
                try
                {
                    filestream.Close();
                }
                catch { }

                fThread.Abort();

                StopProc();
            }
            catch
            {
                if (UpdateStatusEvent != null)
                    UpdateStatusEvent("Operation stopped", CurrStatus, FileLength, BytesCounter, TimeSpan.Zero, 0);
            }
        }

        protected virtual void StopProc()
        {
        }

        public int BaseTimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

        protected void ResetTimeoutTimer()
        {
            _TimeoutTimer.Stop();
            _TimeoutTimer.Start();
        }

        public void Start()
        {
            ThreadStop = false;
            AbortFlag = false;
            ThreadStart thr_start_func = new ThreadStart(Worker_Thread_01);
            fThread = new Thread(thr_start_func);
            fThread.Priority = ThreadPriority.BelowNormal;
            fThread.IsBackground = true;
            fThread.Start();
            CurrStatus = DStatus.started;
            _TimeoutTimer.Start();
        }

        public void Abort()
        {
            AbortFlag = true;
            ThreadStop = true;
            _OpStopTimer.Start();
        }

        private void TimeoutTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                try
                {
                    filestream.Close();
                }
                catch
                { }

                _OpStopTimer.Stop();
                _TimeoutTimer.Stop();

                AbortFlag = true;
                ThreadStop = true;

                Thread.Sleep(200);

                CurrStatus = DStatus.error;

                if (UpdateStatusEvent != null)
                    UpdateStatusEvent("Timeout", CurrStatus, FileLength, BytesCounter, TimeSpan.Zero, 0);

                fThread.Abort();
            }
            catch
            { }
            finally
            {
                _Busy = false;
            }
        }
    }
}
