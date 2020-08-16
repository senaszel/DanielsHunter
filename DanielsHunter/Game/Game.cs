namespace DanielsHunter
{
    public class Game
    {
        public int TurnCounter { get; set; }
        public GameOutcome Outcome { get; set; }
        public Board Board { get; set; }
        public User User { get; set; }

        public Game()
        {
            TurnCounter = 0;
            Outcome = GameOutcome.PENDING;
            Board = new Board();
            User = new User();
        }
    }
}
