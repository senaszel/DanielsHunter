using DanielsHunter.App.Concrete;
using DanielsHunter.App.Helpers;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;

namespace DanielsHunter.App.Manager
{
    public class GameManager
    {
        private readonly Game game;
        public GameManager()
        {
            game = new Game();
        }
        public GameManager(Game game)
        {
            this.game = game;
        }

        public GameManager Run()
        {
            do
            {
                UserInputManager.GetPlayersInput(game);
                game.userActionService.PerformUserAction();
                game.upkeepPhaseService.Upkeep();
                game.screenManager.UpdateScreen(game);

            } while (game.gameState.Outcome == GameOutcomeEnum.PENDING);
            return this;
        }

    }
}

