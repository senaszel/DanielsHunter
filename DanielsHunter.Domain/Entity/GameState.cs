using DanielsHunter.Domain.Enum;

namespace DanielsHunter.Domain.Entity
{
    public class GameState : BaseEntity
    {
        public int TurnCounter { get; set; }
        public GameOutcome Outcome { get; set; }


        public GameState()
        {
            TurnCounter = 0;
            Outcome = GameOutcome.PENDING;
        }
    }
}
