using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
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
                key = new UserActionManager(game.userService.User).ChooseAction(game.actionService);
                if (key == ConsoleKey.Escape) { Environment.Exit(0); }
                UpdateScreen(game);

            } while (key == ConsoleKey.Q ||
                     key == ConsoleKey.W ||
                     key == ConsoleKey.NumPad5);

            if (game.userService.User.ChosenAction == UserActionEnum.MOVE)
            {
                (int ofX, int ofY) modification = DirectionMenager.PassDirection(key);
                new UserActionManager(game.userService.User).MoveUser(modification, game);
            }
            else if (game.userService.User.ChosenAction == UserActionEnum.CHOP_TREE)
            {
                new UserActionManager(game.userService.User).ChopTree(game.screenService.Screen.Board, game.assetService, key);
                game.actionService.ResetToMOVE();
                UpdateScreen(game);
            }
        }

        private static void UpdateScreen(Game game)
        {
            Console.Clear();
            game.screenManager.FillFooterMenuWithContent(0, $"{game.userService.User.ChosenAction}");
            game.screenManager.GenerateUpperScreen(game.assetService);
            game.screenManager.ShowScreen(true);
        }
    }
}
