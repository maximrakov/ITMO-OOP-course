using System;
using System.Collections.Generic;
using Banks.Banks;
using Banks.BanksStuff;
using Banks.Managers;
using Banks.UI;
using Banks.Util;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var customManager = new CustomManager();
            string cmd;
            while (true)
            {
                cmd = Console.ReadLine();

                if (cmd == "view")
                {
                    customManager.GetState();
                }

                if (cmd == "reg1")
                {
                    string name = Console.ReadLine();
                    string surname = Console.ReadLine();
                    customManager.RegisterAccount(name, surname);
                }

                if (cmd == "reg2")
                {
                    string name = Console.ReadLine();
                    string surname = Console.ReadLine();
                    string password = Console.ReadLine();
                    string adress = Console.ReadLine();
                    customManager.RegisterAccount(name, surname, password, adress);
                }

                if (cmd == "improve")
                {
                    string password = Console.ReadLine();
                    string adress = Console.ReadLine();
                    customManager.Improve(password, adress);
                }

                if (cmd == "transfer")
                {
                    string val = Console.ReadLine();
                    int senderId = Convert.ToInt32(val);
                    val = Console.ReadLine();
                    int takerId = Convert.ToInt32(val);
                    val = Console.ReadLine();
                    int amount = Convert.ToInt32(val);
                    customManager.Transfer(senderId, takerId, amount);
                }

                if (cmd == "acc")
                {
                    string type = Console.ReadLine();
                    customManager.MakeAccount(type);
                }
            }
        }
    }
}
