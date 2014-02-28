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
        private string backupLocation;
        private string logLocation;
        private string arguments;
        private string computerName;
        private bool overwrite;
        private string usmtLocation;
        private string domain;
        private uint olderThan;

        public Settings()
        {
            this.backupLocation = "C:\\Fake\\Backup\\Location\\";
            this.logLocation = "C:\\Fake\\Log\\Location\\";
            this.arguments = "/i:migapp.xml /i:miguser.xml /v:13 /c";
            this.computerName = System.Environment.MachineName;
            this.overwrite = true;
            this.usmtLocation = Directory.GetCurrentDirectory();
            this.domain = "DOMAIN";
        }


        //Get methods

        public string GetArguments()
        {
            return arguments;
        }

        public string GetBackupLocation()
        {
            return backupLocation;
        }

        public string GetComputerName()
        {
            return computerName;
        }

        public uint GetDate()
        {
            return (olderThan == null) ? 0 : olderThan;
        }

        public string GetDomain()
        {
            return domain;
        }

        public string GetLogLocation()
        {
            return logLocation;
        }

        public string GetUSMTLocation()
        {
            return usmtLocation;
        }

        public bool OverwriteArgument()
        {
            return overwrite;
        }

        //Set methods
        
        public void SetArguments(string args)
        {
            arguments = args;
        }

        public void SetBackupLocation(string newLocation)
        {
            backupLocation = newLocation;
        }

        public void SetComputerName(string name)
        {
            computerName = name;
        }

        public void SetDate(uint newDate)
        {
            olderThan = newDate;
        }

        public void SetDomain(string newDomain)
        {
            domain = newDomain;
        }

        public void SetLogLocation(string newLocation)
        {
            logLocation = newLocation;
        }

        public void SetOverwriteArgument(bool status)
        {
            overwrite = status;
        }

        public void SetUSMTLocation(string location)
        {
            usmtLocation = location;
        }
    }
}
