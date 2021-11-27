using System;
using System.Collections.Generic;
using Backups.DataUtils;
using Backups.Stuff;

namespace Backups.Models
{
    [Serializable]
    public class Storage : IStorage
    {
        public Storage(List<ObjectFile> objects, string storageWay, string storagePath, int number)
        {
            if (objects is null)
            {
                throw new ArgumentNullException(nameof(objects));
            }

            if (storageWay is null)
            {
                throw new ArgumentNullException(nameof(storageWay));
            }

            ObjectFiles = new List<ObjectFile>();
            foreach (ObjectFile objectFile in objects)
            {
                ObjectFiles.Add(objectFile.GetCpy());
            }

            Repository = new Repository(storageWay, objects, storagePath, number);
        }

        public void MakeRestorePoint()
        {
            Repository.MakeRestorePoint();
        }

        public List<ObjectFile> ObjectFiles { get; set; }
        public IRepository Repository { get; set; }
        public string StorageWay { get; set; }
    }
}
