using DanielsHunter.Domain.Enum;

namespace DanielsHunter.Domain.Entity
{
    public class GameState : BaseEntity
    {
        public int TurnCounter { get; set; }
        public GameOutcomeEnum Outcome { get; set; }


        public GameState()
        {
            TurnCounter = 0;
            Outcome = GameOutcomeEnum.PENDING;
        }
    }
}
