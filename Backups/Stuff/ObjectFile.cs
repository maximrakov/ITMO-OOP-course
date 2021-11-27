using System;

namespace Backups.Stuff
{
    [Serializable]
    public class ObjectFile
    {
        public string Info { get; set; }
        public ObjectFile(string path)
        {
            Info = path;
        }

        public ObjectFile GetCpy()
        {
            return new ObjectFile(Info);
        }
    }
}
