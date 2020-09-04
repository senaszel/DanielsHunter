using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter.App.Concrete
{
    public class UpkeepPhaseService
    {
        private readonly Game game;
        public UpkeepPhaseService()
        {
        }
        public UpkeepPhaseService(Game game)
        {
            this.game = game;
        }
        public void Upkeep()
        {
            ManageCounters();
            game.gameStateManager.CheckIfStarved(game);
        }

        public void ManageCounters()
        {
            game.gameStateManager.AdvanceCounter(1);
            game.userService.User.Provisions -= 1;
        }
    }
}
