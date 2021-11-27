using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Backups.Stuff;
using BackupsExtra.Loger;
using BackupsExtra.Models;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Serial(BackupJobExtra backupJobExtra)
        {
            var binFormater = new BinaryFormatter();

            using (var file = new FileStream("backupJob.bin", FileMode.OpenOrCreate))
            {
                binFormater.Serialize(file, backupJobExtra);
            }
        }

        private static BackupJobExtra Deserial()
        {
            var binFormater = new BinaryFormatter();
            using (var file = new FileStream("backupJob.bin", FileMode.OpenOrCreate))
            {
                var newBackupJob = binFormater.Deserialize(file) as BackupJobExtra;
                return newBackupJob;
            }
        }

        private static void Main()
        {
            BackupLoger.Cons = true;
            BackupLoger.Fl = true;
            BackupLoger.Path = @"D:\BackupLogs\blog.txt";

            var backupJob = new BackupJobExtra("split", "firstJob", "qwerty");

            // BackupJobExtra backupJob = Deserial();
            var objectFile1 = new ObjectFile(@"D:\BackupsStuff\aba.txt");
            var objectFile2 = new ObjectFile(@"D:\BackupsStuff\caba.txt");
            backupJob.JobObject().AddFile(objectFile1);
            backupJob.JobObject().AddFile(objectFile2);
            backupJob.MakeRestorePointExtra();
            backupJob.JobObject().ListFiles.Remove(objectFile1);
            backupJob.MakeRestorePointExtra();
            backupJob.RecoverRestorePoint(0, @"D:\Extracts");
            Console.WriteLine(backupJob.RestorePointsExtra.Count);

            // Serial(backupJob);
           /* backupJob.Merge(backupJob.RestorePointsExtra[0], backupJob.RestorePointsExtra[1]);
            backupJob.RecoverRestorePoint(1, @"D:\Extracts");
            backupJob.DeletRestorePoints(0);*/
        }
    }
}
