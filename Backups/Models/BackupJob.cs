using System;
using System.Collections.Generic;

namespace Backups.Models
{
    public class BackupJob
    {
        public List<RestorePoint> RestorePoints { get; set; }
        public JobObject JobObject { get; set; }
        public string StorageWay { get; set; }
        public string JobName { get; set; }
        public BackupJob(string storageWay, string jobName)
        {
            RestorePoints = new List<RestorePoint>();
            if (storageWay is null)
            {
                throw new ArgumentNullException(nameof(storageWay));
            }

            if (jobName is null)
            {
                throw new ArgumentNullException(nameof(jobName));
            }

            JobObject = new JobObject();
            StorageWay = storageWay;
            JobName = jobName;
        }

        public void MakeRestorePoint()
        {
            RestorePoints.Add(new RestorePoint(JobObject.ListFiles, StorageWay));
        }
    }
}
