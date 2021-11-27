using System;
using System.Collections.Generic;
using Backups.Stuff;

namespace Backups.Models
{
    [Serializable]
    public class RestorePoint : IRestorePoint
    {
        public RestorePoint(List<ObjectFile> objectFiles, string storageWay, string storagePath, int number)
        {
            if (storageWay is null)
            {
                throw new ArgumentNullException(nameof(storageWay));
            }

            Storage = new Storage(objectFiles, storageWay, storagePath, number);
        }

        public void MakeResorePoint()
        {
            Storage.MakeRestorePoint();
        }

        public IStorage Storage { get; set; }
    }
}
