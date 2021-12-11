using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Backups.Models;
using Backups.Stuff;
namespace Backups.Tests
{
    public class Tests
    {
       /* [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void CreateBuckupsAndCheckPointsAndStorages()
        {
            BackupJob backupJob = new BackupJob("split", "firstJob");
            ObjectFile objectFile1 = new ObjectFile("test");
            ObjectFile objectFile2 = new ObjectFile("test2");
            backupJob.JobObject.AddFile(objectFile1);
            backupJob.JobObject.AddFile(objectFile2);
            backupJob.MakeRestorePoint();
            backupJob.JobObject.ListFiles.Remove(objectFile1);
            backupJob.MakeRestorePoint();
            Assert.AreEqual(backupJob.RestorePoints.Count, 2);
            List<RestorePoint> restorePoint = backupJob.RestorePoints;
            int count = 0;
            foreach (RestorePoint restore in restorePoint)
            {
                count += restore.Storage.ObjectFiles.Count;
            }
            Assert.AreEqual(count, 3);
        }*/
    }
}
