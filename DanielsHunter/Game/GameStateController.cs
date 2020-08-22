using System;

namespace DanielsHunter.Game
{
    public class GameStateController
    {
        public void CheckIfEnoughCollected(GameController gameController)
        {
            if (MeatCollectionCondtition(gameController.UserService.User.Meat))
            {
                gameController.GameState.Outcome = GameOutcome.WON;
                Common.Quit(gameController.ScreenService, gameController.GameState, ConsoleKey.Escape, 3);
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

        public void CheckIfStarved(GameController gameController)
        {
            if (CheckIfStarved(gameController.UserService.User.Provisions))
            {
                gameController.GameState.Outcome = GameOutcome.LOST;
                Common.Quit(gameController.ScreenService, gameController.GameState, ConsoleKey.Escape, 3);
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
