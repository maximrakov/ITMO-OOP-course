using Backups.Models;
using Backups.Stuff;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var backupJob = new BackupJob("split", "firstJob", "qwerty");
            var objectFile1 = new ObjectFile(@"D:\BackupsStuff\aba.txt");
            var objectFile2 = new ObjectFile(@"D:\BackupsStuff\caba.txt");
            backupJob.JobObject.AddFile(objectFile1);
            backupJob.JobObject.AddFile(objectFile2);
            backupJob.MakeRestorePoint();
            backupJob.JobObject.ListFiles.Remove(objectFile1);
            backupJob.MakeRestorePoint();
        }
    }
}
