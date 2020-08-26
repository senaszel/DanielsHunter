using DanielsHunter.Model;

namespace DanielsHunter.Service
{
    class DanielService
    {
        private Daniel daniel;

        public DanielService(Daniel daniel)
        {
            this.daniel = daniel;
        }

        public void PlaceDanielAtRandomPlaceOnTheBoard(Board board)
        {
            BoardService boardController = new BoardService(board);
            System.Random random = new System.Random();
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
            boardController.RemoveAssetFromTheBoard(daniel);
            Daniel newDaniel = new Daniel(randomX, randomY);
            boardController.PlaceAssetOnTheBoard(newDaniel);
        }

       

    }
}
