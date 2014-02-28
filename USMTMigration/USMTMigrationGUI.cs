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
                arguments += settings.GetBackupLocation();

                //God this is ugly
                //arguments += (settings.OverwriteArgument()) ? " /o" : "";
                //arguments += (settings.GetDate() > 0) ? " /uel:" + settings.GetDate() : ""; 

                //Or should I use this
                if (settings.OverwriteArgument())
                {
                    arguments += " /o";
                }
                if(settings.GetDate() > 0)
                {
                    arguments += " /uel:" + settings.GetDate();
                }

                foreach (string profile in ProfilesList.CheckedItems)
                {
                    // /ui:farwest\user2
                    string temp = profile.Replace("C:\\Users\\", "");
                    arguments += " /ui:" + settings.GetDomain() + "\\" + temp;
                }
            }
            else
            {
                arguments += settings.GetBackupLocation() + RestoreComputerText.Text;
                arguments += " /all";
            }
            arguments += " " + settings.GetArguments();
            arguments += " /l:" + settings.GetLogLocation() + settings.GetComputerName() + ((isBackup) ? "_scan.log" : "_load.log");



            //Debug
            System.Diagnostics.Debug.WriteLine(arguments);

            return arguments;
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            Transfer();
                //if (isBackup)
                //{
                //    Backup();
                //}
                //else
                //{
                //    Restore();
                //}
        }

        private void Transfer()
        {
            /*
                 // Start the child process.
                 Process p = new Process();
                 // Redirect the output stream of the child process.
                 p.StartInfo.UseShellExecute = false;
                 p.StartInfo.RedirectStandardOutput = true;
                 p.StartInfo.FileName = "YOURBATCHFILE.bat";
                 p.Start();
                 // Do not wait for the child process to exit before
                 // reading to the end of its redirected stream.
                 // p.WaitForExit();
                 // Read the output stream first and then wait.
                 string output = p.StandardOutput.ReadToEnd();
                 p.WaitForExit();
              
             You can add arguments to your call through the {YourProcessObject}.StartInfo.Arguments 
            */
            Process migration = new Process();
            migration.StartInfo.UseShellExecute = false;
            migration.StartInfo.RedirectStandardOutput = true;
            migration.StartInfo.FileName = settings.GetUSMTLocation() + ((isBackup) ? "scanstate.exe" : "loadstate.exe");
            migration.StartInfo.Arguments = GetArguments();

            //Show what's executed
            MessageBox.Show(migration.StartInfo.ToString());

            migration.Start();
            string output = migration.StandardOutput.ReadToEnd();
            migration.WaitForExit();

        }

        //private void Backup()
        //{
        //    //Execute Scanstate
        //}

        //private void Restore()
        //{
        //    //Execute Loadstate
        //}

        //Show command to be executed when transfer is clicked
        private void ArgumentsButton_Click(object sender, EventArgs e)
        {
            string text = settings.GetUSMTLocation() + ((isBackup) ? "\\scanstate.exe " : "\\loadstate.exe ") + GetArguments();
            MessageBox.Show(text);
        }



    }
}
