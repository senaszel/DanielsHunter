using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using System;
using DanielsHunter.Domain.Enum;

namespace DanielsHunter.App.Manager
{
    public class GameStateManager 
    {
        private GameState gameState;
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
            if (MeatCollectionCondition(game.userActionManager.user.Meat))
            {
                game.screenManager.GenerateUpperScreen(game.assetService);
                game.screenManager.ShowScreen();
                gameState.Outcome = GameOutcome.WON;
                QuitService.Quit(game.screenManager, gameState, ConsoleKey.Escape, 3);
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
            if (AreProvisionsZeroOrLess(game.userActionManager.user.Provisions))
            {
                game.screenManager.GenerateUpperScreen(game.assetService);
                game.screenManager.ShowScreen();
                gameState.Outcome = GameOutcome.LOST;
                QuitService.Quit(game.screenManager, gameState, ConsoleKey.Escape, 3);
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

        internal void HasDanielBeenCought(Game game)
        {
            var oldDaniel = game.assetService.GetAsset("Daniel");
            var danielKey = oldDaniel.Key;
            var userKey = game.assetService.GetAsset("User").Key;
            if (danielKey == userKey)
            {
                game.userActionManager.user.Meat += 10;
                CheckIfEnoughCollected(game);
                game.userActionManager.user.Provisions += 21;
                game.assetService.RemoveFromAssetsRepository(oldDaniel);
                new TreeManager().GrowTrees(game);
                Daniel newDaniel = new Daniel();
                game.assetService.AddToAssetRepository(newDaniel);
                new DanielManager(newDaniel).PlaceDanielAtRandomPlaceOnTheBoard(game);
            }
        }
    }
}
