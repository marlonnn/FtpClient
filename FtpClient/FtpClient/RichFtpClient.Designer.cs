namespace FtpClient
{
    partial class RichFtpClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.lstNotification = new System.Windows.Forms.ListBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnWatchFile = new System.Windows.Forms.Button();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.tmrEditNotify = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSubFolder = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.rdbDir = new System.Windows.Forms.RadioButton();
            this.rdbFile = new System.Windows.Forms.RadioButton();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgOpenDir = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_mess = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectedStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ftpCtl1 = new DotNetRemoting.FTPClientCtl();
            this.listViewData = new FtpClient.LogListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Change Notifications";
            // 
            // lstNotification
            // 
            this.lstNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNotification.FormattingEnabled = true;
            this.lstNotification.ItemHeight = 12;
            this.lstNotification.Location = new System.Drawing.Point(9, 181);
            this.lstNotification.Name = "lstNotification";
            this.lstNotification.Size = new System.Drawing.Size(669, 100);
            this.lstNotification.TabIndex = 21;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(9, 93);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(124, 13);
            this.lblFile.TabIndex = 19;
            this.lblFile.Text = "Select File/Directory";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(10, 110);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(312, 21);
            this.txtFile.TabIndex = 18;
            // 
            // btnWatchFile
            // 
            this.btnWatchFile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnWatchFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWatchFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnWatchFile.Location = new System.Drawing.Point(9, 134);
            this.btnWatchFile.Name = "btnWatchFile";
            this.btnWatchFile.Size = new System.Drawing.Size(139, 21);
            this.btnWatchFile.TabIndex = 20;
            this.btnWatchFile.Text = "Start Watching";
            this.btnWatchFile.UseVisualStyleBackColor = false;
            this.btnWatchFile.Click += new System.EventHandler(this.btnWatchFile_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBrowseFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowseFile.Location = new System.Drawing.Point(330, 107);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(87, 21);
            this.btnBrowseFile.TabIndex = 24;
            this.btnBrowseFile.Text = "Browse";
            this.btnBrowseFile.UseVisualStyleBackColor = false;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLog.Location = new System.Drawing.Point(184, 134);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(139, 21);
            this.btnLog.TabIndex = 25;
            this.btnLog.Text = "Dump To Log";
            this.btnLog.UseVisualStyleBackColor = false;
            // 
            // tmrEditNotify
            // 
            this.tmrEditNotify.Enabled = true;
            this.tmrEditNotify.Tick += new System.EventHandler(this.tmrEditNotify_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSubFolder);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.rdbDir);
            this.groupBox1.Controls.Add(this.rdbFile);
            this.groupBox1.Location = new System.Drawing.Point(14, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 63);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // chkSubFolder
            // 
            this.chkSubFolder.AutoSize = true;
            this.chkSubFolder.Enabled = false;
            this.chkSubFolder.Location = new System.Drawing.Point(216, 42);
            this.chkSubFolder.Name = "chkSubFolder";
            this.chkSubFolder.Size = new System.Drawing.Size(94, 16);
            this.chkSubFolder.TabIndex = 2;
            this.chkSubFolder.Text = "Subfolders";
            this.chkSubFolder.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(310, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 20);
            this.comboBox1.TabIndex = 33;
            this.comboBox1.Visible = false;
            // 
            // rdbDir
            // 
            this.rdbDir.AutoSize = true;
            this.rdbDir.Location = new System.Drawing.Point(7, 39);
            this.rdbDir.Name = "rdbDir";
            this.rdbDir.Size = new System.Drawing.Size(128, 16);
            this.rdbDir.TabIndex = 1;
            this.rdbDir.Text = "Watch Directory";
            this.rdbDir.UseVisualStyleBackColor = true;
            // 
            // rdbFile
            // 
            this.rdbFile.AutoSize = true;
            this.rdbFile.Checked = true;
            this.rdbFile.Location = new System.Drawing.Point(7, 18);
            this.rdbFile.Name = "rdbFile";
            this.rdbFile.Size = new System.Drawing.Size(93, 16);
            this.rdbFile.TabIndex = 0;
            this.rdbFile.TabStop = true;
            this.rdbFile.Text = "Watch File";
            this.rdbFile.UseVisualStyleBackColor = true;
            // 
            // dlgOpenDir
            // 
            this.dlgOpenDir.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.DefaultExt = "log";
            this.dlgSaveFile.Filter = "LogFiles|*.log";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripLabelStatus,
            this.toolStripProgressBar,
            this.toolStripStatusLabel2,
            this.toolStripLabelTime,
            this.toolStripLabel3,
            this.toolStripLabelSpeed});
            this.statusStrip1.Location = new System.Drawing.Point(0, 500);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // toolStripLabelStatus
            // 
            this.toolStripLabelStatus.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabelStatus.Name = "toolStripLabelStatus";
            this.toolStripLabelStatus.Size = new System.Drawing.Size(39, 17);
            this.toolStripLabelStatus.Text = "Ready";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(175, 16);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel2.Text = "Time Left";
            // 
            // toolStripLabelTime
            // 
            this.toolStripLabelTime.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabelTime.Name = "toolStripLabelTime";
            this.toolStripLabelTime.Size = new System.Drawing.Size(49, 17);
            this.toolStripLabelTime.Text = "00:00:00";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(49, 17);
            this.toolStripLabel3.Text = "Speed:";
            // 
            // toolStripLabelSpeed
            // 
            this.toolStripLabelSpeed.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabelSpeed.Name = "toolStripLabelSpeed";
            this.toolStripLabelSpeed.Size = new System.Drawing.Size(13, 17);
            this.toolStripLabelSpeed.Text = "0";
            // 
            // label_mess
            // 
            this.label_mess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_mess.AutoSize = true;
            this.label_mess.Location = new System.Drawing.Point(86, 481);
            this.label_mess.Name = "label_mess";
            this.label_mess.Size = new System.Drawing.Size(40, 12);
            this.label_mess.TabIndex = 29;
            this.label_mess.Text = "ready";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Sienna;
            this.label6.Location = new System.Drawing.Point(6, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 28;
            this.label6.Text = "Message:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.logOffToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(686, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.openToolStripMenuItem.Text = "Login";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.logOffToolStripMenuItem.Text = "LogOut";
            this.logOffToolStripMenuItem.Click += new System.EventHandler(this.StripMenuItemLogOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "Connected Status:";
            // 
            // ConnectedStatus
            // 
            this.ConnectedStatus.AutoSize = true;
            this.ConnectedStatus.ForeColor = System.Drawing.Color.Blue;
            this.ConnectedStatus.Location = new System.Drawing.Point(135, 9);
            this.ConnectedStatus.Name = "ConnectedStatus";
            this.ConnectedStatus.Size = new System.Drawing.Size(89, 12);
            this.ConnectedStatus.TabIndex = 35;
            this.ConnectedStatus.Text = "Disconnected";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ConnectedStatus);
            this.panel1.Location = new System.Drawing.Point(450, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 25);
            this.panel1.TabIndex = 36;
            // 
            // ftpCtl1
            // 
            this.ftpCtl1.BackColor = System.Drawing.Color.Orange;
            this.ftpCtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ftpCtl1.ControlPort = 21;
            this.ftpCtl1.FtpToolStripProgressBar = this.toolStripProgressBar;
            this.ftpCtl1.Location = new System.Drawing.Point(411, 37);
            this.ftpCtl1.Name = "ftpCtl1";
            this.ftpCtl1.ProgrBar = null;
            this.ftpCtl1.ProgressLabel = null;
            this.ftpCtl1.RemoteHost = null;
            this.ftpCtl1.Size = new System.Drawing.Size(122, 16);
            this.ftpCtl1.TabIndex = 31;
            this.ftpCtl1.Timeout = 120000;
            this.ftpCtl1.TimeOut = 20000;
            this.ftpCtl1.Visible = false;
            this.ftpCtl1.StatusUpdateEvent += new DotNetRemoting.UpdateDelegate(this.FtpClientCtrl_StatusUpdateEvent);
            // 
            // listViewData
            // 
            this.listViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewData.BackColor = System.Drawing.Color.Gainsboro;
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderStatus});
            this.listViewData.FullRowSelect = true;
            this.listViewData.GridLines = true;
            this.listViewData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewData.HideSelection = false;
            this.listViewData.Location = new System.Drawing.Point(9, 286);
            this.listViewData.MaxLogRecords = 300;
            this.listViewData.MultiSelect = false;
            this.listViewData.Name = "listViewData";
            this.listViewData.ShowGroups = false;
            this.listViewData.Size = new System.Drawing.Size(669, 196);
            this.listViewData.TabIndex = 26;
            this.listViewData.Timer = null;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 320;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 100;
            // 
            // RichFtpClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 522);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ftpCtl1);
            this.Controls.Add(this.label_mess);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listViewData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstNotification);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnWatchFile);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RichFtpClient";
            this.Text = "FtpClient";
            this.Load += new System.EventHandler(this.FtpClient_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstNotification;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnWatchFile;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Timer tmrEditNotify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSubFolder;
        private System.Windows.Forms.RadioButton rdbDir;
        private System.Windows.Forms.RadioButton rdbFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenDir;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private FtpClient.LogListView listViewData;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelSpeed;
        private System.Windows.Forms.Label label_mess;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private DotNetRemoting.FTPClientCtl ftpCtl1;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ConnectedStatus;
        private System.Windows.Forms.Panel panel1;
    }
}