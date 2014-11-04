namespace DevCraft.UI.Forms
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serverOutput = new System.Windows.Forms.TextBox();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.sendCommand = new System.Windows.Forms.Button();
            this.generalDirBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.sDirButton = new System.Windows.Forms.Button();
            this.sDirLabel = new System.Windows.Forms.Label();
            this.bDirButton = new System.Windows.Forms.Button();
            this.bDirLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.startServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeOldBackupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverName = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(0, 0);
            this.textBox1.TabIndex = 0;
            // 
            // serverOutput
            // 
            this.serverOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverOutput.BackColor = System.Drawing.Color.White;
            this.serverOutput.CausesValidation = false;
            this.serverOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverOutput.Location = new System.Drawing.Point(12, 80);
            this.serverOutput.Multiline = true;
            this.serverOutput.Name = "serverOutput";
            this.serverOutput.ReadOnly = true;
            this.serverOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverOutput.Size = new System.Drawing.Size(716, 393);
            this.serverOutput.TabIndex = 1;
            // 
            // inputBox
            // 
            this.inputBox.AllowDrop = true;
            this.inputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputBox.Location = new System.Drawing.Point(12, 481);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(586, 20);
            this.inputBox.TabIndex = 2;
            // 
            // sendCommand
            // 
            this.sendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendCommand.Location = new System.Drawing.Point(606, 479);
            this.sendCommand.Name = "sendCommand";
            this.sendCommand.Size = new System.Drawing.Size(123, 23);
            this.sendCommand.TabIndex = 5;
            this.sendCommand.Text = "Send Command";
            this.sendCommand.UseVisualStyleBackColor = true;
            this.sendCommand.Click += new System.EventHandler(this.sendCommand_Click);
            // 
            // generalDirBrowser
            // 
            this.generalDirBrowser.Description = "Minecraft Server Directory";
            // 
            // sDirButton
            // 
            this.sDirButton.Location = new System.Drawing.Point(12, 26);
            this.sDirButton.Name = "sDirButton";
            this.sDirButton.Size = new System.Drawing.Size(117, 23);
            this.sDirButton.TabIndex = 6;
            this.sDirButton.Text = "Set Server Directory";
            this.sDirButton.UseVisualStyleBackColor = true;
            this.sDirButton.Click += new System.EventHandler(this.sDirButton_Click);
            // 
            // sDirLabel
            // 
            this.sDirLabel.AutoSize = true;
            this.sDirLabel.Location = new System.Drawing.Point(135, 31);
            this.sDirLabel.Name = "sDirLabel";
            this.sDirLabel.Size = new System.Drawing.Size(137, 13);
            this.sDirLabel.TabIndex = 7;
            this.sDirLabel.Text = "No server directory chosen.";
            // 
            // bDirButton
            // 
            this.bDirButton.Location = new System.Drawing.Point(12, 53);
            this.bDirButton.Name = "bDirButton";
            this.bDirButton.Size = new System.Drawing.Size(117, 23);
            this.bDirButton.TabIndex = 8;
            this.bDirButton.Text = "Set Backup Directory";
            this.bDirButton.UseVisualStyleBackColor = true;
            this.bDirButton.Click += new System.EventHandler(this.bDirButton_Click);
            // 
            // bDirLabel
            // 
            this.bDirLabel.AutoSize = true;
            this.bDirLabel.Location = new System.Drawing.Point(135, 58);
            this.bDirLabel.Name = "bDirLabel";
            this.bDirLabel.Size = new System.Drawing.Size(144, 13);
            this.bDirLabel.TabIndex = 9;
            this.bDirLabel.Text = "No backup directory chosen.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Size = new System.Drawing.Size(155, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.startServerToolStripMenuItem,
            this.restartServerToolStripMenuItem,
            this.stopServerToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.fileToolStripMenuItem.Text = "Server";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "Properties...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // startServerToolStripMenuItem
            // 
            this.startServerToolStripMenuItem.Name = "startServerToolStripMenuItem";
            this.startServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startServerToolStripMenuItem.Text = "Start";
            this.startServerToolStripMenuItem.Click += new System.EventHandler(this.startServerToolStripMenuItem_Click);
            // 
            // restartServerToolStripMenuItem
            // 
            this.restartServerToolStripMenuItem.Name = "restartServerToolStripMenuItem";
            this.restartServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartServerToolStripMenuItem.Text = "Restart";
            this.restartServerToolStripMenuItem.Click += new System.EventHandler(this.restartServerToolStripMenuItem_Click);
            // 
            // stopServerToolStripMenuItem
            // 
            this.stopServerToolStripMenuItem.Name = "stopServerToolStripMenuItem";
            this.stopServerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.stopServerToolStripMenuItem.Text = "Stop";
            this.stopServerToolStripMenuItem.Click += new System.EventHandler(this.stopServerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupScheduleToolStripMenuItem,
            this.removeOldBackupsToolStripMenuItem,
            this.forceBackupToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.optionsToolStripMenuItem.Text = "Backup";
            // 
            // backupScheduleToolStripMenuItem
            // 
            this.backupScheduleToolStripMenuItem.Name = "backupScheduleToolStripMenuItem";
            this.backupScheduleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.backupScheduleToolStripMenuItem.Text = "Schedule...";
            this.backupScheduleToolStripMenuItem.Click += new System.EventHandler(this.backupScheduleToolStripMenuItem_Click);
            // 
            // removeOldBackupsToolStripMenuItem
            // 
            this.removeOldBackupsToolStripMenuItem.Name = "removeOldBackupsToolStripMenuItem";
            this.removeOldBackupsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.removeOldBackupsToolStripMenuItem.Text = "Remove Old Backups";
            this.removeOldBackupsToolStripMenuItem.Click += new System.EventHandler(this.removeOldBackupsToolStripMenuItem_Click);
            // 
            // forceBackupToolStripMenuItem
            // 
            this.forceBackupToolStripMenuItem.Name = "forceBackupToolStripMenuItem";
            this.forceBackupToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.forceBackupToolStripMenuItem.Text = "Force Backup";
            this.forceBackupToolStripMenuItem.Click += new System.EventHandler(this.forceBackupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // serverName
            // 
            this.serverName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serverName.ForeColor = System.Drawing.Color.ForestGreen;
            this.serverName.Location = new System.Drawing.Point(526, 7);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(207, 13);
            this.serverName.TabIndex = 12;
            this.serverName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainWindow
            // 
            this.AcceptButton = this.sendCommand;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 512);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.bDirLabel);
            this.Controls.Add(this.bDirButton);
            this.Controls.Add(this.sDirLabel);
            this.Controls.Add(this.sDirButton);
            this.Controls.Add(this.sendCommand);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.serverOutput);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(756, 550);
            this.Name = "MainWindow";
            this.Text = "DevCraft";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox serverOutput;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button sendCommand;
        private System.Windows.Forms.FolderBrowserDialog generalDirBrowser;
        private System.Windows.Forms.Button sDirButton;
        private System.Windows.Forms.Label sDirLabel;
        private System.Windows.Forms.Button bDirButton;
        private System.Windows.Forms.Label bDirLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupScheduleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServerToolStripMenuItem;
        private System.Windows.Forms.Label serverName;
        private System.Windows.Forms.ToolStripMenuItem removeOldBackupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forceBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem startServerToolStripMenuItem;
    }
}

