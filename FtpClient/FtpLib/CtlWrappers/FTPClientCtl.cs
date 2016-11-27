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
using System.Net;
using EnterpriseDT.Net.Ftp;

namespace DotNetRemoting
{
    [ToolboxBitmapAttribute(typeof(DotNetRemoting.FTPClientCtl), "FTPClientCtl.bmp")]
    [ToolboxItem(true)]
    public partial class FTPClientCtl : BaseDownloaderControl
    {
        FtpMulty _Ftp;
        public event UpdateDelegate StatusUpdateEvent;

        public FTPClientCtl()
        {
            InitializeComponent();
            _Ftp = new FtpMulty();
            _BaseDownloader = _Ftp;
            _Ftp.UpdateStatusEvent += new UpdateDelegate(UpdateStatusEventHandler);
        }

        #region Ftp Options

        #endregion

        protected override void EventCaller(string Message, DStatus Status, long FullSize, long CurrentBytes, TimeSpan EstimatedTimeLeft, double Speed)
        {
            if (Status == DStatus.statbar)
                return;

            if (StatusUpdateEvent != null)
                StatusUpdateEvent(Message, Status, FullSize, CurrentBytes, EstimatedTimeLeft, Speed);
        }
        public void Login(string User, string Password)
        {
            _Ftp.Login(User, Password);
        }

        public void Download(string LocalFolder, string fileName)
        {
            _Ftp.GetEx(LocalFolder, fileName);
        }

        public int Timeout
        {
            get { return _Ftp.FtpMulTimeout; }
            set { _Ftp.FtpMulTimeout = value; }
        }

        public FTPFile[] GetDetails()
        {
            return _Ftp.ListDirectoryDetail();
        }

        public FTPFile[] GetDetails(string Dir)
        {
            return _Ftp.ListDirectoryDetail(Dir);
        }

        public string[] Dir()
        {
            return Dir(null);
        }

        public virtual void Put(string localPath, string remoteFile)
        {
            _Ftp.Put(localPath, remoteFile);
        }

        public string[] Dir(string dirname)
        {
            return _Ftp.Dir(dirname);
        }

        public bool IsConnected
        {
            get { return _Ftp.IsConnected; }
        }

        public void CancelTransfer()
        {
            _Ftp.CancelTransfer();
        }

        public void GetEx(string LocalFie, string RemoteFile)
        {
            _Ftp.GetEx(LocalFie, RemoteFile);
        }

        public virtual void Connect()
        {
            _Ftp.Connect();
        }

        public virtual string RemoteHost
        {
            get { return _Ftp.RemoteHost; }
            set { _Ftp.RemoteHost = value; }
        }

        public void Delete(string remoteFile)
        {
            _Ftp.Delete(remoteFile);
        }

        public void Rename(string from, string to)
        {
            _Ftp.Rename(from, to);
        }

        public void RmDir(string dir)
        {
            _Ftp.RmDir(dir);
        }

        public void ChDir(string dir)
        {
            _Ftp.ChDir(dir);
        }

        public void MkDir(string dir)
        {
            _Ftp.MkDir(dir);
        }

        public string Pwd()
        {
            return _Ftp.Pwd();
        }

        public string[] Features()
        {
            return _Ftp.Features();
        }

        public string GetSystem()
        {
            return _Ftp.GetSystem();
        }

        public void NoOperation()
        {
            _Ftp.NoOperation();
        }

        public void Quit()
        {
            _Ftp.Quit();
        }

        public void QuitImmediately()
        {
            _Ftp.QuitImmediately();
        }

        public bool Exists(string remoteFile)
        {
            return _Ftp.Exists(remoteFile);
        }

        public void SetConnectMode(FTPConnectMode cm)
        {
            _Ftp.ConnectMode = cm;
        }

        public FTPConnectMode GetConnectMode()
        {
            return _Ftp.ConnectMode;
        }

        public int ControlPort
        {
            get { return _Ftp.ControlPort; }
            set { _Ftp.ControlPort = value; }
        }

        public void SetTransferType(FTPTransferType TranType)
        {
            _Ftp.TransferType = TranType;
        }

        public FTPTransferType GetTransferType()
        {
            return _Ftp.TransferType; 
        }
    }
}
