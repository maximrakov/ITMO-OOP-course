using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Backups.Stuff;

namespace Backups.DataUtils
{
    [Serializable]
    public class Repository : IRepository
    {
        public int Number { get; set; }
        public List<ObjectFile> ObjectFiles { get; set; }
        public string StoragePath { get; set; }
        public string StorageWay { get; set; }
        public string StorageNpth { get; set; }
        public Repository(string storageWay, List<ObjectFile> objects, string storagePath, int number)
        {
            Number = number;
            StorageWay = storageWay;
            StorageNpth = storagePath;
            if (storageWay is null)
            {
                throw new ArgumentNullException(nameof(storageWay));
            }

            if (objects is null)
            {
                throw new ArgumentNullException(nameof(objects));
            }

            StoragePath = System.IO.Path.Combine(storagePath, Number.ToString());
            ObjectFiles = new List<ObjectFile>();
            foreach (ObjectFile objectFile in objects)
            {
                ObjectFiles.Add(objectFile.GetCpy());
            }
        }

        public void MakeRestorePoint()
        {
            if (StorageWay == "single")
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(StoragePath, "wtmp"));
                foreach (ObjectFile objectFile in ObjectFiles)
                {
                    File.Copy(objectFile.Info, System.IO.Path.Combine(System.IO.Path.Combine(StoragePath, "wtmp"), Path.GetFileName(objectFile.Info)));
                }

                string zipPath = System.IO.Path.Combine(StoragePath, "arc.zip");

                ZipFile.CreateFromDirectory(System.IO.Path.Combine(StoragePath, "wtmp"), zipPath);
            }

            if (StorageWay == "split")
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(StoragePath, "wtmp"));

                string zipPath;
                int numb = 0;
                foreach (ObjectFile objectFile in ObjectFiles)
                {
                    File.Copy(objectFile.Info, System.IO.Path.Combine(System.IO.Path.Combine(StoragePath, "wtmp"), Path.GetFileName(objectFile.Info)));
                    numb++;
                    zipPath = System.IO.Path.Combine(StoragePath, "arc" + numb.ToString() + ".zip");
                    ZipFile.CreateFromDirectory(System.IO.Path.Combine(StoragePath, "wtmp"), zipPath);
                    File.Delete(System.IO.Path.Combine(System.IO.Path.Combine(StoragePath, "wtmp"), Path.GetFileName(objectFile.Info)));
                }

                Directory.Delete(System.IO.Path.Combine(StoragePath, "wtmp"));
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
