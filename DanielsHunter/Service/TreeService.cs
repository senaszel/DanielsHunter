using DanielsHunter.Model;

namespace DanielsHunter.Service
{
    class TreeService
    {
        private Tree tree;

        public TreeService()
        {
            tree = new Tree();
        }
        public TreeService(Tree tree)
        {
            this.tree = tree;
        }

        public void GrowTrees(Board board, User user)
        {
            (int ofX, int ofY)[] modification = new[] { (-1, 0), (-1, -1), (0, -1), (1, -1), (1, 0), (1, 1), (0, 1), (-1, 1) };
            for (int i = 0; i < modification.Length; i++)
            {
                int newX = user.X + modification[i].ofX;
                int newY = user.Y + modification[i].ofY;
                if (newX >= 0 &&
                    newX < board.Width &&
                    newY < board.Height &&
                    newY >= 0)
                {
                    if (!board.AssetsRepository.IsAsset((newX, newY)))
                    {
                        new BoardService(board).PlaceAssetOnTheBoard(new Tree("TreeController-GrowTrees-generatedTree", newX, newY));
                    }
                }
            }
        }

    }
}
