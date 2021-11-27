using System;
using System.Collections.Generic;
using Backups.Models;

namespace BackupsExtra.Models
{
    [Serializable]
    public class BackupJobExtra : IBackupJobExtra
    {
        public BackupJob BackupJob { get; set; }
        public BackupJobExtra(string storageWay, string storagePath, string jobName)
        {
            BackupJob = new BackupJob(storageWay, storagePath, jobName);
            RestorePointsExtra = new List<IRestorePointExtra>();
        }

        public JobObject JobObject()
        {
            return BackupJob.JobObject;
        }

        public void MakeRestorePointExtra()
        {
            BackupJob.Number++;
            var restorePointExtra = new RestorePointExtra(BackupJob.JobObject.ListFiles, BackupJob.StorageWay, BackupJob.StoragePath, BackupJob.Number);
            restorePointExtra.MakeResorePoint();
            RestorePointsExtra.Add(restorePointExtra);
            BackupJob.RestorePoints.Add(restorePointExtra);
        }

        public void RecoverRestorePoint(int numb, string location)
        {
            RestorePointsExtra[numb].Recovery(location);
        }

        public void DeletRestorePoints(int numb)
        {
            RestorePointsExtra[numb].Delete();
            RestorePointsExtra.Remove(RestorePointsExtra[numb]);
        }

        public void Merge(IRestorePointExtra restorePointExtra, IRestorePointExtra restorePointExtra1)
        {
            restorePointExtra1.Merge(restorePointExtra);
        }

        public List<IRestorePointExtra> FindByAmount(int amount)
        {
            var restorePointExtras = new List<IRestorePointExtra>();
            int count = 0;
            foreach (RestorePointExtra restorePointExtra in RestorePointsExtra)
            {
                if (RestorePointsExtra.Count - count <= amount)
                {
                    break;
                }

                restorePointExtras.Add(restorePointExtra);
                count++;
            }

            return restorePointExtras;
        }

        public List<IRestorePointExtra> FindByDate(DateTime dateTime)
        {
            var restorePointExtras = new List<IRestorePointExtra>();
            foreach (RestorePointExtra restorePointExtra in RestorePointsExtra)
            {
                if (DateTime.Compare(restorePointExtra.DateTime, dateTime) < 0)
                {
                    restorePointExtras.Add(restorePointExtra);
                }
            }

            return restorePointExtras;
        }

        public void CleanResotrePointsByAmountAndId(int amount, DateTime dateTime)
        {
            List<IRestorePointExtra> restorePointExtras = FindByAmount(amount);
            List<IRestorePointExtra> restorePointExtras1 = FindByDate(dateTime);
            foreach (IRestorePointExtra restorePointExtra in restorePointExtras)
            {
                foreach (IRestorePointExtra restorePointExtra1 in restorePointExtras1)
                {
                    if (restorePointExtra == restorePointExtra1)
                    {
                        restorePointExtra.Delete();
                        RestorePointsExtra.Remove(restorePointExtra);
                    }
                }
            }
        }

        public void CleanResotrePointsByAmountOrId(int amount, DateTime dateTime)
        {
            List<IRestorePointExtra> restorePointExtras = FindByAmount(amount);
            List<IRestorePointExtra> restorePointExtras1 = FindByDate(dateTime);
            foreach (IRestorePointExtra restorePointExtra in restorePointExtras)
            {
                restorePointExtra.Delete();
                RestorePointsExtra.Remove(restorePointExtra);
            }

            foreach (IRestorePointExtra restorePointExtra in restorePointExtras1)
            {
                restorePointExtra.Delete();
                RestorePointsExtra.Remove(restorePointExtra);
            }
        }

        public void CleanResotrePointsByAmount(int amount)
        {
            List<IRestorePointExtra> restorePointExtras = FindByAmount(amount);
            foreach (IRestorePointExtra restorePointExtra in restorePointExtras)
            {
                restorePointExtra.Delete();
                RestorePointsExtra.Remove(restorePointExtra);
            }
        }

        public void CleanResotrePointsById(DateTime dateTime)
        {
            List<IRestorePointExtra> restorePointExtras = FindByDate(dateTime);
            foreach (IRestorePointExtra restorePointExtra in restorePointExtras)
            {
                RestorePointsExtra.Remove(restorePointExtra);
            }
        }

        public List<IRestorePointExtra> RestorePointsExtra { get; set; }
    }
}
