using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USMTMigration
{
    public partial class SettingsGUI : Form
    {

        public SettingsGUI()
        {
            InitializeComponent();
            BackupLocationText.Text = Properties.Settings.Default.BackupLoc;
            LogLocationText.Text = Properties.Settings.Default.LogLoc;
            ArgumentsText.Text = Properties.Settings.Default.Arguments;
            ComputerNameText.Text = Properties.Settings.Default.ComputerName;
            OverwriteCheckbox.Checked = Properties.Settings.Default.Overwrite;
            LocalUSMTLocationText.Text = Properties.Settings.Default.LocalUSMTLoc;
            RemoteUSMTLocationText.Text = Properties.Settings.Default.RemoteUSMTLoc;
            DomainText.Text = Properties.Settings.Default.Domain;
            MigApp.Checked = Properties.Settings.Default.MigApp;
            MigUser.Checked = Properties.Settings.Default.MigUser;
            MigDocs.Checked = Properties.Settings.Default.MigDocs;

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BackupLoc = BackupLocationText.Text;
            Properties.Settings.Default.LogLoc = LogLocationText.Text;
            Properties.Settings.Default.Arguments = ArgumentsText.Text;
            Properties.Settings.Default.ComputerName = ComputerNameText.Text;
            Properties.Settings.Default.Overwrite = OverwriteCheckbox.Checked;
            Properties.Settings.Default.LocalUSMTLoc = LocalUSMTLocationText.Text;
            Properties.Settings.Default.RemoteUSMTLoc = RemoteUSMTLocationText.Text;
            Properties.Settings.Default.Domain = DomainText.Text;
            Properties.Settings.Default.MigApp = MigApp.Checked;
            Properties.Settings.Default.MigUser = MigUser.Checked;
            Properties.Settings.Default.MigDocs = MigDocs.Checked;

            this.Close();
        }


        //Opens link to Scanstate Syntax
        private void LookUpArgumentsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://technet.microsoft.com/en-us/library/dd560781(v=ws.10).aspx");
        }
    }
}
