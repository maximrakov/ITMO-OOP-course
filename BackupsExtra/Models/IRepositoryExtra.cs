using System.Collections.Generic;
using Backups.DataUtils;
using Backups.Stuff;

namespace BackupsExtra.Models
{
    public interface IRepositoryExtra : IRepository
    {
        public void Recovery(string path);
        public void Delete();
        public void AddFiles(List<ObjectFile> objectFiles);
    }
}
