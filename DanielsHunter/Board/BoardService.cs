using System;
using System.Linq;

namespace DanielsHunter
{
    public class BoardService
    {
        public Board Board { get; set; }

        public BoardService(Board board)
        {
            Board = board;
        }

        public Game GenerateUpperScreen(Game game)
        {
            Board.View[0] = "\r\n";
            Board.View[1] = (string.Concat(new string(' ', 20), "D A N I E L S   H U N T E R :"));

            string middle = game.Outcome == GameOutcome.PENDING ? "pending" : (game.Outcome == GameOutcome.LOOSE ? "You have Lost!" : "You Won!");
            Board.View[2] = $"\t\t\t\t{middle}";

            Board.View[3] = $"Provision's Left: {game.User.Provisions}\t\t\t\t\tAquired Meat: {game.User.Meat}";
            Board.View[4] = "\r\n";
            return game;
        }

        public Board GenerateLowerScreen()
        {
            Board.View = new string[Board.Height + 1];

            Console.WriteLine(string.Concat(Enumerable.Repeat("\r\n", Board.Offset)));
            for (int i = 5; i <= Board.Height; i++)
            {
                if (i == 5 || i == Board.Height)
                {
                    Board.View[i] = string.Concat(new string(' ', Board.Offset * 2), new string('#', Board.Width));
                }
                else
                {
                    Board.View[i] = string.Concat(new string(' ', Board.Offset * 2), '#', new string(' ', Board.Width - 2), '#');
                }
            }
            return Board;
        }

        public Board PlaceDaniel()
        {
            Random random = new Random();

            int danielX = random.Next(14, 57);
            int danielY = random.Next(6, 20);
            SymbolRepository symbolRepository = new SymbolRepository();
            foreach (string symbol in symbolRepository.Symbols)
            {
                if (Board.View[danielY].Substring(danielX, 1) != symbol)
                {
                    Board.View[danielY] = Board.View[danielY].Insert(danielX, "d").Remove(danielX + 1, 1);
                }
            };

            return Board;
        }

        public void Draw()
        {
            Console.CursorVisible = false;
            string scene = string.Join('\n', Board.View);
            Console.Write(scene);
        }
    }
}
