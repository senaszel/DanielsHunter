using System;

namespace DanielsHunter
{
     class Game
    {
        public  int TurnCounter { get; set; }
        public  string Outcome { get; set; }
        public Board Board { get; set; }
        public User User { get; set; }

        public Game()
        {
            TurnCounter = 0;
            Outcome = string.Empty;
            Board = new Board();
            User = new User();
        }
    }
}
