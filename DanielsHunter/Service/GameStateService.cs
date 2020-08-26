using DanielsHunter.Enum;
using DanielsHunter.Model;
using System;

namespace DanielsHunter.Service
{
    public class GameStateService
    {
        public GameState gameState;
        public GameStateService()
        {
        }
        public GameStateService(GameState gameState)
        {
            this.gameState = gameState;
        }

        public void AdvanceCounter(int time)
        {
            gameState.TurnCounter += time;
        }

        public void CheckIfEnoughCollected(Game game)
        {
            if (MeatCollectionCondition(game.userService.user.Meat))
            {
                gameState.Outcome = GameOutcome.WON;
                Common.QuitService.Quit(game.screenService, gameState, ConsoleKey.Escape, 3);
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
            if (CheckIfStarved(game.userService.user.Provisions))
            {
                gameState.Outcome = GameOutcome.LOST;
                Common.QuitService.Quit(game.screenService, gameState, ConsoleKey.Escape, 3);
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

        internal void HasDanielBeenCought(Game game)
        {
            if (!game.assetsService.IsAsset("Daniel"))
            {
                game.userService.user.Meat += 10;
                CheckIfEnoughCollected(game);
                game.userService.user.Provisions += 21;
                new TreeService().GrowTrees(game.screenService.screen.Board, game.userService.user);
                Daniel newDaniel = new Daniel();
                game.assetsService.AddToAssetRepository(newDaniel);
                new DanielService(newDaniel).PlaceDanielAtRandomPlaceOnTheBoard(game.screenService.screen.Board);
            }
        }
    }
}
