using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter
{
    class TreeService
    {
        public Tree Tree { get; set; }

        public TreeService()
        {
            Tree = new Tree();
        }

        public Board GrowTrees(Board board, int userX, int userY)
        {
            board.View[userY - 1] = board.View[userY - 1].Insert(userX - 1, Tree.Symbol).Remove(userX, 1);
            board.View[userY + 1] = board.View[userY + 1].Insert(userX - 1, Tree.Symbol).Remove(userX, 1);

            board.View[userY - 1] = board.View[userY - 1].Insert(userX + 1, Tree.Symbol).Remove(userX + 2, 1);
            board.View[userY + 1] = board.View[userY + 1].Insert(userX + 1, Tree.Symbol).Remove(userX + 2, 1);
            return board;
        }
    }
}
