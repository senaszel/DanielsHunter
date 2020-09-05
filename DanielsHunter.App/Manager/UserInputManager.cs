using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using System;

namespace DanielsHunter.App.Manager
{
    static class UserInputManager
    {
        public static void GetPlayersInput(Game game)
        {
            ConsoleKey key;
            do
            {
                key = game.userActionManager.ChooseAction(game.actionService);
                if (key == ConsoleKey.Escape) { Environment.Exit(0); }
                game.screenManager.UpdateScreen(game);

            } while (key == ConsoleKey.Q ||
                     key == ConsoleKey.W ||
                     key == ConsoleKey.NumPad5);

            game.userActionService.PerformUserAction(key);
        }

        
    }
}
