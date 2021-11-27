namespace Backups.Models
{
    public interface IBackupJob
    {
        public void MakeRestorePoint();
    }
}
