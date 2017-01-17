// This is a part of DotNetRemoting Library
// Copyright (C) 2002-2008 Amplefile
// All rights reserved.
//
// This source code can be used, distributed or modified
// only under terms and conditions 
// of the accompanying license agreement.

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using EnterpriseDT.Net.Ftp;

namespace DotNetRemoting
{
    public class FtpMulty : BaseDownloader
    {
        FtpAction _Action;
        FtpClientEx _FtpClientEx;
        bool _TransferCanceled;

        public bool TransferCanceled
        {
            get { return _TransferCanceled; }
            set { _TransferCanceled = value; }
        }

        public FtpMulty()
        {
            _FtpClientEx = new FtpClientEx();
            _FtpClientEx.BytesTransferredEx += new ButesRxDelegate(_FtpClientEx_BytesTransferredEx);

            BaseTimeOut = _FtpClientEx.Timeout + 1000;
        }

        void _FtpClientEx_BytesTransferredEx(int Percent, TimeSpan TimeLeft, double Speed)
        {
            UpdateStatusEvent("transferring", DStatus.transferring, 100, Percent, TimeLeft, Speed);
            ResetTimeoutTimer();
        }

        private void SetStatusBar(int Percent)
        {
            UpdateStatusEvent("complete", DStatus.statbar, 100, Percent, TimeSpan.Zero, 0);
        }

        public int FtpMulTimeout
        {
            get
            {
                return _FtpClientEx.Timeout;
            }
            set
            {
                _FtpClientEx.Timeout = value;
                BaseTimeOut = value + 1000;
            }
        }

        protected override void StartOperation()
        {
            try
            {
                switch (_Action)
                {
                    case FtpAction.Download:
                        GetEx_Intern();
                        break;

                    case FtpAction.Upload:
                        Put_Intern();
                        break;
                }
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error:" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
                StopTimer();
            }
        }

        public void Delete(string remoteFile)
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.Delete(remoteFile);
                UpdateStatusEvent("Delete complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(del):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void Rename(string from, string to)
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.Rename(from, to);
                UpdateStatusEvent("Rename complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(ren):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void RmDir(string dir)
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.RmDir(dir);
                UpdateStatusEvent("RmDir complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(RmDir):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void ChDir(string dir)
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.ChDir(dir);
                UpdateStatusEvent("ChDir complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(ChDir):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void ChDir(string dir, bool noStatusBar = true)
        {
            _FtpClientEx.ChDir(dir);
        }

        public string Pwd()
        {
            try
            {
                string Res = null;
                SetStatusBar(10);
                Res = _FtpClientEx.Pwd();
                UpdateStatusEvent("ChDir complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
                return Res;
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(ChDir):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
            return null;
        }

        public string[] Features()
        {
            try
            {
                string[] Res = null;
                SetStatusBar(10);
                Res = _FtpClientEx.Features();
                UpdateStatusEvent("Features complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
                return Res;
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(Features):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
            return null;
        }

        public string GetSystem()
        {
            try
            {
                string Res = null;
                SetStatusBar(10);
                Res = _FtpClientEx.GetSystem();
                UpdateStatusEvent("GetSystem complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
                return Res;
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(GetSystem):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
            return null;
        }

        public void NoOperation()
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.NoOperation();
                UpdateStatusEvent("NoOperation complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(NoOperation):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void Quit()
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.Quit();
                UpdateStatusEvent("Quit complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(Quit):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void LogOut()
        {
            _FtpClientEx.Quit();
        }

        public void QuitImmediately()
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.QuitImmediately();
                UpdateStatusEvent("QuitImmediately complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(QuitImmediately):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void MkDir(string dir)
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.MkDir(dir);
                UpdateStatusEvent("MkDir complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(MkDir):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void MkDir(string dir, bool noStatusBar = true)
        {
            _FtpClientEx.MkDir(dir);
        }

        public bool Exists(string remoteFile)
        {
            try
            {
                SetStatusBar(10);
                bool Res = _FtpClientEx.Exists(remoteFile);
                UpdateStatusEvent("Exists complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
                return Res;
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(Exists):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }

            return false;
        }

        public FTPFile[] ListDirectoryDetail()
        {
            return ListDirectoryDetail(null);
        }

        public FTPFile[] ListDirectoryDetail(string dirname)
        {
            try
            {
                SetStatusBar(10);
                FTPFile[] FtpFiles = _FtpClientEx.DirDetails(dirname);
                UpdateStatusEvent("Details complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
                return (FTPFile[])FtpFiles;
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(1):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }

            return null;
        }

        public FTPFile[] ListDirectoryDetail(string dirname, bool list = true)
        {
            return _FtpClientEx.DirDetails(dirname);
        }

        public FTPFile[] GetSubFolders()
        {
            try
            {
                FTPFile[] FtpFiles = _FtpClientEx.DirDetails();
                return (FTPFile[])FtpFiles;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FTPFile[] GetSubFolders(string dir)
        {
            try
            {
                FTPFile[] FtpFiles = _FtpClientEx.DirDetails(dir);
                return (FTPFile[])FtpFiles;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual string[] Dir()
        {
            return Dir(null);
        }

        public virtual string[] Dir(string dirname)
        {
            try
            {
                SetStatusBar(10);
                string[] list = _FtpClientEx.Dir(dirname, false);
                UpdateStatusEvent("dir complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                SetStatusBar(100);
                return list;
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(a):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }

            return null;
        }

        public void Login(string User, string Password)
        {
            try
            {
                SetStatusBar(10);
                _FtpClientEx.Login(User, Password);
                SetStatusBar(100);
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(2):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void GetEx(string LocalFie, string RemoteFile)
        {
            _Action = FtpAction.Download;
            _Params = new object[] { LocalFie, RemoteFile };
            Start();
        }
        public void Put(string localPath, string remoteFile)
        {
            _Action = FtpAction.Upload;
            _Params = new object[] { localPath, remoteFile };
            Start();
        }

        public virtual void Put_Intern()
        {
            try
            {
                if (_Busy)
                {
                    UpdateStatusEvent("Busy", DStatus.busy, 0, 0, TimeSpan.Zero, 0);
                    return;
                }

                _TransferCanceled = false;
                _Busy = true;

                //_FtpClientEx.TransferType = FTPTransferType.BINARY;
                string FilePath = (string)_Params[0];
                FileInfo fi = new FileInfo(FilePath);
                _FtpClientEx.FSize = fi.Length;
                _FtpClientEx.Put(FilePath, (string)_Params[1]);

                if (_TransferCanceled)
                {
                    UpdateStatusEvent("upload aborted:", DStatus.aborted, 0, 0, TimeSpan.Zero, 0);
                }
                else
                {
                    UpdateStatusEvent("upload complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                }
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(b):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
            finally
            {
                StopTimer();
            }

            _Busy = false;
        }

        public void CancelTransfer()
        {
            try
            {
                _FtpClientEx.CancelTransfer();
                _TransferCanceled = true;
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(3):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public void GetEx_Intern()
        {
            try
            {
                if (_Busy)
                {
                    UpdateStatusEvent("Busy", DStatus.busy, 0, 0, TimeSpan.Zero, 0);
                    return;
                }

                _TransferCanceled = false;

                _Busy = true;

                //_FtpClientEx.TransferType = FTPTransferType.BINARY;
                _FtpClientEx.GetEx((string)_Params[0], (string)_Params[1]);

                if (_TransferCanceled)
                {
                    UpdateStatusEvent("download aborted:", DStatus.aborted, 0, 0, TimeSpan.Zero, 0);
                }
                else
                {
                    UpdateStatusEvent("download complete:", DStatus.complete, 0, 0, TimeSpan.Zero, 0);
                }
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(4):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
            finally
            {
                StopTimer();
            }

            _Busy = false;
        }

        public bool IsConnected
        {
            get 
            {
                try
                {
                    return _FtpClientEx.Connected;
                }
                catch (Exception ex)
                {
                    UpdateStatusEvent("Error(IsConnected):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
                }

                return false;
            }
        }

        public void Connect()
        {
            try
            {
                _FtpClientEx.Connect();
            }
            catch (Exception ex)
            {
                UpdateStatusEvent("Error(Connect):" + ex.Message, DStatus.error, 0, 0, TimeSpan.Zero, 0);
            }
        }

        public virtual string RemoteHost
        {
            get { return _FtpClientEx.RemoteHost; }
            set { _FtpClientEx.RemoteHost = value; }
        }

        public FTPConnectMode ConnectMode
        {
            set{_FtpClientEx.ConnectMode = value;}
            get{return _FtpClientEx.ConnectMode;}
        }

        public int ControlPort
        {
            get{return _FtpClientEx.ControlPort;}
            set{_FtpClientEx.ControlPort = value;}
        }

        public FTPTransferType TransferType
        {
            get{return _FtpClientEx.TransferType;}
            set{_FtpClientEx.TransferType = value;}
        }
    }
}
