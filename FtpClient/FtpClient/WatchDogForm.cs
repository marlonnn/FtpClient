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
        private StringBuilder stringBuilder;
        private bool bDirty;
        private System.IO.FileSystemWatcher watcher;
        private bool bIsWatching;
        private UploadImageQueue uploadImageQueue;
        private WatchDogSettings settings;

        public WatchDogForm()
        {
            InitializeComponent();
            stringBuilder = new StringBuilder();
            bDirty = false;
            bIsWatching = false;
        }

        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            if (bIsWatching)
            {
                bIsWatching = false;
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
                btnWatchFile.BackColor = Color.LightSkyBlue;
                btnWatchFile.Text = "Start Watching";

            }
            else
            {
                bIsWatching = true;
                btnWatchFile.BackColor = Color.Red;
                btnWatchFile.Text = "Stop Watching";

                watcher = new System.IO.FileSystemWatcher();
                if (rdbDir.Checked)
                {
                    watcher.Filter = "*.*";
                    watcher.Path = txtFile.Text + "\\";
                }
                else
                {
                    watcher.Filter = txtFile.Text.Substring(txtFile.Text.LastIndexOf('\\') + 1);
                    watcher.Path = txtFile.Text.Substring(0, txtFile.Text.Length - watcher.Filter.Length);
                }

                if (chkSubFolder.Checked)
                {
                    watcher.IncludeSubdirectories = true;
                }

                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName | NotifyFilters.DirectoryName;
               watcher.Changed += new FileSystemEventHandler(OnChanged);
               watcher.Created += new FileSystemEventHandler(OnChanged);
               watcher.Deleted += new FileSystemEventHandler(OnChanged);
               watcher.Renamed += new RenamedEventHandler(OnRenamed);
                watcher.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!bDirty)
            {
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append(e.FullPath);
                stringBuilder.Append(" ");
                stringBuilder.Append(e.ChangeType.ToString());
                stringBuilder.Append("    ");
                stringBuilder.Append(DateTime.Now.ToString());
                bDirty = true;
                if (e.ChangeType == WatcherChangeTypes.Created)
                {
                    
                    OriginalImage originalImage = new OriginalImage(new DateTime(), e.Name, e.FullPath);
                    if (uploadImageQueue != null)
                    {
                        uploadImageQueue.Push(originalImage);
                    }
                }
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!bDirty)
            {
                stringBuilder.Remove(0, stringBuilder.Length);
                stringBuilder.Append(e.OldFullPath);
                stringBuilder.Append(" ");
                stringBuilder.Append(e.ChangeType.ToString());
                stringBuilder.Append(" ");
                stringBuilder.Append("to ");
                stringBuilder.Append(e.Name);
                stringBuilder.Append("    ");
                stringBuilder.Append(DateTime.Now.ToString());
                bDirty = true;
                if (rdbFile.Checked)
                {
                    watcher.Filter = e.Name;
                    watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - watcher.Filter.Length);
                }
            }
        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (bDirty)
            {
                lstNotification.BeginUpdate();
                lstNotification.Items.Add(this.stringBuilder.ToString());
                lstNotification.EndUpdate();
                bDirty = false;
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
            //settings = (WatchDogSettings)GetSettingsObject(typeof(WatchDogSettings));
        }

        private void WatchDogForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //SaveSettings();
        }

        private void ApplySettings()
        {

        }

        private void SaveSettings()
        {
            settings.FileMode = this.rdbFile.Checked ? true : false;
            settings.DirectoryMode = this.rdbDir.Checked ? true : false;
            settings.IncludeSubFolders = this.chkSubFolder.Checked ? true : false;
            settings.FileFullName = this.txtFile.Text;
        }

    }
}
