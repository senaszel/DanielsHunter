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

        
    }
}
