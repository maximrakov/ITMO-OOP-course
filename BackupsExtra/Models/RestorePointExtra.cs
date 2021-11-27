using System;
using System.Collections.Generic;
using Backups.Models;
using Backups.Stuff;
using BackupsExtra.Loger;

namespace BackupsExtra.Models
{
    [Serializable]
    public class RestorePointExtra : IRestorePointExtra
    {
        public RestorePoint RestorePoint { get; set; }
        public IStorageExtra StorageExtra { get; set; }
        public List<ObjectFile> Objects { get; set; }
        public DateTime DateTime { get; set; }

        // public Data Data { get; set; }
        public RestorePointExtra(List<ObjectFile> objectFiles, string storageWay, string storagePath, int numb)
        {
            DateTime = DateTime.Now;
            RestorePoint = new RestorePoint(objectFiles, storageWay, storagePath, numb);
            StorageExtra = new StorageExtra(objectFiles, storageWay, storagePath, numb);
            Objects = new List<ObjectFile>();
            foreach (ObjectFile objectFile in objectFiles)
            {
                Objects.Add(objectFile.GetCpy());
            }

            RestorePoint.Storage = StorageExtra;
            BackupLoger.AddMessage("Create Restore Point" + DateTime.Now.ToString());
        }

        public List<ObjectFile> Objectss()
        {
            return Objects;
        }

        public DateTime DateTimes()
        {
            return DateTime;
        }

        public void Recovery(string location)
        {
            StorageExtra.Recovery(location);
        }

        public void MakeResorePoint()
        {
            StorageExtra.MakeRestorePoint();
        }

        public void Merge(IRestorePointExtra other)
        {
            var objectFiles = new List<ObjectFile>();
            foreach (ObjectFile objectFile in other.Objectss())
            {
                bool exist = false;
                foreach (ObjectFile objectFile1 in Objects)
                {
                    if (objectFile.Info == objectFile1.Info)
                    {
                        exist = true;
                    }
                }

                if (!exist)
                {
                    objectFiles.Add(objectFile);
                    Objects.Add(objectFile);
                }
            }

            StorageExtra.AddFiles(objectFiles);
        }

        public void Delete()
        {
            StorageExtra.Delete();
        }
    }
}
