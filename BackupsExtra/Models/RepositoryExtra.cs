using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Backups.DataUtils;
using Backups.Stuff;
using BackupsExtra.Loger;

namespace BackupsExtra.Models
{
    [Serializable]
    public class RepositoryExtra : IRepositoryExtra
    {
        public Repository Repository { get; set; }
        public RepositoryExtra(string storageWay, List<ObjectFile> objects, string storagePath, int numb)
        {
            Repository = new Repository(storageWay, objects, storagePath, numb);
            BackupLoger.AddMessage("Create Repostitory Point" + DateTime.Now.ToString());
        }

        public void Recovery(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (Repository.StorageWay == "single")
            {
                ZipFile.ExtractToDirectory(System.IO.Path.Combine(Repository.StoragePath, "arc.zip"), path);
            }

            if (Repository.StorageWay == "split")
            {
                int numb = 0;
                foreach (ObjectFile objectFile in Repository.ObjectFiles)
                {
                    numb++;
                    string zipPath = System.IO.Path.Combine(Repository.StoragePath, "arc" + numb.ToString() + ".zip");
                    ZipFile.ExtractToDirectory(zipPath, path);
                }
            }
        }

        public void Delete()
        {
            if (Repository.StorageWay == "single")
            {
                string zipPath = System.IO.Path.Combine(Repository.StoragePath, "arc.zip");
                foreach (ObjectFile objectFile in Repository.ObjectFiles)
                {
                    File.Delete(System.IO.Path.Combine(System.IO.Path.Combine(Repository.StoragePath, "wtmp"), Path.GetFileName(objectFile.Info)));
                }

                Directory.Delete(System.IO.Path.Combine(Repository.StoragePath, "wtmp"));
                File.Delete(zipPath);
                Directory.Delete(Repository.StoragePath);
            }

            if (Repository.StorageWay == "split")
            {
                int numb = 0;
                foreach (ObjectFile objectFile in Repository.ObjectFiles)
                {
                    numb++;
                    string zipPath = System.IO.Path.Combine(Repository.StoragePath, "arc" + numb.ToString() + ".zip");
                    File.Delete(zipPath);
                }

                Directory.Delete(Repository.StoragePath);
            }
        }

        public void MakeRestorePoint()
        {
            Repository.MakeRestorePoint();
        }

        public void AddFiles(List<ObjectFile> objectFiles)
        {
            string zipPath;
            int numb = objectFiles.Count;
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(Repository.StoragePath, "wtmp"));
            foreach (ObjectFile objectFile in objectFiles)
            {
                File.Copy(objectFile.Info, System.IO.Path.Combine(System.IO.Path.Combine(Repository.StoragePath, "wtmp"), Path.GetFileName(objectFile.Info)));
                numb++;
                zipPath = System.IO.Path.Combine(Repository.StoragePath, "arc" + numb.ToString() + ".zip");
                ZipFile.CreateFromDirectory(System.IO.Path.Combine(Repository.StoragePath, "wtmp"), zipPath);
                File.Delete(System.IO.Path.Combine(System.IO.Path.Combine(Repository.StoragePath, "wtmp"), Path.GetFileName(objectFile.Info)));
                Repository.ObjectFiles.Add(objectFile);
            }

            Directory.Delete(System.IO.Path.Combine(Repository.StoragePath, "wtmp"));
        }
    }
}
