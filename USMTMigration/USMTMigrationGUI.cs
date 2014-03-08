using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace USMTMigration
{
    public partial class USMTMigrationGUI : Form
    {
        private Settings settings;
        private bool isBackup;

        public USMTMigrationGUI()
        {
            InitializeComponent();
            settings = new Settings();
            TransferButton.Enabled = ArgumentsButton.Enabled = false;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsGUI settingsGUI = new SettingsGUI(this.settings);
            settingsGUI.Show();

        }

        private void Backup_Click(object sender, EventArgs e)
        {
            BackupButton.Enabled = false;
            RestoreButton.Enabled = true;
            ProfilesList.Items.Clear();
            ProfilesList.Visible = true;
            RestoreComputerLabel.Visible = false;
            RestoreComputerText.Visible = false;

            string profilesPath = "C:\\Users\\";
            foreach(string profile in Directory.GetDirectories(profilesPath)){
                string temp = profile.Replace(profilesPath, "");
                if (!temp.Equals("All Users") && !temp.Contains("Default") && !temp.Equals("Public"))
                {
                    ProfilesList.Items.Add(temp);
                    ProfilesList.SetItemChecked(ProfilesList.Items.Count - 1, true);
                }
            }

            TransferButton.Enabled = ArgumentsButton.Enabled = true;
            isBackup = true;
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            BackupButton.Enabled = true;
            RestoreButton.Enabled = false;
            ProfilesList.Visible = false;
            RestoreComputerLabel.Visible = true;
            RestoreComputerText.Visible = true;

            //List all files in the backup location

            TransferButton.Enabled = ArgumentsButton.Enabled = true;
            isBackup = false;
        }

        //Select all buttons in the profile list
        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProfilesList.Items.Count; i++)
            {
                ProfilesList.SetItemChecked(i, true);
            }
        }

        //Unselect all buttons in the profile list
        private void UnselectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProfilesList.Items.Count; i++)
            {
                ProfilesList.SetItemChecked(i, false);
            }
        }

        private string GetArguments()
        {
            //string arguments = (isBackup) ? settings.GetBackupLocation() + ((settings.OverwriteArgument()) ? " /o" : "") : "";
            string arguments = "";
            if(isBackup){
                arguments += settings.backupLocation;

                //God this is ugly
                //arguments += (settings.OverwriteArgument()) ? " /o" : "";
                //arguments += (settings.GetDate() > 0) ? " /uel:" + settings.GetDate() : ""; 

                //Or should I use this
                if (settings.overwrite)
                {
                    arguments += " /o";
                }
                if(settings.profilesOlderThan > 0)
                {
                    arguments += " /uel:" + settings.profilesOlderThan;
                }

                foreach (string profile in ProfilesList.CheckedItems)
                {
                    // /ui:farwest\user2
                    string temp = profile.Replace("C:\\Users\\", "");
                    arguments += " /ui:" + settings.domain + "\\" + temp;
                }
            }
            else
            {
                arguments += settings.backupLocation + RestoreComputerText.Text;
                arguments += " /all";
            }
            arguments += " " + settings.arguments;
            arguments += " /l:" + settings.logLocation + settings.computerName + ((isBackup) ? "_scan.log" : "_load.log");



            //Debug
            System.Diagnostics.Debug.WriteLine(arguments);

            return arguments;
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            Transfer();
        }

        private void Transfer()
        {
            USMTExists();
            Process migration = new Process();
            migration.StartInfo.UseShellExecute = true;
            migration.StartInfo.RedirectStandardOutput = false;
            migration.StartInfo.FileName = settings.localUSMTLocation + ((isBackup) ? "\\scanstate.bat" : "\\loadstate.bat");
            migration.StartInfo.Arguments = GetArguments();

            //Show what's executed
            //MessageBox.Show(migration.StartInfo.FileName);
            migration.Start();
            //string output = migration.StandardOutput.ReadLine();
            //MessageBox.Show(output);
            //Close the program
            migration.WaitForExit();
            this.Close();

        }

        //Show command to be executed when transfer is clicked
        private void ArgumentsButton_Click(object sender, EventArgs e)
        {
            string text = settings.localUSMTLocation + ((isBackup) ? "\\scanstate.exe " : "\\loadstate.exe ") + GetArguments();
            MessageBox.Show(text);
        }

        //Check to see if USMT files are present on the local machine in the designated folder, otherwise copy them
        private void USMTExists()
        {
            if (!Directory.Exists(settings.localUSMTLocation))
            {
                string[] files = System.IO.Directory.GetFiles(settings.remoteUSMTLocation);

                // Copy the files and overwrite destination files if they already exist. 
                foreach (string s in files)
                {
                      //Use static Path methods to extract only the file name from the path.
                      String fileName = System.IO.Path.GetFileName(s);
                      String destFile = System.IO.Path.Combine(settings.localUSMTLocation, fileName);
                      System.IO.File.Copy(s, destFile, true);
                }
                
            }
        }
    }
}
