using System;

namespace DanielsHunter
{
    public static class Common
    {
        public static void Quit(ConsoleKey whichKeyEscapes, int howManyTimes)
        {
            int exit3 = 0;
            ConsoleKey exit;
            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine($"\r\n\r\n\t\tPress {whichKeyEscapes} {howManyTimes} times to Quit");
                exit = Console.ReadKey().Key;
                if (exit == ConsoleKey.Escape) { exit3 += 1; }

            } while (exit3 < 3);
        }
    }
}