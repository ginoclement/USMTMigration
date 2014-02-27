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
            this.Backup = new System.Windows.Forms.Button();
            this.Restore = new System.Windows.Forms.Button();
            this.ProfilesList = new System.Windows.Forms.CheckedListBox();
            this.Settings = new System.Windows.Forms.Button();
            this.SelectAllButton = new System.Windows.Forms.Button();
            this.UnselectAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Backup
            // 
            this.Backup.Location = new System.Drawing.Point(13, 13);
            this.Backup.Name = "Backup";
            this.Backup.Size = new System.Drawing.Size(75, 23);
            this.Backup.TabIndex = 0;
            this.Backup.Text = "Backup";
            this.Backup.UseVisualStyleBackColor = true;
            this.Backup.Click += new System.EventHandler(this.Backup_Click);
            // 
            // Restore
            // 
            this.Restore.Location = new System.Drawing.Point(13, 43);
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(75, 23);
            this.Restore.TabIndex = 1;
            this.Restore.Text = "Restore";
            this.Restore.UseVisualStyleBackColor = true;
            // 
            // ProfilesList
            // 
            this.ProfilesList.FormattingEnabled = true;
            this.ProfilesList.Location = new System.Drawing.Point(94, 13);
            this.ProfilesList.Name = "ProfilesList";
            this.ProfilesList.Size = new System.Drawing.Size(297, 229);
            this.ProfilesList.TabIndex = 2;
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(397, 13);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(75, 23);
            this.Settings.TabIndex = 3;
            this.Settings.Text = "Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Location = new System.Drawing.Point(398, 72);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(75, 23);
            this.SelectAllButton.TabIndex = 4;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.UseVisualStyleBackColor = true;
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // UnselectAllButton
            // 
            this.UnselectAllButton.Location = new System.Drawing.Point(398, 102);
            this.UnselectAllButton.Name = "UnselectAllButton";
            this.UnselectAllButton.Size = new System.Drawing.Size(75, 23);
            this.UnselectAllButton.TabIndex = 5;
            this.UnselectAllButton.Text = "Unselect All";
            this.UnselectAllButton.UseVisualStyleBackColor = true;
            this.UnselectAllButton.Click += new System.EventHandler(this.UnselectAllButton_Click);
            // 
            // USMTMigrationGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.UnselectAllButton);
            this.Controls.Add(this.SelectAllButton);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.ProfilesList);
            this.Controls.Add(this.Restore);
            this.Controls.Add(this.Backup);
            this.Name = "USMTMigrationGUI";
            this.Text = "USMT Migration";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Backup;
        private System.Windows.Forms.Button Restore;
        private System.Windows.Forms.CheckedListBox ProfilesList;
        private System.Windows.Forms.Button Settings;
        private System.Windows.Forms.Button SelectAllButton;
        private System.Windows.Forms.Button UnselectAllButton;
    }
}

