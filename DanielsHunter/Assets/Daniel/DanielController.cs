using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter
{
    class DanielController
    {
        Daniel Daniel;

        public DanielController(Daniel daniel)
        {
            Daniel = daniel;
        }

        public void PlaceDanielAtRandomPlaceOnTheBoard(Board board)
        {
            BoardController boardController = new BoardController(board);
            Random random = new Random();
            int randomX;
            int randomY;
            bool placePossible = false;
            do
            {
                randomX = random.Next(0, board.Width);
                randomY = random.Next(0, board.Height);

                if (!board.AssetsRepository.IsAsset((randomX, randomY)))
                {
                    placePossible = true;
                }
            } while (!placePossible);
            boardController.RemoveAssetFromTheBoard(Daniel);
            Daniel newDaniel = new Daniel(randomX, randomY);
            boardController.PlaceAssetOnTheBoard(newDaniel);
        }

       

    }
}
