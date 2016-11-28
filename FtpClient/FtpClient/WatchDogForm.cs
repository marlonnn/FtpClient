using FtpClient.Binary;
using FtpClient.Queue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtpClient
{
    public partial class WatchDogForm : GenericSaveForm.GenericSavForm
    {
        private StringBuilder _stringBuilder;
        private bool _bDirty;
        private System.IO.FileSystemWatcher _Watcher;
        private bool _bIsWatching;
        private UploadImageQueue _uploadImageQueue;
        private WatchDogSettings _settings;

        public WatchDogForm()
        {
            InitializeComponent();
            _stringBuilder = new StringBuilder();
            _bDirty = false;
            _bIsWatching = false;
        }

        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            if (_bIsWatching)
            {
                _bIsWatching = false;
                _Watcher.EnableRaisingEvents = false;
                _Watcher.Dispose();
                btnWatchFile.BackColor = Color.LightSkyBlue;
                btnWatchFile.Text = "Start Watching";

            }
            else
            {
                _bIsWatching = true;
                btnWatchFile.BackColor = Color.Red;
                btnWatchFile.Text = "Stop Watching";

                _Watcher = new System.IO.FileSystemWatcher();
                if (rdbDir.Checked)
                {
                    _Watcher.Filter = "*.*";
                    _Watcher.Path = txtFile.Text + "\\";
                }
                else
                {
                    _Watcher.Filter = txtFile.Text.Substring(txtFile.Text.LastIndexOf('\\') + 1);
                    _Watcher.Path = txtFile.Text.Substring(0, txtFile.Text.Length - _Watcher.Filter.Length);
                }

                if (chkSubFolder.Checked)
                {
                    _Watcher.IncludeSubdirectories = true;
                }

                _Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName | NotifyFilters.DirectoryName;
               _Watcher.Changed += new FileSystemEventHandler(OnChanged);
               _Watcher.Created += new FileSystemEventHandler(OnChanged);
               _Watcher.Deleted += new FileSystemEventHandler(OnChanged);
               _Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                _Watcher.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!_bDirty)
            {
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(e.FullPath);
                _stringBuilder.Append(" ");
                _stringBuilder.Append(e.ChangeType.ToString());
                _stringBuilder.Append("    ");
                _stringBuilder.Append(DateTime.Now.ToString());
                _bDirty = true;
                if (e.ChangeType == WatcherChangeTypes.Created)
                {
                    
                    OriginalImage originalImage = new OriginalImage(new DateTime(), e.Name, e.FullPath);
                    if (_uploadImageQueue != null)
                    {
                        _uploadImageQueue.Push(originalImage);
                    }
                }
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!_bDirty)
            {
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(e.OldFullPath);
                _stringBuilder.Append(" ");
                _stringBuilder.Append(e.ChangeType.ToString());
                _stringBuilder.Append(" ");
                _stringBuilder.Append("to ");
                _stringBuilder.Append(e.Name);
                _stringBuilder.Append("    ");
                _stringBuilder.Append(DateTime.Now.ToString());
                _bDirty = true;
                if (rdbFile.Checked)
                {
                    _Watcher.Filter = e.Name;
                    _Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - _Watcher.Filter.Length);
                }
            }
        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (_bDirty)
            {
                lstNotification.BeginUpdate();
                lstNotification.Items.Add(this._stringBuilder.ToString());
                lstNotification.EndUpdate();
                _bDirty = false;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (rdbDir.Checked)
            {
                DialogResult resDialog = dlgOpenDir.ShowDialog();
                if (resDialog.ToString() == "OK")
                {
                    txtFile.Text = dlgOpenDir.SelectedPath;
                }
            }
            else
            {
                DialogResult resDialog = dlgOpenFile.ShowDialog();
                if (resDialog.ToString() == "OK")
                {
                    txtFile.Text = dlgOpenFile.FileName;
                }
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            DialogResult resDialog = dlgSaveFile.ShowDialog();
            if (resDialog.ToString() == "OK")
            {
                FileInfo fi = new FileInfo(dlgSaveFile.FileName);
                StreamWriter sw = fi.CreateText();
                foreach (string sItem in lstNotification.Items)
                {
                    sw.WriteLine(sItem);
                }
                sw.Close();
            }
        }

        private void rdbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFile.Checked == true)
            {
                chkSubFolder.Enabled = false;
                chkSubFolder.Checked = false;
            }
        }

        private void rdbDir_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDir.Checked == true)
            {
                chkSubFolder.Enabled = true;
            }
        }

        private void WatchDogForm_Load(object sender, EventArgs e)
        {
            _settings = (WatchDogSettings)GetSettingsObject(typeof(WatchDogSettings));
        }

        private void WatchDogForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void ApplySettings()
        {

        }

        private void SaveSettings()
        {
            _settings.FileMode = this.rdbFile.Checked ? true : false;
            _settings.DirectoryMode = this.rdbDir.Checked ? true : false;
            _settings.IncludeSubFolders = this.chkSubFolder.Checked ? true : false;
            _settings.FileFullName = this.txtFile.Text;
        }

    }
}
