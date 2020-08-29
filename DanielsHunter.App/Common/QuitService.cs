using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using System;

namespace DanielsHunter.App.Common
{
    public static class QuitService
    {
        public static void Quit(ScreenManager screenService, GameState gameState, ConsoleKey whichKeyEscapes, int howManyTimes)
        {
            string comment = gameState.Outcome == GameOutcome.LOST ? "Sorry," : "Congratulations";
            int exit3 = 0;
            ConsoleKey exit;
            do
            {
                Console.Clear();
                Console.CursorVisible = false;
                screenService.FillFooterMenuWithContent(0,$"{comment} You have {gameState.Outcome}!", $"Press {whichKeyEscapes} {howManyTimes} times to Quit");
                screenService.ShowScreen(true);
                exit = Console.ReadKey().Key;
                if (exit == ConsoleKey.Escape) { exit3 += 1; }

            } while (exit3 < 3);
            Environment.Exit(0);
        }
    }
}