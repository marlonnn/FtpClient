namespace FtpClient
{
    partial class FtpClientForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FtpClientForm));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxUserId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.txtBoxServerIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabelSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLocalFile = new System.Windows.Forms.TextBox();
            this.btnFileBrowse = new System.Windows.Forms.Button();
            this.listViewData = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpLoad = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label_mess = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ftpCtl1 = new DotNetRemoting.FTPClientCtl();
            this.groupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.ftpCtl1);
            this.groupBox.Controls.Add(this.txtBoxPassword);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.txtBoxUserId);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.txtBoxPort);
            this.groupBox.Controls.Add(this.txtBoxServerIp);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(511, 107);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Server";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(77, 73);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(186, 21);
            this.txtBoxPassword.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // txtBoxUserId
            // 
            this.txtBoxUserId.Location = new System.Drawing.Point(77, 43);
            this.txtBoxUserId.Name = "txtBoxUserId";
            this.txtBoxUserId.Size = new System.Drawing.Size(186, 21);
            this.txtBoxUserId.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "User ID";
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.Location = new System.Drawing.Point(447, 14);
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.Size = new System.Drawing.Size(52, 21);
            this.txtBoxPort.TabIndex = 4;
            // 
            // txtBoxServerIp
            // 
            this.txtBoxServerIp.Location = new System.Drawing.Point(77, 14);
            this.txtBoxServerIp.Name = "txtBoxServerIp";
            this.txtBoxServerIp.Size = new System.Drawing.Size(315, 21);
            this.txtBoxServerIp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ftp Server";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 460);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(530, 22);
            this.statusStrip1.TabIndex = 1;
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
            this.toolStripLabelStatus.Size = new System.Drawing.Size(44, 17);
            this.toolStripLabelStatus.Text = "Ready";
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
            this.toolStripLabelTime.Size = new System.Drawing.Size(56, 17);
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
            this.toolStripLabelSpeed.Size = new System.Drawing.Size(15, 17);
            this.toolStripLabelSpeed.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Local File";
            // 
            // textBoxLocalFile
            // 
            this.textBoxLocalFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocalFile.Location = new System.Drawing.Point(89, 139);
            this.textBoxLocalFile.Name = "textBoxLocalFile";
            this.textBoxLocalFile.Size = new System.Drawing.Size(383, 21);
            this.textBoxLocalFile.TabIndex = 3;
            // 
            // btnFileBrowse
            // 
            this.btnFileBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileBrowse.Location = new System.Drawing.Point(478, 137);
            this.btnFileBrowse.Name = "btnFileBrowse";
            this.btnFileBrowse.Size = new System.Drawing.Size(45, 23);
            this.btnFileBrowse.TabIndex = 4;
            this.btnFileBrowse.Text = "...";
            this.btnFileBrowse.UseVisualStyleBackColor = true;
            this.btnFileBrowse.Click += new System.EventHandler(this.btnFileBrowse_Click);
            // 
            // listViewData
            // 
            this.listViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewData.BackColor = System.Drawing.Color.Gainsboro;
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderSize});
            this.listViewData.FullRowSelect = true;
            this.listViewData.GridLines = true;
            this.listViewData.Location = new System.Drawing.Point(0, 166);
            this.listViewData.Name = "listViewData";
            this.listViewData.Size = new System.Drawing.Size(536, 233);
            this.listViewData.TabIndex = 5;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 320;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Size";
            this.columnHeaderSize.Width = 100;
            // 
            // btnUpLoad
            // 
            this.btnUpLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpLoad.Location = new System.Drawing.Point(20, 405);
            this.btnUpLoad.Name = "btnUpLoad";
            this.btnUpLoad.Size = new System.Drawing.Size(75, 23);
            this.btnUpLoad.TabIndex = 6;
            this.btnUpLoad.Text = "UpLoad";
            this.btnUpLoad.UseVisualStyleBackColor = true;
            this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Sienna;
            this.label6.Location = new System.Drawing.Point(21, 438);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "Message:";
            // 
            // label_mess
            // 
            this.label_mess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_mess.AutoSize = true;
            this.label_mess.Location = new System.Drawing.Point(90, 440);
            this.label_mess.Name = "label_mess";
            this.label_mess.Size = new System.Drawing.Size(35, 12);
            this.label_mess.TabIndex = 8;
            this.label_mess.Text = "ready";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ftpCtl1
            // 
            this.ftpCtl1.BackColor = System.Drawing.Color.Orange;
            this.ftpCtl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ftpCtl1.ControlPort = 21;
            this.ftpCtl1.FtpToolStripProgressBar = this.toolStripProgressBar;
            this.ftpCtl1.Location = new System.Drawing.Point(318, 48);
            this.ftpCtl1.Name = "ftpCtl1";
            this.ftpCtl1.ProgrBar = null;
            this.ftpCtl1.ProgressLabel = null;
            this.ftpCtl1.RemoteHost = null;
            this.ftpCtl1.Size = new System.Drawing.Size(105, 16);
            this.ftpCtl1.TabIndex = 9;
            this.ftpCtl1.Timeout = 120000;
            this.ftpCtl1.TimeOut = 20000;
            this.ftpCtl1.Visible = false;
            this.ftpCtl1.StatusUpdateEvent += new DotNetRemoting.UpdateDelegate(this.ftpCtl1_StatusUpdateEvent);
            // 
            // FtpClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 482);
            this.Controls.Add(this.label_mess);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnUpLoad);
            this.Controls.Add(this.listViewData);
            this.Controls.Add(this.btnFileBrowse);
            this.Controls.Add(this.textBoxLocalFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(430, 423);
            this.Name = "FtpClientForm";
            this.Text = "FtpClientForm";
            this.Load += new System.EventHandler(this.FtpClientForm_Load);
            this.FormClosing += FtpClientForm_FormClosing;
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxUserId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxPort;
        private System.Windows.Forms.TextBox txtBoxServerIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLocalFile;
        private System.Windows.Forms.Button btnFileBrowse;
        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.Button btnUpLoad;
        private DotNetRemoting.FTPClientCtl ftpCtl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_mess;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

