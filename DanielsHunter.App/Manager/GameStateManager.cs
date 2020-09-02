using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using System;
using DanielsHunter.Domain.Enum;

namespace DanielsHunter.App.Manager
{
    public class GameStateManager
    {
        private readonly GameState gameState;
        public GameStateManager()
        {
        }
        public GameStateManager(GameState gameState)
        {
            this.gameState = gameState;
        }

        public void AdvanceCounter(int time)
        {
            gameState.TurnCounter += time;
        }

        public void CheckIfEnoughCollected(Game game)
        {
            if (MeatCollectionCondition(game.userService.User.Meat))
            {
                game.screenManager.UpdateScreen(game);
                gameState.Outcome = GameOutcome.WON;
                QuitService.Quit(game, ConsoleKey.Escape, 3);
            }
        }

        private bool MeatCollectionCondition(int meat)
        {
            if (meat >= 300)
            {
                return true;
            }
            return false;
        }

        public void CheckIfStarved(Game game)
        {
            if (AreProvisionsZeroOrLess(game.userService.User.Provisions))
            {
                game.screenManager.UpdateScreen(game);
                gameState.Outcome = GameOutcome.LOST;
                QuitService.Quit(game, ConsoleKey.Escape, 3);
            }
        }

        private bool AreProvisionsZeroOrLess(int provisions)
        {
            if (provisions <= 0)
            {
                return true;
            }
            return false;
        }

        public void HasDanielBeenCought(Game game)
        {
            if (game.assetService.GetAsset("Daniel").Key == game.assetService.GetAsset("User").Key)
            {
                ScoreDaniel(game);
                game.screenManager.UpdateScreen(game);
            }
        }

        public void ScoreDaniel(Game game)
        {
            game.userService.User.Meat += 10;
            CheckIfEnoughCollected(game);
            game.userService.User.Provisions += 21;
            Daniel oldDaniel = (Daniel)game.assetService.GetAsset("Daniel");
            game.boardManager.RemoveSymbolFromPlayArea(oldDaniel.Key);
            game.assetService.RemoveFromAssets(oldDaniel);
            new TreeManager().GrowTreesAroundPlayer(game);
            Daniel newDaniel = new Daniel();
            game.assetService.AddToAssets(newDaniel);
            new DanielManager(newDaniel).PlaceDanielAtRandomPlaceOnTheBoard(game);
        }
    }
}
