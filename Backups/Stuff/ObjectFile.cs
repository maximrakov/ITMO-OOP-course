namespace Backups.Stuff
{
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
