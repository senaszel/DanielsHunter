using System;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(85,32);
            Game.Set();
            Game.Start();

            int exit3 = 0;
            ConsoleKey exit;
            do
            {
                Console.Clear();
                Console.WriteLine(string.Concat("\r\n\r\n",new string(' ',20),Game.Outcome));
                Console.WriteLine("\r\n\r\n3 x Escape to Quit");
                Console.WriteLine();
                exit = Console.ReadKey().Key;
                if (exit == ConsoleKey.Escape) { exit3 += 1; }

            } while (exit3 < 3);
        }
    }
}
