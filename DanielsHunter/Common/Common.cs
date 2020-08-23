using System;

namespace DanielsHunter
{
    public static class Common
    {
        public static void Quit(ScreenController screenService, GameState gameState, ConsoleKey whichKeyEscapes, int howManyTimes)
        {
            string comment = gameState.Outcome == GameOutcome.LOST ? "Sorry," : "Congratulations";
            int exit3 = 0;
            ConsoleKey exit;
            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                screenService.Screen.CommStrip[1] = $"\t\t\t{comment} You have {gameState.Outcome}!";
                screenService.Screen.CommStrip[2] = $"\t\t\tPress {whichKeyEscapes} {howManyTimes} times to Quit";
                screenService.ShowScreen();
                exit = Console.ReadKey().Key;
                if (exit == ConsoleKey.Escape) { exit3 += 1; }

            } while (exit3 < 3);
            Environment.Exit(0);
        }

        internal static void TitleScreen()
        {
            Console.Clear();
            Console.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\n\t\t\t\tD A N I E L S   H U N T E R");
            Console.ReadKey(true);
        }

        internal static void Intro()
        {
            Console.WriteLine("\r\n\r\n\r\n\tWrzesień 2001 \r\n\r\n\tWchodzę do lasu. Nie jest to rozsądne; środek tygodnia, pusto, cicho, rwie się zasięg. Jestem sama. \r\n\tIdę. I jakoś tak schodzę ze ścieżki, jakoś tak chcę po lesie, w krzaki, liście, ziemię, mech. (...)\r\n\tKawałek kory rozcieram w palcach, skubię mech i grzybnię, dotykam pniaków. Las wciągam do środka. (...)\r\n\tJesienna skóra pachnie obłędnie, wciąż wącham ręce. Mam, złapałam ten moment: tak oto zaczyna się szczęście. (...)\r\n\tLas coraz gęstszy. Nie boję się wcale. Ciepło jest, jasno.\r\n\tNa początku.\r\n\t\tPstryk.\r\n\r\n\t\t\t\t\t\t-- Agnieszka Kaluga, \"Zorkownia\"\r\n\r\n\r\n\r\n\t\t...10 lat później...");
            Console.ReadKey(true);
        }
    }
}