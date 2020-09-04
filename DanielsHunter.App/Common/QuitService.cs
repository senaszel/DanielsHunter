using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Enum;
using System;

namespace DanielsHunter.App.Common
{
    public static class QuitService
    {
        public static void Quit(Game game, ConsoleKey whichKeyEscapes, int howManyTimes)
        {
            string comment = game.gameState.Outcome == GameOutcomeEnum.LOST ? "Sorry," : "Congratulations";
            int exit3 = 0;
            ConsoleKey exit;
            do
            {
                game.screenManager.FillFooterMenuWithContent(null,$"{comment} You have {game.gameState.Outcome}!", $"Press {whichKeyEscapes} {howManyTimes} times to Quit");
                game.screenManager.UpdateScreen(game,true);
                exit = Console.ReadKey().Key;
                if (exit == ConsoleKey.Escape) { exit3 += 1; }

            } while (exit3 < 3);
            Environment.Exit(0);
        }
    }
}