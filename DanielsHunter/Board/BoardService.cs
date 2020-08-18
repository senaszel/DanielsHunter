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

        public void GenerateUpperScreen(Game game)
        {
            Board.Header[0] = "\r\n";
            Board.Header[1] = (string.Concat(new string(' ', 20), "D A N I E L S   H U N T E R :"));
            Board.Header[2] = "\r\n";

            Board.CommStrip[0] = "\r\n";
            Board.CommStrip[1] = $"\t\t\t\tX : {game.User.UserX}\tY : {game.User.UserY}";
            Board.CommStrip[2] = $"Provision's Left: {game.User.Provisions}\t\t\t\t\tAquired Meat: {game.User.Meat}";
            Board.CommStrip[3] = "\r\n";
        }

        public Board DrawBoard()
        {
            int upperBoarder = 0;
            int lowerBoarder = Board.View.Length;
            for (int i = upperBoarder; i < lowerBoarder; i++)
            {
                if (i == upperBoarder || i == lowerBoarder - 1)
                {
                    Board.View[i] = string.Concat(new string(' ', Board.Offset), new string('#', Board.Width + 2));
                }
                else
                {
                    Board.PlayArea[i - 1] = new string(' ', Board.Width);
                    Board.View[i] = string.Concat(new string(' ', Board.Offset), '#', Board.PlayArea[i - 1], '#');
                }
            }
            return Board;
        }

        public void PlaceDaniel()
        {
            Random random = new Random();

            int danielX = random.Next(0, Board.Width + 1);
            int danielY = random.Next(0, Board.Height + 1);
            SymbolRepository symbolRepository = new SymbolRepository();
            foreach (string symbol in symbolRepository.Symbols)
            {
                if (Board.View[danielY].Substring(danielX, 1) != symbol)
                {
                    Board.View[danielY] = Board.View[danielY].Insert(danielX, "d").Remove(danielX + 1, 1);
                }
            };
        }

        public void DrawScreen()
        {
            Console.CursorVisible = false;
            string screen = string.Concat(string.Join('\n', Board.Header), string.Join('\n', Board.CommStrip), string.Join('\n', Board.View), string.Join('\n', Board.Footer));
            Console.Write(screen);
        }
    }
}
