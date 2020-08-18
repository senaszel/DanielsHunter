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
            Board = new Board(height: 25, width: 50, offset: 10, headerLength: 3, commStripLength: 4, viewLength: 25, footerLength: 3);
            User = new User();
        }
    }
}
