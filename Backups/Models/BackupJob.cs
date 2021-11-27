using System;
using System.Collections.Generic;

namespace Backups.Models
{
    [Serializable]
    public class BackupJob : IBackupJob
    {
        public List<IRestorePoint> RestorePoints { get; set; }
        public JobObject JobObject { get; set; }
        public string StorageWay { get; set; }
        public string JobName { get; set; }
        public string StoragePath { get; set; }
        public int Number { get; set; }
        public BackupJob(string storageWay, string storagePath, string jobName)
        {
            string folderName = @"d:\";
            string totalPath = System.IO.Path.Combine(folderName, storagePath);
            System.IO.Directory.CreateDirectory(totalPath);
            RestorePoints = new List<IRestorePoint>();
            if (storageWay is null)
            {
                throw new ArgumentNullException(nameof(storageWay));
            }

            if (jobName is null)
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            Number = 0;
            JobObject = new JobObject();
            StorageWay = storageWay;
            JobName = jobName;
            StoragePath = totalPath;
        }

        public void MakeRestorePoint()
        {
            Number++;
            IRestorePoint restore = new RestorePoint(JobObject.ListFiles, StorageWay, StoragePath, Number);
            restore.MakeResorePoint();
            RestorePoints.Add(restore);
        }
    }
}
