using System;
using System.Collections.Generic;
using Backups.Stuff;

namespace Backups.Models
{
    public class RestorePoint
    {
        public RestorePoint(List<ObjectFile> objectFiles, string storageWay)
        {
            if (storageWay is null)
            {
                throw new ArgumentNullException(nameof(storageWay));
            }

            Storage = new Storage(objectFiles, storageWay);
        }

        public Storage Storage { get; set; }
    }
}
