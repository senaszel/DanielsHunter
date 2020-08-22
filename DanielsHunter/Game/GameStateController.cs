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


    }
}
