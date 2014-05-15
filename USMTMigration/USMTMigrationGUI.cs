﻿using System;
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
                arguments += Properties.Settings.Default.BackupLoc + "\\";

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
            arguments += " /l:\"" + Properties.Settings.Default.LogLoc + "\\" + Properties.Settings.Default.ComputerName + ((isBackup) ? "_scan.log" : "_load.log") + "\"";



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
            //Check for USMT tools
            USMTExists();


            string command = "\"" + Properties.Settings.Default.LocalUSMTLoc + "\\USMT\\amd64" + ((isBackup) ? "\\scanstate.exe" : "\\loadstate.exe") + "\" " + GetArguments();
            Console.WriteLine("Command: " + command);
            //System.Diagnostics.Process.Start("CMD.exe", command);
            //this.Close();

            Process migration = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + command + " & pause";
            migration.StartInfo = startInfo;
            migration.Start();
            //This is supposed to execute Windows Logout
            //ExitWindowsEx(0, 0);

        }
        //Show command to be executed when transfer is clicked
        private void ArgumentsButton_Click(object sender, EventArgs e)
        {
            string text = Properties.Settings.Default.LocalUSMTLoc + ((isBackup) ? "\\scanstate.exe " : "\\loadstate.exe ") + GetArguments();
            MessageBox.Show(text);
        }

        //Check to see if USMT files are present on the local machine in the designated folder,
        //otherwise copy them. Throws DirectoryNotFoundException if files are not found locally
        //and not found at the remote location.
        private void USMTExists()
        {
            DirectoryInfo source = new DirectoryInfo(Properties.Settings.Default.LocalUSMTLoc);
            DirectoryInfo target = new DirectoryInfo(Properties.Settings.Default.RemoteUSMTLoc);

            //Check to see if the target directory exists
            Console.WriteLine("Checking for USMT tools...");
            if (!source.Exists)
            {
                //Create directory
                Console.WriteLine("Local USMT directory does not exist, creating...");
                Directory.CreateDirectory(Properties.Settings.Default.LocalUSMTLoc);
                
                //If the source directory doesn't exist, throw an exception
                if (!Directory.Exists(Properties.Settings.Default.RemoteUSMTLoc))
                {
                    throw new DirectoryNotFoundException("Source directory does not exist: " + Properties.Settings.Default.RemoteUSMTLoc);
                }

                //Copy USMT files
                Console.WriteLine("Copying USMT files...");
                CopyDirectory(Properties.Settings.Default.RemoteUSMTLoc, Properties.Settings.Default.LocalUSMTLoc);
            }
            else
            {
                Console.WriteLine("USMT files are present on this computer.");
            }
        }

        //Copy the files in the directory as well as any subdirectories
        private void CopyDirectory(String sourcepath, String targetpath)
        {
            DirectoryInfo source = new DirectoryInfo(sourcepath);

            //Copy all files at the source + path
            foreach(FileInfo file in source.GetFiles()){
                Console.WriteLine(file.FullName);
                
                file.CopyTo(targetpath + "\\" + file.Name);
            }
            //Get all directories at the source + path
            foreach(DirectoryInfo dir in source.GetDirectories())
            {
                //Create the directory at the destination + path
                Directory.CreateDirectory(targetpath + "\\" + dir.Name);
                //Recurse with destination + path as the new path
                CopyDirectory(dir.FullName, targetpath + "\\" + dir.Name);
            }
        }
    }
}
