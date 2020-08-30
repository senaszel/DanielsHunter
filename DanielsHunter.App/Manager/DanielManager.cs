using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Manager
{
    public class DanielManager
    {
        private readonly Daniel daniel;

        public DanielManager(Daniel daniel)
        {
            this.daniel = daniel;
        }

        public void PlaceDanielAtRandomPlaceOnTheBoard(Game game)
        {
            System.Random random = new System.Random();
            int randomX;
            int randomY;
            bool placePossible = false;
            do
            {
                randomX = random.Next(0, game.boardService.Board.Width);
                randomY = random.Next(0, game.boardService.Board.Height);

                if (!game.assetService.IsAsset((randomX, randomY)))
                {
                    placePossible = true;
                }
            } while (!placePossible);
            new AssetManager(game).RemoveAssetFromTheBoard(daniel);
            Daniel newDaniel = new Daniel(randomX, randomY);
            new AssetManager(game).PlaceAssetOnTheBoard(newDaniel);
        }



    }
}
