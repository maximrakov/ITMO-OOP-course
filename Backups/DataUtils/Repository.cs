using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Backups.Stuff;

namespace Backups.DataUtils
{
    public class Repository
    {
        public string Way { get; set; }
        public Repository(string storageWay, List<ObjectFile> objects)
        {
            Way = @"labb";
            if (storageWay is null)
            {
                throw new ArgumentNullException(nameof(storageWay));
            }

            if (objects is null)
            {
                throw new ArgumentNullException(nameof(objects));
            }

            if (storageWay == "single")
            {
                using (StreamWriter sw = File.CreateText(@"d:\" + Way + @"\wtmp\tmptxt.txt"))
                {
                    foreach (ObjectFile objectFile in objects)
                    {
                        sw.WriteLine(objectFile.Info);
                    }
                }

                string zipPath = @"d:\labb\res\result" + objects[0].Info + ".zip";
                ZipFile.CreateFromDirectory(@"d:\labb\wtmp", zipPath);
            }

            if (storageWay == "split")
            {
                string zipPath = @"d:\" + Way + @"\wtmp\res\result" + objects[0].Info + ".zip";
                foreach (ObjectFile objectFile in objects)
                {
                    using (StreamWriter sw = File.CreateText(@"d:\labb\wtmp\tmptxt.txt"))
                    {
                        sw.WriteLine(objectFile.Info);
                    }

                    zipPath = @"d:\" + Way + @"\res\result" + RandomString(10) + objectFile.Info + ".zip";
                    ZipFile.CreateFromDirectory(@"d:\labb\wtmp", zipPath);
                }
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
