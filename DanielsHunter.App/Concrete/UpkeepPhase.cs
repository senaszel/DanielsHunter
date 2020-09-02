using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter.App.Concrete
{
    public class UpkeepPhase
    {
        private readonly Game game;
        public UpkeepPhase()
        {
        }
        public UpkeepPhase(Game game)
        {
            this.game = game;
        }
        internal void Conduct()
        {
            game.gameStateManager.AdvanceCounter(1);
            game.userService.User.Provisions -= 1;
            game.gameStateManager.CheckIfStarved(game);
        }
    }
}
