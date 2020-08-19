namespace DanielsHunter
{
    public class GameState
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
