using DanielsHunter.App.Concrete;
using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter.App.Helpers
{
    class InitialisationHelper
    {
        public void InitialisePlayArea(Screen screen)
        {
            int upperBoarder = 0;
            int lowerBoarder = screen.Board.Height + 1;
            for (int i = upperBoarder; i <= lowerBoarder; i++)
            {
                if (i == upperBoarder || i == lowerBoarder)
                {
                    screen.View[i] = string.Concat(new string(' ', screen.Board.Offset), new string('#', screen.Board.Width + 2));
                }
                else
                {
                    if (i <= screen.Board.Width)
                    {
                        screen.Board.PlayArea[i - 1] = new string(' ', screen.Board.Width);
                    }
                    screen.View[i] = string.Concat(new string(' ', screen.Board.Offset), '#', screen.Board.PlayArea[i - 1], '#');
                }
            }
        }

        internal void InitialiseWithTrees(BoardService boardService, AssetManager assetManager, int numberOfTrees)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfTrees; i++)
            {
                int x = random.Next(boardService.Board.Width);
                int y = random.Next(boardService.Board.Height);
                Tree tree = new Tree("Tree-Created-OnInitialisation", x, y);
                assetManager.IntroduceAsset(tree);
            }
        }

    }
}

