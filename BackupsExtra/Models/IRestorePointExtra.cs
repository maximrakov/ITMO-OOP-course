using System;
using System.Collections.Generic;
using Backups.Models;
using Backups.Stuff;

namespace BackupsExtra.Models
{
    public interface IRestorePointExtra : IRestorePoint
    {
        public void Recovery(string location);
        public void Delete();
        public void Merge(IRestorePointExtra other);
        public List<ObjectFile> Objectss();
        public DateTime DateTimes();
    }
}
