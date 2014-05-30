USMTMigration
=============

Description
============
This is a graphical user interface to accompany the user state migration toolkit (USMT) provided by Microsoft. It allows for backing up of user profiles to a local folder or network location and restoring from a location.

Set defaults
=============
In order to set the default settings for the application you need to modify the USMTMigration.exe.config file. Go to <usersettings> and set the value each <setting> in <value>

Here are a list of the settings followed by what they are. I really shouldn't have to do this, it's pretty straightforward but just in case here you go.

BackupLocation: Where the USMT backups will be saved to/restored from
LogLocation: Where to store the USMT logs
Arguments: Any additional arguments to pass to USMT that aren't configured within settings
ComputerName: This shouldn't be set, it gets populated automatically with the name of the computer the program ran on
Overwrite: Whether to overwrite older backups
LocalUSMTLocation: Where to copy the USMT files to on the computer
RemoteUSMTLocation: Where to get the USMT files if they aren't already in LocalUSMTLocation
Domain: This shouldn't be set, it gets populated automatically with the domain of the user currently logged in
MigApp: Whether to use MigApp.xml
MigUser: Whether to use MigUser.xml
MigDocs: Whether to use MigDocs.xml

Use
============
Use of the application is fairly simple. Run USMTMigration.exe and enter administrator credentials (required for USMT scripts). If you want to backup profiles, click backup and check any profiles you wish to back up, otherwise click restore and select which backup to restore (backups are based on computer name).

Notes
============
-You can get the USMT files from Windows Assessment and Deployment Kit (Windows ADK) which can be downloaded for free off Microsofts website. All you need is all the files in the folder containing scanstate.exe and loadstate.exe.

-The USMT files (you know, the ones mentioned in the last note), should be the only thing in RemoteUSMTLocation. The program is specifically looking for scanstate.exe and loadstate.exe in that location, it does not check subdirectories.

-If the command prompt flashes, check for a log. If a log was not created, there was most likely an error in the syntax passed to scanstate.exe or loadstate.exe

-If you run into any bugs or find any ways to make things better, please let me know!