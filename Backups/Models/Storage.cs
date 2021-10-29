using System;
using System.Collections.Generic;
using Backups.DataUtils;
using Backups.Stuff;

namespace Backups.Models
{
    public class Storage
    {
        public Storage(List<ObjectFile> objects, string storageWay)
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

            Repository = new Repository(storageWay, objects);
        }

        public List<ObjectFile> ObjectFiles { get; set; }
        public Repository Repository { get; set; }
        public string StorageWay { get; set; }
    }
}
