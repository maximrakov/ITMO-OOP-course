using System;

namespace Isu
{
    internal class Program
    {
        private static void Main()
        {
            var dt = new DateTime(2000, 1, 1, 22, 10, 0);
            var dt2 = new DateTime(2000, 1, 1, 22, 15, 0);
            Console.WriteLine(dt2.Subtract(dt));
        }
    }
}
