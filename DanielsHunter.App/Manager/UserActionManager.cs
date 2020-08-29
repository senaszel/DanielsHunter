using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Manager
{
    public class UserActionManager
    {
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

        public void MoveUser((int ofX, int ofY) modification, Screen screen, AssetService assetService)
        {
            if (user.X + modification.ofX >= 0 &&
                user.X + modification.ofX < screen.Board.Width &&
                user.Y + modification.ofY < screen.Board.Height &&
                user.Y + modification.ofY >= 0)
            {
                if (screen.Board.PlayArea[user.Y + modification.ofY].Substring(user.X + modification.ofX, 1) != "#")
                {
                    user.X += modification.ofX;
                    user.Y += modification.ofY;
                }
            }
            else
            {
                UserInputManager.GetPlayersInput(screen, user, assetService);
            }
        }
    }
}
