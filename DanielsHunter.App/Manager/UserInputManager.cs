using DanielsHunter.App.Concrete;
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
                if (key == ConsoleKey.Escape) { new EscapeService(game).Run(); key = ConsoleKey.NumPad5; }
                game.screenManager.UpdateScreen(game);

            } while (key == ConsoleKey.Q ||
                     key == ConsoleKey.W ||
                     key == ConsoleKey.NumPad5);

            game.userService.User.PressedKey = key;
        }
    }
}
