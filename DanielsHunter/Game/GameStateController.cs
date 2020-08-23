using System;

namespace DanielsHunter
{
    public class GameStateController
    {
        private readonly GameController GameController;
        public GameStateController()
        {

        }
        public GameStateController(GameController gameController)
        {
            GameController = gameController;
        }

        public void AdvanceCounter(int time)
        {
            GameController.GameState.TurnCounter += time;
        }

        public void CheckIfEnoughCollected()
        {
            if (MeatCollectionCondtition(GameController.UserService.User.Meat))
            {
                GameController.GameState.Outcome = GameOutcome.WON;
                Common.Quit(GameController.ScreenController, GameController.GameState, ConsoleKey.Escape, 3);
            }
        }

        private bool MeatCollectionCondtition(int meat)
        {
            if (meat >= 300)
            {
                return true;
            }
            return false;
        }

        public void CheckIfStarved()
        {
            if (CheckIfStarved(GameController.UserService.User.Provisions))
            {
                GameController.GameState.Outcome = GameOutcome.LOST;
                Common.Quit(GameController.ScreenController, GameController.GameState, ConsoleKey.Escape, 3);
            }
        }

        private bool CheckIfStarved(int provisions)
        {
            if (provisions <= 0)
            {
                return true;
            }
            return false;
        }

        internal void HasDanielBeenCought(GameController gameController)
        {
            //if (gameController.ScreenController.Screen.Board.PlayArea[gameController.UserService.User.Y].Substring(gameController.UserService.User.X, 1) == "d")
            if (!gameController.AssetsRepository.IsAsset("Daniel"))
            {
                gameController.UserService.User.Meat += 10;
                gameController.GameStateController.CheckIfEnoughCollected();
                gameController.UserService.User.Provisions += 21;
                new TreeController().GrowTrees(gameController.ScreenController.Screen.Board, gameController.UserService.User);
                Daniel newDaniel = new Daniel();
                gameController.AssetsRepository.AddToAssetRepository(newDaniel);
                new DanielController(newDaniel).PlaceDanielAtRandomPlaceOnTheBoard(gameController.ScreenController.Screen.Board);
            }
        }
    }
}
