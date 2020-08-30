using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using System;

namespace DanielsHunter.App.Manager
{
    public class UserActionManager
    {
        // todo wydzielic user service zeby mozna tutaj zrobic private
        public User user;
        public UserActionManager()
        {
        }
        public UserActionManager(User user)
        {
            this.user = user;
        }

        public void ChopTree(Board board, AssetService assetService)
        {
            Tree tree = new Tree();
            (int x, int y) direction = DirectionMenager.GetDirection();
            var playArea = board.PlayArea;
            int X = user.X + direction.x;
            int Y = user.Y + direction.y;
            if (X >= 0 &&
                X < board.Width &&
                Y >= 0 &&
                Y < board.Height &&
                playArea[Y].Substring(X, 1) == tree.Symbol)
            {
                assetService.RemoveFromAssetsRepository(assetService.GetAsset((X, Y)));
                new BoardManager(board).RemoveSymbolFromPlayArea(X, Y);
            }
        }

        internal void ChopTree(Board board, AssetService assetService, ConsoleKey key)
        {
            Tree tree = new Tree();
            (int x, int y) direction = DirectionMenager.PassDirection(key);
            var playArea = board.PlayArea;
            int X = user.X + direction.x;
            int Y = user.Y + direction.y;
            if (X >= 0 &&
                X < board.Width &&
                Y >= 0 &&
                Y < board.Height &&
                playArea[Y].Substring(X, 1) == tree.Symbol)
            {
                assetService.RemoveFromAssetsRepository(assetService.GetAsset((X, Y)));
                new BoardManager(board).RemoveSymbolFromPlayArea(X, Y);
            }
        }

        public void MoveUser((int ofX, int ofY) modification, Game game)
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
