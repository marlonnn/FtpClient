// This is a part of DotNetRemoting Library
// Copyright (C) 2002-2008 Amplefile
// All rights reserved.
//
// This source code can be used, distributed or modified
// only under terms and conditions 
// of the accompanying license agreement.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DotNetRemoting
{
    [ToolboxItem(false)]
    public partial class BaseDownloaderControl : UserControl
    {
        protected BaseDownloader _BaseDownloader;
        protected ProgressBar _ProgrBar;
        protected Label _ProgressLabel;
        protected Label _TimeLabel;
        ToolStripProgressBar _ToolStripProgressBar;
        
        protected void UpdateStatusEventHandler(string Message, DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {
            Invoke(new UpdateDelegate(UpdateLocal), new object[] { Message, Status, FullSize, CurrentBytes, EstimatedTimeLeft, Speed });
        }

        public ProgressBar ProgrBar
        {
            get
            {
                return _ProgrBar;
            }
            set
            {
                _ProgrBar = value;
            }
        }

        public ToolStripProgressBar FtpToolStripProgressBar
        {
            get
            {
                return _ToolStripProgressBar;
            }
            set
            {
                _ToolStripProgressBar = value;
            }
        }
        
        public void SetLocalFolder(string FolderPath)
        {
            _BaseDownloader.LocalFolder = FolderPath; 
        }

        protected Label TimeLabel
        {
            get { return _TimeLabel; }
            set { _TimeLabel = value; }
        }

        public BaseDownloaderControl()
        {
            InitializeComponent();
            Visible = false;
        }

        public Label ProgressLabel
        {
            get { return _ProgressLabel; }
            set { _ProgressLabel = value; }
        }

        public int TimeOut
        {
            get 
            {
                return _BaseDownloader.BaseTimeOut; 
            }
            set { _BaseDownloader.BaseTimeOut = value; }
        }

        public void Start()
        {
            _BaseDownloader.Start();
        }

        public void Abort()
        {
            _BaseDownloader.Abort();
        }

        protected virtual void EventCaller(string Message, DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {
        }

        protected virtual void UpdateLocal(string Message, DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {
            EventCaller(Message, Status, FullSize, CurrentBytes, EstimatedTimeLeft, Speed);
           
            if (FullSize != 0 && FullSize != -1)
            {
                if (_ProgrBar != null)
                {
                    int Val = (int)(((double)CurrentBytes / (double)FullSize) * 100);
                    if (Val > 100)
                        Val = 100;

                    _ProgrBar.Value = Val;
                }

                if (_ToolStripProgressBar != null)
                {
                    int Val = (int)(((double)CurrentBytes / (double)FullSize) * 100);
                    if (Val > 100)
                        Val = 100;

                    _ToolStripProgressBar.Value = Val;

                    _ToolStripProgressBar.Owner.Refresh();
                }

                if (_ProgressLabel != null)
                {
                    _ProgressLabel.Text = CurrentBytes.ToString() + " Kb of " + FullSize.ToString() + " Kb";
                }

                if (_TimeLabel != null)
                {
                    _TimeLabel.Text = EstimatedTimeLeft.ToString();
                }
            }
        }
    }
}
