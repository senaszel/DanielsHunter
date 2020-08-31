using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Manager
{
    class TreeManager 
    {
        private readonly Tree tree;

        public TreeManager()
        {
            tree = new Tree();
        }
        public TreeManager(Tree tree)
        {
            this.tree = tree;
        }

        public void GrowTreesAroundPlayer(Game game)
        {
            (int ofX, int ofY)[] modification = new[] { (-1, 0), (-1, -1), (0, -1), (1, -1), (1, 0), (1, 1), (0, 1), (-1, 1) };
            for (int i = 0; i < modification.Length; i++)
            {
                int newX = game.userService.User.X + modification[i].ofX;
                int newY = game.userService.User.Y + modification[i].ofY;
                if (newX >= 0 &&
                    newX < game.boardService.Board.Width &&
                    newY < game.boardService.Board.Height &&
                    newY >= 0)
                {
                    if (!game.assetService.IsAsset((newX, newY)))
                    {
                        game.assetManager.IntroduceAsset(new Tree("TreeController-GrowTrees-generatedTree", newX, newY));
                    }
                }
            }
        }

    }
}
