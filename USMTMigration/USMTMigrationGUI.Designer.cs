namespace USMTMigration
{
    partial class USMTMigrationGUI
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
            this.BackupButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.ProfilesList = new System.Windows.Forms.CheckedListBox();
            this.Settings = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.UnselectAllButton = new System.Windows.Forms.Button();
            this.TransferButton = new System.Windows.Forms.Button();
            this.ArgumentsButton = new System.Windows.Forms.Button();
            this.RestoreComputerLabel = new System.Windows.Forms.Label();
            this.RestoreComputerText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BackupButton
            // 
            this.BackupButton.Location = new System.Drawing.Point(13, 43);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(75, 23);
            this.BackupButton.TabIndex = 0;
            this.BackupButton.Text = "Backup";
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.Backup_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Location = new System.Drawing.Point(12, 72);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(75, 23);
            this.RestoreButton.TabIndex = 1;
            this.RestoreButton.Text = "Restore";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Click += new System.EventHandler(this.Restore_Click);
            // 
            // ProfilesList
            // 
            this.ProfilesList.FormattingEnabled = true;
            this.ProfilesList.Location = new System.Drawing.Point(94, 13);
            this.ProfilesList.Name = "ProfilesList";
            this.ProfilesList.ScrollAlwaysVisible = true;
            this.ProfilesList.Size = new System.Drawing.Size(297, 229);
            this.ProfilesList.TabIndex = 2;
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(12, 101);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(75, 23);
            this.Settings.TabIndex = 3;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(398, 43);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(75, 23);
            this.SelectAllButton.TabIndex = 4;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // UnselectAllButton
            // 
            this.UnselectAllButton.Location = new System.Drawing.Point(398, 72);
            this.UnselectAllButton.Name = "UnselectAllButton";
            this.UnselectAllButton.Size = new System.Drawing.Size(75, 23);
            this.UnselectAllButton.TabIndex = 5;
            this.UnselectAllButton.Text = "Unselect All";
            this.UnselectAllButton.UseVisualStyleBackColor = true;
            this.UnselectAllButton.Click += new System.EventHandler(this.UnselectAllButton_Click);
            // 
            // TransferButton
            // 
            this.TransferButton.Location = new System.Drawing.Point(398, 219);
            this.TransferButton.Name = "TransferButton";
            this.TransferButton.Size = new System.Drawing.Size(75, 23);
            this.TransferButton.TabIndex = 6;
            this.TransferButton.Text = "Transfer";
            this.TransferButton.UseVisualStyleBackColor = true;
            this.TransferButton.Click += new System.EventHandler(this.TransferButton_Click);
            // 
            // ArgumentsButton
            // 
            this.ArgumentsButton.Location = new System.Drawing.Point(398, 190);
            this.ArgumentsButton.Name = "ArgumentsButton";
            this.ArgumentsButton.Size = new System.Drawing.Size(75, 23);
            this.ArgumentsButton.TabIndex = 9;
            this.ArgumentsButton.Text = "Arguments";
            this.ArgumentsButton.UseVisualStyleBackColor = true;
            this.ArgumentsButton.Click += new System.EventHandler(this.ArgumentsButton_Click);
            // 
            // RestoreComputerLabel
            // 
            this.RestoreComputerLabel.AutoSize = true;
            this.RestoreComputerLabel.Location = new System.Drawing.Point(95, 43);
            this.RestoreComputerLabel.Name = "RestoreComputerLabel";
            this.RestoreComputerLabel.Size = new System.Drawing.Size(131, 13);
            this.RestoreComputerLabel.TabIndex = 10;
            this.RestoreComputerLabel.Text = "Computer name to restore:";
            this.RestoreComputerLabel.Visible = false;
            // 
            // RestoreComputerText
            // 
            this.RestoreComputerText.Location = new System.Drawing.Point(95, 60);
            this.RestoreComputerText.Name = "RestoreComputerText";
            this.RestoreComputerText.Size = new System.Drawing.Size(296, 20);
            this.RestoreComputerText.TabIndex = 11;
            this.RestoreComputerText.Visible = false;
            // 
            // USMTMigrationGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.RestoreComputerText);
            this.Controls.Add(this.RestoreComputerLabel);
            this.Controls.Add(this.ArgumentsButton);
            this.Controls.Add(this.TransferButton);
            this.Controls.Add(this.UnselectAllButton);
            this.Controls.Add(this.SelectAllButton);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.ProfilesList);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.BackupButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "USMTMigrationGUI";
            this.Text = "USMT Migration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackupButton;
        private System.Windows.Forms.Button RestoreButton;
        private System.Windows.Forms.CheckedListBox ProfilesList;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button UnselectAllButton;
        private System.Windows.Forms.Button TransferButton;
        private System.Windows.Forms.Button ArgumentsButton;
        private System.Windows.Forms.Label RestoreComputerLabel;
        private System.Windows.Forms.TextBox RestoreComputerText;
    }
}

