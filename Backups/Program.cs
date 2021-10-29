﻿using System.Collections.Generic;
using Backups.Models;
using Backups.Stuff;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var backupJob = new BackupJob("single", "firstJob");
            var objectFile1 = new ObjectFile("test");
            var objectFile2 = new ObjectFile("test2");
            backupJob.JobObject.AddFile(objectFile1);
            backupJob.JobObject.AddFile(objectFile2);
            backupJob.MakeRestorePoint();
            backupJob.JobObject.ListFiles.Remove(objectFile1);
            backupJob.MakeRestorePoint();
            List<RestorePoint> restorePoint = backupJob.RestorePoints;
            int count = 0;
            foreach (RestorePoint restore in restorePoint)
            {
                count += restore.Storage.ObjectFiles.Count;
            }
        }
    }
}
