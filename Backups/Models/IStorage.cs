namespace Backups.Models
{
    public interface IStorage
    {
        void MakeRestorePoint();
    }
}
