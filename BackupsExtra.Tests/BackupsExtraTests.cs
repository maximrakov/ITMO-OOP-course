using Backups.Stuff;
using BackupsExtra.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackupsExtra.Tests
{
    public class Tests
    {
        /*private BackupJobExtra backupJob;
        private ObjectFile objectFile1;
        private ObjectFile objectFile2;
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void ExtraPointsHaveBeenAddedAnd()
        {
            backupJob = new BackupJobExtra("split", "firstJob", "qwerty");
            objectFile1 = new ObjectFile(@"D:\BackupsStuff\aba.txt");
            objectFile2 = new ObjectFile(@"D:\BackupsStuff\caba.txt");
            backupJob.JobObject().AddFile(objectFile1);
            backupJob.JobObject().AddFile(objectFile2);
            backupJob.MakeRestorePointExtra();
            backupJob.JobObject().ListFiles.Remove(objectFile1);
            backupJob.MakeRestorePointExtra();
        }
        [Test]
        public void DeleteExtraPoints()
        {
            backupJob = new BackupJobExtra("split", "firstJob1", "qwerty");
            objectFile1 = new ObjectFile(@"D:\BackupsStuff\aba.txt");
            objectFile2 = new ObjectFile(@"D:\BackupsStuff\caba.txt");
            backupJob.JobObject().AddFile(objectFile1);
            backupJob.JobObject().AddFile(objectFile2);
            backupJob.MakeRestorePointExtra();
            backupJob.JobObject().ListFiles.Remove(objectFile1);
            backupJob.MakeRestorePointExtra();
            backupJob.CleanResotrePointsByAmount(1);
            Assert.AreEqual(backupJob.RestorePointsExtra.Count, 1);
        }
        [Test]
        public void MergePoints()
        {
            backupJob = new BackupJobExtra("split", "firstJob2", "qwerty");
            objectFile1 = new ObjectFile(@"D:\BackupsStuff\aba.txt");
            objectFile2 = new ObjectFile(@"D:\BackupsStuff\caba.txt");
            backupJob.JobObject().AddFile(objectFile1);
            backupJob.JobObject().AddFile(objectFile2);
            backupJob.MakeRestorePointExtra();
            backupJob.JobObject().ListFiles.Remove(objectFile1);
            backupJob.MakeRestorePointExtra();
            backupJob.Merge(backupJob.RestorePointsExtra[0], backupJob.RestorePointsExtra[1]);
            Assert.AreEqual(backupJob.RestorePointsExtra[1].Objectss().Count, 2);
        }*/
    }
}
