using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USMTMigration
{
    public class Settings
    {
        private string backupLocation;
        private string logLocation;

        public Settings()
        {
            this.backupLocation = "C:\\Fake\\Backup\\Location\\";
            this.logLocation = "C:\\Fake\\Log\\Location\\";
        }

        public string getBackupLocation()
        {
            return backupLocation;
        }

        public string getLogLocation()
        {
            return logLocation;
        }

        public void setBackupLocation(string newLocation)
        {
            backupLocation = newLocation;
        }

        public void setLogLocation(string newLocation)
        {
            logLocation = newLocation;
        }
    }
}
