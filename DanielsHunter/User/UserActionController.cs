using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DanielsHunter
{
    class UserActionController
    {
        User User;
        public UserActionController()
        {

        }
        public UserActionController(User user)
        {
            User = user;
        }

        internal void ChopTree(Board board)
        {
            //todo a tego drzewa to nie wyciagac z assets repo?
            Tree tree = new Tree();
            (int x, int y) direction = DirectionMenager.GetDirection();
            var playArea = board.PlayArea;
            int X = User.X + direction.x;
            int Y = User.Y + direction.y;
            if (X >= 0 && X < board.Width && Y >= 0 && Y < board.Height && playArea[Y].Substring(X, 1) == tree.Symbol)
            {
                if (board.AssetsRepository.RemoveFromAssetsRepository(board.AssetsRepository.GetAsset((X,Y))))
                new BoardController(board).RemoveAssetFromTheBoard(X, Y);
            }
        }

        internal void MoveUser((int ofX, int ofY) modification,Screen screen)
        {
            if (User.X + modification.ofX >= 0 &&
                    User.X + modification.ofX < screen.Board.Width &&
                    User.Y + modification.ofY < screen.Board.Height &&
                    User.Y + modification.ofY >= 0)
            {
                if (screen.Board.PlayArea[User.Y + modification.ofY].Substring(User.X + modification.ofX, 1) != "#")
                {
                    User.X = User.X + modification.ofX;
                    User.Y = User.Y + modification.ofY;
                }
            }
            else
            {
                PlayerInputService.GetPlayersInput(screen, User);
            }
        }
    }
}
