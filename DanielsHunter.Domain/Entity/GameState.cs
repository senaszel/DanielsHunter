using DanielsHunter.Domain.Enum;

namespace DanielsHunter.Domain.Entity
{
    public class GameState : BaseEntity
    {
        public static bool Wait { get; set; }
        public int TurnCounter { get; set; }
        public GameOutcome Outcome { get; set; }


        public GameState()
        {
            Wait = false;
            TurnCounter = 0;
            Outcome = GameOutcome.PENDING;
        }
    }
}
