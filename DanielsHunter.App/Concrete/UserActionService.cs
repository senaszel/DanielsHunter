using DanielsHunter.App.Common;
using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using System;

namespace DanielsHunter.App.Concrete
{
    public class UserActionService
    {
        private Game game;
        public UserActionService()
        {
        }
        public UserActionService(Game game)
        {
            this.game = game;
        }
        public void PerformUserAction(ConsoleKey key)
        {

            switch (game.userService.User.ChosenAction)
            {
                case UserActionEnum.MOVE:
                    Move(key);
                    break;
                case UserActionEnum.CHOP_TREE:
                    ChopTree(key);
                    break;
                case UserActionEnum.SHOOT:
                    Shoot(key);
                    break;
                case UserActionEnum.WAIT:
                    Wait();
                    break;
            }
            game.screenManager.UpdateScreen(game);
        }

        private void Wait()
        {
            new DanielManager((Daniel)game.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString())).RunDaniel(game);
        }

        private void Shoot(ConsoleKey key)
        {
            game.userActionManager.Shoot(this.game, key);
            game.actionService.ResetToMOVE();
        }

        private void ChopTree(ConsoleKey key)
        {
            game.userActionManager.ChopTree(this.game, key);
            game.actionService.ResetToMOVE();
        }

        private void Move(ConsoleKey key)
        {
            (int ofX, int ofY) modification = DirectionMenager.PassDirection(key);
            game.userActionManager.MoveUser(modification, game);
            game.gameStateManager.HasDanielBeenCought(game);
            new DanielManager((Daniel)game.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString())).RunDaniel(game);
        }
    }
}
