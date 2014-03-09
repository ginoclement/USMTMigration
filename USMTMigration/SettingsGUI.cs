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
        private Settings settings;

        public SettingsGUI(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;

            //Initialize textbox values
            BackupLocationText.Text = settings.backupLocation;
            LogLocationText.Text = settings.logLocation;
            ArgumentsText.Text = settings.arguments;
            ComputerNameText.Text = settings.computerName;
            OverwriteCheckbox.Checked = settings.overwrite;
            LocalUSMTLocationText.Text = settings.localUSMTLocation;
            RemoteUSMTLocationText.Text = settings.remoteUSMTLocation;
            DomainText.Text = settings.domain;
            OlderThan.Value = settings.profilesOlderThan;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            settings.backupLocation = BackupLocationText.Text;
            settings.logLocation = LogLocationText.Text;
            settings.arguments = ArgumentsText.Text;
            settings.computerName = ComputerNameText.Text;
            settings.overwrite = OverwriteCheckbox.Checked;
            settings.localUSMTLocation = LocalUSMTLocationText.Text;
            settings.remoteUSMTLocation = RemoteUSMTLocationText.Text;
            settings.domain = DomainText.Text;
            settings.profilesOlderThan = (uint) OlderThan.Value;

            this.Close();
        }


        //Opens link to Scanstate Syntax
        private void LookUpArgumentsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://technet.microsoft.com/en-us/library/dd560781(v=ws.10).aspx");
        }
    }
}
