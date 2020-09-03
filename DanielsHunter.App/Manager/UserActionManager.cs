using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using System;

namespace DanielsHunter.App.Manager
{
    public class UserActionManager
    {
        private readonly User user;
        public UserActionManager()
        {
        }
        public UserActionManager(User user)
        {
            this.user = user;
        }

        internal void ChopTree(Game game, ConsoleKey key)
        {
            Tree tree = new Tree();
            (int x, int y) direction = DirectionMenager.PassDirection(key);
            int X = user.X + direction.x;
            int Y = user.Y + direction.y;
            if (X >= 0 &&
                X < game.boardService.Board.Width &&
                Y >= 0 &&
                Y < game.boardService.Board.Height &&
                 game.boardService.Board.PlayArea[Y].Substring(X, 1) == tree.Symbol)
            {
                game.assetService.RemoveFromAssets(game.assetService.GetAsset((X, Y)));
                game.boardManager.RemoveSymbolFromPlayArea((X, Y));
            }
        }

        internal void Shoot(Game game, ConsoleKey key)
        {
            (int x, int y) direction = DirectionMenager.PassDirection(key);
            if (direction.x == 0 && direction.y == 0) return;
            (int x, int y) bullet = game.userService.User.Key;
            Board board = (Board)game.boardService.GetFirstItem();
            do
            {
                bullet.x += direction.x;
                bullet.y += direction.y;
                if (game.assetService.IsAsset(bullet))
                {
                    if (game.assetService.GetAsset(bullet).Symbol != "d")
                    {
                        return;
                    }
                    else
                    {
                        game.gameStateManager.ScoreDaniel(game);
                        return;
                    }
                }
            } while (bullet.x >= 0 &&
                     bullet.x < board.Width &&
                     bullet.y >= 0 &&
                     bullet.y < board.Height);
        }

        public void MoveUser((int ofX, int ofY) modification, Game game)
        {
            AssetManager assetManager = new AssetManager(game.assetService,game.boardManager);
            assetManager.DisposeAsset(game.userService.User);
            TryMoveUser(modification, game);
            assetManager.IntroduceAsset(game.userService.User);
        }

        private void TryMoveUser((int ofX, int ofY) modification, Game game)
        {
            if (user.X + modification.ofX >= 0 &&
                user.X + modification.ofX < game.screenService.Screen.Board.Width &&
                user.Y + modification.ofY < game.screenService.Screen.Board.Height &&
                user.Y + modification.ofY >= 0)
            {
                if (game.screenService.Screen.Board.PlayArea[user.Y + modification.ofY].Substring(user.X + modification.ofX, 1) != "#")
                {
                    user.X += modification.ofX;
                    user.Y += modification.ofY;
                }
            }
            else
            {
                game.assetManager.IntroduceAsset(game.userService.User);
                UserInputManager.GetPlayersInput(game);
            }
        }

        public ConsoleKey ChooseAction(ActionService actionService)
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                user.ChosenAction = key switch
                {
                    ConsoleKey.Q => actionService.PreviousAction(),
                    ConsoleKey.W => actionService.NextAction(),
                    ConsoleKey.NumPad1 => user.ChosenAction,
                    ConsoleKey.NumPad2 => user.ChosenAction,
                    ConsoleKey.NumPad3 => user.ChosenAction,
                    ConsoleKey.NumPad4 => user.ChosenAction,
                    ConsoleKey.NumPad5 => actionService.NextAction(),
                    ConsoleKey.NumPad6 => user.ChosenAction,
                    ConsoleKey.NumPad7 => user.ChosenAction,
                    ConsoleKey.NumPad8 => user.ChosenAction,
                    ConsoleKey.NumPad9 => user.ChosenAction,
                    ConsoleKey.Escape => user.ChosenAction,
                    _ => UserActionEnum.NO_CHANGE
                };
            } while (user.ChosenAction == UserActionEnum.NO_CHANGE);
            return key;
        }
    }
}
