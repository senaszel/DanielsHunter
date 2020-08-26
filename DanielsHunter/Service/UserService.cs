using DanielsHunter.Common;
using DanielsHunter.Model;

namespace DanielsHunter.Service
{
    public class UserService
    {
        public User user;
        public UserService()
        {
        }
        public UserService(User user)
        {
            this.user = user;
        }

        public void ChopTree(Board board)
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
                if (board.AssetsRepository.RemoveFromAssetsRepository(board.AssetsRepository.GetAsset((X, Y))))
                    new BoardService(board).RemoveAssetFromTheBoard(X, Y);
            }
        }

        internal void MoveUser((int ofX, int ofY) modification, Screen screen)
        {
            if (user.X + modification.ofX >= 0 &&
                user.X + modification.ofX < screen.Board.Width &&
                user.Y + modification.ofY < screen.Board.Height &&
                user.Y + modification.ofY >= 0)
            {
                if (screen.Board.PlayArea[user.Y + modification.ofY].Substring(user.X + modification.ofX, 1) != "#")
                {
                    user.X = user.X + modification.ofX;
                    user.Y = user.Y + modification.ofY;
                }
            }
            else
            {
                UserInputService.GetPlayersInput(screen, user);
            }
        }
    }
}
