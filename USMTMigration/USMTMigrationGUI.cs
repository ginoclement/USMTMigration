using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public USMTMigrationGUI()
        {
            InitializeComponent();
            settings = new Settings();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            SettingsGUI settingsGUI = new SettingsGUI(this.settings);
            settingsGUI.Show();
        }

        private void Backup_Click(object sender, EventArgs e)
        {
            //File users = new File();
            string profilesPath = "C:\\Users\\";
            //Console.Write(Directory.GetDirectories(profilesPath)[1]);
            //System.Diagnostics.Debug.WriteLine(Directory.GetDirectories(profilesPath).ToString());
            foreach(string profile in Directory.GetDirectories(profilesPath)){
                ProfilesList.Items.Add(profile);
            }
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProfilesList.Items.Count; i++ )
            {
                ProfilesList.SetItemChecked(i, true);
            }
        }

        private void UnselectAllButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ProfilesList.Items.Count; i++)
            {
                ProfilesList.SetItemChecked(i, false);
            }
        }

        //private void load

    }
}
