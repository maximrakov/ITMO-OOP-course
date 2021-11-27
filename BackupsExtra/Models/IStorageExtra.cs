using System.Collections.Generic;
using Backups.Models;
using Backups.Stuff;

namespace BackupsExtra.Models
{
    public interface IStorageExtra : IStorage
    {
        public void Recovery(string location);
        public void Delete();
        public void AddFiles(List<ObjectFile> objectFiles);
    }
}
