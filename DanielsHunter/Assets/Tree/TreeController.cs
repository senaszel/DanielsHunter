using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter
{
    class TreeController
    {
        private Tree Tree;

        public TreeController()
        {
            Tree = new Tree();
        }
        public TreeController(Tree tree)
        {
            Tree = tree;
        }

        public void GrowTrees(Board board, User user)
        {
            int x = user.X;
            int y = user.Y;

            if ((y - 1 >= 0) && (x - 1 >= 0))
                if (!board.AssetsRepository.IsAsset(x - 1, y - 1))
                    new BoardController(board).PlaceAssetOnTheBoard(new Tree("TreeController-GrowTrees-generatedTree",x - 1, y - 1));

            if ((y + 1 < board.Height) && (x - 1 >= 0))
                if (!board.AssetsRepository.IsAsset(x - 1, y + 1))
                    new BoardController(board).PlaceAssetOnTheBoard(new Tree("TreeController-GrowTrees-generatedTree", x - 1, y + 1));

            if ((y - 1 >= 0) && (x + 1 < board.Width))
                if (!board.AssetsRepository.IsAsset(x + 1, y - 1))
                    new BoardController(board).PlaceAssetOnTheBoard(new Tree("TreeController-GrowTrees-generatedTree", x + 1, y - 1));

            if ((y + 1 < board.Height) && (x + 1 < board.Width))
                if (!board.AssetsRepository.IsAsset(x + 1, y + 1))
                    new BoardController(board).PlaceAssetOnTheBoard(new Tree("TreeController-GrowTrees-generatedTree", x + 1, y + 1));
        }

    }
}
