using System.Collections.Generic;
using Backups.Stuff;

namespace Backups.Models
{
    public class JobObject
    {
        public List<ObjectFile> ListFiles { get; set; }

        public JobObject()
        {
            ListFiles = new List<ObjectFile>();
        }

        public void AddFile(ObjectFile objectFile)
        {
            ListFiles.Add(objectFile);
        }
    }
}
