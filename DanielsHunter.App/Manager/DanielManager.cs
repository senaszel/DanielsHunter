using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using System;

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

        public void RunDaniel(Game game)
        {
            System.Random random = new System.Random();
            Daniel daniel = (Daniel)game.assetService.GetAsset("Daniel");
            Daniel newDaniel = daniel;
            new AssetManager(game).RemoveAssetFromTheBoard(daniel);
            User user = game.userService.User;
            (int higher,int lower) Y = newDaniel.Y > user.Y ? (newDaniel.Y,user.Y) : (user.Y,newDaniel.Y);
            (int higher, int lower) X = newDaniel.X > user.X ? (newDaniel.X,user.X) : (user.X,newDaniel.Y);
            int distance = Y.higher - Y.lower >= X.higher - X.lower ? (X.higher - X.lower) : (Y.higher - Y.lower);
            if (distance < 11)
            {
                int randomDirection = random.Next(1,10);
                var key = DirectionMenager.ConvertIntToConsoleKey(randomDirection);
                (int x, int y) modificators = DirectionMenager.PassDirection(key);
                int newX = newDaniel.X + modificators.x;
                int newY = newDaniel.Y + modificators.y;
                if (newX >= 0 &&
                    newX < game.boardService.Board.Width &&
                    newY >= 0 &&
                    newY < game.boardService.Board.Height)
                {
                    newDaniel.X += modificators.x;
                    newDaniel.Y += modificators.y;
                }
            }
            new AssetManager(game).PlaceAssetOnTheBoard(newDaniel);
        }

        private object AssetManager()
        {
            throw new NotImplementedException();
        }
    }
}
