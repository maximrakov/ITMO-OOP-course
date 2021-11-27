using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.DataUtils
{
    public interface IRepository
    {
        public void MakeRestorePoint();
    }
}
