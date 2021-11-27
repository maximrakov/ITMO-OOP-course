using System;
using System.Collections.Generic;
using Backups.Models;
using Backups.Stuff;
using BackupsExtra.Loger;

namespace BackupsExtra.Models
{
    [Serializable]
    public class StorageExtra : IStorageExtra
    {
        private Storage storage;
        public IRepositoryExtra RepositoryExtra { get; set; }
        public StorageExtra(List<ObjectFile> objects, string storageWay, string storagePath, int numb)
        {
            RepositoryExtra = new RepositoryExtra(storageWay, objects, storagePath, numb);
            storage = new Storage(objects, storageWay, storagePath, numb);
            storage.Repository = RepositoryExtra;
            BackupLoger.AddMessage("Create Storage Point" + DateTime.Now.ToString());
        }

        public void Recovery(string location)
        {
            RepositoryExtra.Recovery(location);
        }

        public void MakeRestorePoint()
        {
            RepositoryExtra.MakeRestorePoint();
        }

        public void Delete()
        {
            RepositoryExtra.Delete();
        }

        public void AddFiles(List<ObjectFile> objectFiles)
        {
            RepositoryExtra.AddFiles(objectFiles);
        }
    }
}
