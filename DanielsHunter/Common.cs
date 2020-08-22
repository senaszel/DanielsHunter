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
    }
}