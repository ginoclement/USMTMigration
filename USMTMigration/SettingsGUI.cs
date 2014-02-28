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
            BackupLocationText.Text = settings.GetBackupLocation();
            LogLocationText.Text = settings.GetLogLocation();
            ArgumentsText.Text = settings.GetArguments();
            ComputerNameText.Text = settings.GetComputerName();
            OverwriteCheckbox.Checked = settings.OverwriteArgument();
            USMTLocationText.Text = settings.GetUSMTLocation();
            DomainText.Text = settings.GetDomain();
            OlderThan.Value = settings.GetDate();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            settings.SetBackupLocation(BackupLocationText.Text);
            settings.SetLogLocation(LogLocationText.Text);
            settings.SetArguments(ArgumentsText.Text);
            settings.SetComputerName(ComputerNameText.Text);
            settings.SetOverwriteArgument(OverwriteCheckbox.Checked);
            settings.SetUSMTLocation(USMTLocationText.Text);
            settings.SetDomain(DomainText.Text);
            settings.SetDate((uint) OlderThan.Value);

            this.Close();
        }


        //Opens link to Scanstate Syntax
        private void LookUpArgumentsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://technet.microsoft.com/en-us/library/dd560781(v=ws.10).aspx");
        }
    }
}
