using Backups.Models;

namespace BackupsExtra.Models
{
    public interface IBackupJobExtra
    {
        public JobObject JobObject();
        public void MakeRestorePointExtra();
        public void RecoverRestorePoint(int numb, string location);
        public void DeletRestorePoints(int numb);
    }
}
