using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
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
            game.assetManager.DisposeAsset(daniel);
            Daniel newDaniel = new Daniel(randomX, randomY);
            game.assetManager.IntroduceAsset(newDaniel);
        }

        public void RunDaniel(Game game)
        {
            System.Random random = new System.Random();
            Daniel daniel = (Daniel)game.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString());
            Daniel newDaniel = daniel;
            game.assetManager.DisposeAsset(daniel);
            User user = game.userService.User;
            (int higher, int lower) Y = newDaniel.Y > user.Y ? (newDaniel.Y, user.Y) : (user.Y, newDaniel.Y);
            (int higher, int lower) X = newDaniel.X > user.X ? (newDaniel.X, user.X) : (user.X, newDaniel.Y);
            int distance = Y.higher - Y.lower >= X.higher - X.lower ? (X.higher - X.lower) : (Y.higher - Y.lower);
            if (distance < 11)
            {
                bool placePossible = false;
                do
                {
                    int newX = newDaniel.X;
                    int newY = newDaniel.Y;
                    int randomDirection = random.Next(1, 10);
                    var key = DirectionMenager.ConvertIntToConsoleKey(randomDirection);
                    (int x, int y) modificators = DirectionMenager.PassDirection(key);
                    newX += modificators.x;
                    newY += modificators.y;
                    if (newX >= 0 &&
                        newX < game.boardService.Board.Width &&
                        newY >= 0 &&
                        newY < game.boardService.Board.Height)
                    {
                        if (!game.assetService.IsAsset((newX, newY)))
                        {
                            placePossible = true;
                            newDaniel.X += modificators.x;
                            newDaniel.Y += modificators.y;
                        }
                    }
                } while (!placePossible);
            }
            game.assetManager.IntroduceAsset(newDaniel);
        }

    }
}
