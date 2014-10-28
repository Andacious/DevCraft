namespace DevCraft.UI.Forms
{
    partial class BackupScheduleWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupScheduleWindow));
            this.okButton = new System.Windows.Forms.Button();
            this.txtCustomInterval = new System.Windows.Forms.TextBox();
            this.ddCustomInterval = new System.Windows.Forms.ComboBox();
            this.lblErrorLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblCustomInterval = new System.Windows.Forms.Label();
            this.ddFrequency = new System.Windows.Forms.ComboBox();
            this.ddDay = new System.Windows.Forms.ComboBox();
            this.chkDisplayBackupStatus = new System.Windows.Forms.CheckBox();
            this.pkrTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(310, 209);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // txtCustomInterval
            // 
            this.txtCustomInterval.Location = new System.Drawing.Point(264, 137);
            this.txtCustomInterval.Name = "txtCustomInterval";
            this.txtCustomInterval.Size = new System.Drawing.Size(52, 20);
            this.txtCustomInterval.TabIndex = 1;
            // 
            // ddCustomInterval
            // 
            this.ddCustomInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddCustomInterval.FormattingEnabled = true;
            this.ddCustomInterval.Location = new System.Drawing.Point(322, 137);
            this.ddCustomInterval.Name = "ddCustomInterval";
            this.ddCustomInterval.Size = new System.Drawing.Size(63, 21);
            this.ddCustomInterval.TabIndex = 3;
            // 
            // lblErrorLabel
            // 
            this.lblErrorLabel.AutoSize = true;
            this.lblErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.lblErrorLabel.Location = new System.Drawing.Point(25, 214);
            this.lblErrorLabel.Name = "lblErrorLabel";
            this.lblErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.lblErrorLabel.TabIndex = 5;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(229, 209);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Location = new System.Drawing.Point(25, 23);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(60, 13);
            this.lblFrequency.TabIndex = 7;
            this.lblFrequency.Text = "Frequency:";
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(26, 62);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(29, 13);
            this.lblDay.TabIndex = 8;
            this.lblDay.Text = "Day:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(26, 102);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "Time:";
            // 
            // lblCustomInterval
            // 
            this.lblCustomInterval.AutoSize = true;
            this.lblCustomInterval.Location = new System.Drawing.Point(25, 140);
            this.lblCustomInterval.Name = "lblCustomInterval";
            this.lblCustomInterval.Size = new System.Drawing.Size(83, 13);
            this.lblCustomInterval.TabIndex = 10;
            this.lblCustomInterval.Text = "Custom Interval:";
            // 
            // ddFrequency
            // 
            this.ddFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddFrequency.FormattingEnabled = true;
            this.ddFrequency.Location = new System.Drawing.Point(264, 20);
            this.ddFrequency.Name = "ddFrequency";
            this.ddFrequency.Size = new System.Drawing.Size(121, 21);
            this.ddFrequency.TabIndex = 11;
            this.ddFrequency.SelectedIndexChanged += new System.EventHandler(this.ddFrequency_SelectedIndexChanged);
            // 
            // ddDay
            // 
            this.ddDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddDay.FormattingEnabled = true;
            this.ddDay.Location = new System.Drawing.Point(264, 59);
            this.ddDay.Name = "ddDay";
            this.ddDay.Size = new System.Drawing.Size(121, 21);
            this.ddDay.TabIndex = 12;
            // 
            // chkDisplayBackupStatus
            // 
            this.chkDisplayBackupStatus.AutoSize = true;
            this.chkDisplayBackupStatus.Location = new System.Drawing.Point(28, 174);
            this.chkDisplayBackupStatus.Name = "chkDisplayBackupStatus";
            this.chkDisplayBackupStatus.Size = new System.Drawing.Size(178, 17);
            this.chkDisplayBackupStatus.TabIndex = 17;
            this.chkDisplayBackupStatus.Text = "Display backup status to players";
            this.chkDisplayBackupStatus.UseVisualStyleBackColor = true;
            // 
            // pkrTime
            // 
            this.pkrTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.pkrTime.Location = new System.Drawing.Point(264, 98);
            this.pkrTime.Name = "pkrTime";
            this.pkrTime.ShowUpDown = true;
            this.pkrTime.Size = new System.Drawing.Size(121, 20);
            this.pkrTime.TabIndex = 18;
            // 
            // BackupScheduleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 250);
            this.Controls.Add(this.pkrTime);
            this.Controls.Add(this.chkDisplayBackupStatus);
            this.Controls.Add(this.ddDay);
            this.Controls.Add(this.ddFrequency);
            this.Controls.Add(this.lblCustomInterval);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.lblErrorLabel);
            this.Controls.Add(this.ddCustomInterval);
            this.Controls.Add(this.txtCustomInterval);
            this.Controls.Add(this.okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackupScheduleWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Backup Schedule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox txtCustomInterval;
        private System.Windows.Forms.ComboBox ddCustomInterval;
        private System.Windows.Forms.Label lblErrorLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCustomInterval;
        private System.Windows.Forms.ComboBox ddFrequency;
        private System.Windows.Forms.ComboBox ddDay;
        private System.Windows.Forms.CheckBox chkDisplayBackupStatus;
        private System.Windows.Forms.DateTimePicker pkrTime;
    }
}