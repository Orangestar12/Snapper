namespace snapper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notif_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notification_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.startSnappingNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseSnappingTemporarilyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSnappingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitSnapperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hrsbox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.minbox = new System.Windows.Forms.NumericUpDown();
            this.secbox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dir_text = new System.Windows.Forms.TextBox();
            this.quitbtn = new System.Windows.Forms.Button();
            this.startbtn = new System.Windows.Forms.Button();
            this.timeout_help = new System.Windows.Forms.Button();
            this.save_help = new System.Windows.Forms.Button();
            this.savebtn = new System.Windows.Forms.Button();
            this.showNotifBox = new System.Windows.Forms.CheckBox();
            this.notifications_help = new System.Windows.Forms.Button();
            this.notification_contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrsbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secbox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notif_icon
            // 
            this.notif_icon.ContextMenuStrip = this.notification_contextMenu;
            this.notif_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("notif_icon.Icon")));
            this.notif_icon.Text = "Snapper";
            this.notif_icon.Visible = true;
            this.notif_icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notif_icon_MouseClick);
            // 
            // notification_contextMenu
            // 
            this.notification_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOptionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.startSnappingNowToolStripMenuItem,
            this.pauseSnappingTemporarilyToolStripMenuItem,
            this.stopSnappingMenuItem,
            this.toolStripSeparator2,
            this.exitSnapperToolStripMenuItem});
            this.notification_contextMenu.Name = "contextMenuStrip1";
            this.notification_contextMenu.Size = new System.Drawing.Size(222, 126);
            // 
            // showOptionsToolStripMenuItem
            // 
            this.showOptionsToolStripMenuItem.Name = "showOptionsToolStripMenuItem";
            this.showOptionsToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.showOptionsToolStripMenuItem.Text = "Show options";
            this.showOptionsToolStripMenuItem.Click += new System.EventHandler(this.showOptionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // startSnappingNowToolStripMenuItem
            // 
            this.startSnappingNowToolStripMenuItem.Name = "startSnappingNowToolStripMenuItem";
            this.startSnappingNowToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.startSnappingNowToolStripMenuItem.Text = "Start snapping now";
            this.startSnappingNowToolStripMenuItem.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // pauseSnappingTemporarilyToolStripMenuItem
            // 
            this.pauseSnappingTemporarilyToolStripMenuItem.Name = "pauseSnappingTemporarilyToolStripMenuItem";
            this.pauseSnappingTemporarilyToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.pauseSnappingTemporarilyToolStripMenuItem.Text = "Pause snapping temporarily";
            this.pauseSnappingTemporarilyToolStripMenuItem.Click += new System.EventHandler(this.pauseSnappingTemporarilyToolStripMenuItem_Click);
            // 
            // stopSnappingMenuItem
            // 
            this.stopSnappingMenuItem.Name = "stopSnappingMenuItem";
            this.stopSnappingMenuItem.Size = new System.Drawing.Size(221, 22);
            this.stopSnappingMenuItem.Text = "Stop Snapping";
            this.stopSnappingMenuItem.Click += new System.EventHandler(this.stopSnappingMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(218, 6);
            // 
            // exitSnapperToolStripMenuItem
            // 
            this.exitSnapperToolStripMenuItem.Name = "exitSnapperToolStripMenuItem";
            this.exitSnapperToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.exitSnapperToolStripMenuItem.Text = "Exit Snapper";
            this.exitSnapperToolStripMenuItem.Click += new System.EventHandler(this.quitbtn_Click);
            // 
            // hrsbox
            // 
            this.hrsbox.Location = new System.Drawing.Point(18, 32);
            this.hrsbox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.hrsbox.Name = "hrsbox";
            this.hrsbox.Size = new System.Drawing.Size(45, 20);
            this.hrsbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hours";
            // 
            // minbox
            // 
            this.minbox.Location = new System.Drawing.Point(69, 32);
            this.minbox.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minbox.Name = "minbox";
            this.minbox.Size = new System.Drawing.Size(45, 20);
            this.minbox.TabIndex = 3;
            // 
            // secbox
            // 
            this.secbox.Location = new System.Drawing.Point(120, 32);
            this.secbox.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.secbox.Name = "secbox";
            this.secbox.Size = new System.Drawing.Size(45, 20);
            this.secbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Snapshot Interval";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.hrsbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.minbox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.secbox);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 71);
            this.panel1.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Save Location";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.dir_text);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(13, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 60);
            this.panel2.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Change Directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // dir_text
            // 
            this.dir_text.BackColor = System.Drawing.SystemColors.Window;
            this.dir_text.Location = new System.Drawing.Point(3, 3);
            this.dir_text.Name = "dir_text";
            this.dir_text.Size = new System.Drawing.Size(179, 20);
            this.dir_text.TabIndex = 10;
            this.dir_text.TextChanged += new System.EventHandler(this.dir_textChange);
            // 
            // quitbtn
            // 
            this.quitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.quitbtn.Location = new System.Drawing.Point(3, 254);
            this.quitbtn.Name = "quitbtn";
            this.quitbtn.Size = new System.Drawing.Size(60, 23);
            this.quitbtn.TabIndex = 10;
            this.quitbtn.Text = "Quit";
            this.quitbtn.UseVisualStyleBackColor = true;
            this.quitbtn.Click += new System.EventHandler(this.quitbtn_Click);
            // 
            // startbtn
            // 
            this.startbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startbtn.Location = new System.Drawing.Point(150, 254);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(58, 23);
            this.startbtn.TabIndex = 11;
            this.startbtn.Text = "Start";
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            this.startbtn.MouseEnter += new System.EventHandler(this.start_notify);
            // 
            // timeout_help
            // 
            this.timeout_help.Location = new System.Drawing.Point(176, 4);
            this.timeout_help.Name = "timeout_help";
            this.timeout_help.Size = new System.Drawing.Size(24, 23);
            this.timeout_help.TabIndex = 12;
            this.timeout_help.Text = "?";
            this.timeout_help.UseVisualStyleBackColor = true;
            this.timeout_help.Click += new System.EventHandler(this.timeout_help_Click);
            // 
            // save_help
            // 
            this.save_help.Location = new System.Drawing.Point(176, 108);
            this.save_help.Name = "save_help";
            this.save_help.Size = new System.Drawing.Size(24, 23);
            this.save_help.TabIndex = 13;
            this.save_help.Text = "?";
            this.save_help.UseVisualStyleBackColor = true;
            this.save_help.Click += new System.EventHandler(this.save_help_Click);
            // 
            // savebtn
            // 
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.savebtn.Location = new System.Drawing.Point(77, 254);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(59, 23);
            this.savebtn.TabIndex = 14;
            this.savebtn.Text = "Save";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // showNotifBox
            // 
            this.showNotifBox.AutoSize = true;
            this.showNotifBox.Checked = true;
            this.showNotifBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showNotifBox.Location = new System.Drawing.Point(9, 217);
            this.showNotifBox.Name = "showNotifBox";
            this.showNotifBox.Size = new System.Drawing.Size(177, 17);
            this.showNotifBox.TabIndex = 15;
            this.showNotifBox.Text = "Display notification on Snapshot";
            this.showNotifBox.UseVisualStyleBackColor = true;
            this.showNotifBox.CheckedChanged += new System.EventHandler(this.showNotifBox_CheckedChanged);
            // 
            // notifications_help
            // 
            this.notifications_help.Location = new System.Drawing.Point(184, 213);
            this.notifications_help.Name = "notifications_help";
            this.notifications_help.Size = new System.Drawing.Size(24, 23);
            this.notifications_help.TabIndex = 16;
            this.notifications_help.Text = "?";
            this.notifications_help.UseVisualStyleBackColor = true;
            this.notifications_help.Click += new System.EventHandler(this.notifications_help_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 289);
            this.Controls.Add(this.notifications_help);
            this.Controls.Add(this.showNotifBox);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.save_help);
            this.Controls.Add(this.timeout_help);
            this.Controls.Add(this.startbtn);
            this.Controls.Add(this.quitbtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Snapper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.notification_contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hrsbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secbox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip notification_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem showOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startSnappingNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseSnappingTemporarilyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitSnapperToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown hrsbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown minbox;
        private System.Windows.Forms.NumericUpDown secbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox dir_text;
        private System.Windows.Forms.Button quitbtn;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.Button timeout_help;
        private System.Windows.Forms.Button save_help;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.NotifyIcon notif_icon;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.ToolStripMenuItem stopSnappingMenuItem;
        private System.Windows.Forms.CheckBox showNotifBox;
        private System.Windows.Forms.Button notifications_help;
    }
}

