using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace USMTMigration
{
    public partial class USMTMigrationGUI : Form
    {
        private bool isBackup;

        //Log out method... I don't know if this works.
        //[DllImport("user32")]
        //public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        public USMTMigrationGUI()
        {
            InitializeComponent();
            TransferButton.Enabled = ArgumentsButton.Enabled = false;
            USMTExists();
            Properties.Settings.Default.ComputerName = System.Environment.MachineName;
            Properties.Settings.Default.Domain = Environment.UserDomainName;
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsGUI settingsGUI = new SettingsGUI();
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
            //Lolz gotta love ternary operators
            //string arguments = (isBackup) ? settings.GetBackupLocation() + ((settings.OverwriteArgument()) ? " /o" : "") : "";
            string arguments = "";
            if(isBackup){
                arguments += Properties.Settings.Default.BackupLoc;

                //God this is ugly
                //arguments += (settings.OverwriteArgument()) ? " /o" : "";
                //arguments += (settings.GetDate() > 0) ? " /uel:" + settings.GetDate() : ""; 
                
                //Or should I use this
                if (Properties.Settings.Default.Overwrite)
                {
                    arguments += " /o";
                }
                if (Properties.Settings.Default.DaysToSave > 0)
                {
                    arguments += " /uel:" + Properties.Settings.Default.DaysToSave;
                }

                foreach (string profile in ProfilesList.CheckedItems)
                {
                    // /ui:farwest\user2
                    string temp = profile.Replace("C:\\Users\\", "");
                    arguments += " /ui:" + Properties.Settings.Default.Domain + "\\" + temp;
                }
            }
            else
            {
                arguments += Properties.Settings.Default.BackupLoc + RestoreComputerText.Text;
                arguments += " /all";
            }
            arguments += " " + Properties.Settings.Default.Arguments;
            arguments += " /l:" + Properties.Settings.Default.LogLoc + Properties.Settings.Default.ComputerName + ((isBackup) ? "_scan.log" : "_load.log");



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
            Process migration = new Process();
            migration.StartInfo.UseShellExecute = true;
            migration.StartInfo.RedirectStandardOutput = false;
            migration.StartInfo.FileName = Properties.Settings.Default.LocalUSMTLoc + ((isBackup) ? "\\scanstate.bat" : "\\loadstate.bat");
            migration.StartInfo.Arguments = GetArguments();

            migration.Start();
            //string output = migration.StandardOutput.ReadLine();
            //Close the program
            migration.WaitForExit();
            this.Close();

            //This is supposed to execute Windows Logout
            //ExitWindowsEx(0, 0);

        }
        //Show command to be executed when transfer is clicked
        private void ArgumentsButton_Click(object sender, EventArgs e)
        {
            string text = Properties.Settings.Default.LocalUSMTLoc + ((isBackup) ? "\\scanstate.exe " : "\\loadstate.exe ") + GetArguments();
            MessageBox.Show(text);
        }

        //Check to see if USMT files are present on the local machine in the designated folder, otherwise copy them
        private void USMTExists()
        {
            if (!Directory.Exists(Properties.Settings.Default.LocalUSMTLoc))
            {
                Console.WriteLine("USMT files not found, copying...");
                string[] files = System.IO.Directory.GetFiles(Properties.Settings.Default.RemoteUSMTLoc);
                // Copy the files and overwrite destination files if they already exist. 
                foreach (string s in files)
                {
                      //Use static Path methods to extract only the file name from the path.
                      String fileName = System.IO.Path.GetFileName(s);
                      String destFile = System.IO.Path.Combine(Properties.Settings.Default.LocalUSMTLoc, fileName);
                      System.IO.File.Copy(s, destFile, true);
                }

            }
            else
            {
                Console.WriteLine("USMT files already exist.");
            }
        }





    }
}
