using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USMTMigration
{
    public class Settings
    {
        public string backupLocation;
        public string logLocation;
        public string arguments;
        public string computerName;
        public bool overwrite;
        public string domain;
        public uint profilesOlderThan;
        public string localUSMTLocation;
        public string remoteUSMTLocation;

        public Settings()
        {
            //Create a data structure with all settings, check if a settings exists, otherwise use default
            if (File.Exists("options.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("options.txt");
            }
            else
            {
                this.backupLocation = "C:\\Fake\\Backup\\Location\\";
                this.logLocation = "C:\\Fake\\Log\\Location\\";
                this.arguments = "/i:migapp.xml /i:miguser.xml /v:13 /c";
                this.computerName = System.Environment.MachineName;
                this.overwrite = true;
                this.localUSMTLocation = "C:\\"; //"C:\\Users\\Gino Clement\\Desktop"; //Directory.GetCurrentDirectory();
                this.remoteUSMTLocation = "C:\\Users\\Gino Clement\\Desktop\\SomeRemoteLocation";
                this.domain = "DOMAIN";
            }
        }

    }
}
