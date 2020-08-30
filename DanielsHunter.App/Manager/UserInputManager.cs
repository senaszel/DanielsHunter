﻿using DanielsHunter.App.Common;
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
                key = game.userActionManager.ChooseAction(game.actionService);
                if (key == ConsoleKey.Escape) { Environment.Exit(0); }
                game.screenManager.UpdateScreen(game);

            } while (key == ConsoleKey.Q ||
                     key == ConsoleKey.W ||
                     key == ConsoleKey.NumPad5);

            if (game.userService.User.ChosenAction == UserActionEnum.MOVE)
            {
                (int ofX, int ofY) modification = DirectionMenager.PassDirection(key);
                game.userActionManager.MoveUser(modification, game);
                game.screenManager.UpdateScreen(game);
            }
            if (game.userService.User.ChosenAction == UserActionEnum.CHOP_TREE)
            {
                game.userActionManager.ChopTree(game.screenService.Screen.Board, game.assetService, key);
                game.actionService.ResetToMOVE();
                game.screenManager.UpdateScreen(game);
            }
            else if (game.userService.User.ChosenAction == UserActionEnum.SHOOT)
            {
                game.userActionManager.Shoot(game,key);
                game.actionService.ResetToMOVE();
                game.screenManager.UpdateScreen(game);
            }
        }
    }
}
