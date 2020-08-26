using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter.Common
{
    public static class TitleScreenService
    {
        internal static void TitleScreen()
        {
            Console.Clear();
            Console.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\n\t\t\t\tD A N I E L S   H U N T E R");
            Console.ReadKey(true);
        }
    }
}
