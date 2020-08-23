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

        internal void ChopTree(Board board,AssetsRepository assetsRepository)
        {
            Tree tree = new Tree();
            (int x, int y) direction = DirectionMenager.GetDirection();
            var playArea = board.PlayArea;
            tree.X = User.X + direction.x;
            tree.Y = User.Y + direction.y;
            if (playArea[tree.Y].Substring(tree.X,1)==tree.Symbol)
            {
                new BoardController(board,assetsRepository).RemoveAssetFromTheBoard(tree);
            }
        }
    }
}
