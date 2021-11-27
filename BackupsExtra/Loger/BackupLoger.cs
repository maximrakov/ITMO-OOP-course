using System;
using System.IO;

namespace BackupsExtra.Loger
{
    [Serializable]
    public static class BackupLoger
    {
        public static bool Cons { get; set; }
        public static bool Fl { get; set; }
        public static string Path { get; set; }

        public static void AddMessage(string message)
        {
            if (Cons)
            {
                Console.WriteLine(message);
            }

            if (Fl)
            {
                File.AppendAllText(Path, message);
            }
        }
    }
}
