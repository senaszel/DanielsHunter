using System;
using System.Collections.Generic;

namespace DanielsHunter
{
    class BoardService
    {
        public Board Board { get; set; }

        public BoardService(Board board)
        {
            Board = board;
        }

        public string[] Generate()
        {
            Board.View = new string[Board.Height + 1];

            Console.WriteLine(string.Concat(System.Linq.Enumerable.Repeat("\r\n", Board.Offset)));
            for (int i = 0; i <= Board.Height; i++)
            {
                if (i == 0 || i == Board.Height)
                {
                    Board.View[i] = string.Concat(new string(' ', Board.Offset * 2), new string('#', Board.Width));
                }
                else
                {
                    Board.View[i] = string.Concat(new string(' ', Board.Offset * 2), '#', new string(' ', Board.Width - 2), '#');
                }
            }
            return Board.View;
        }

        public string[] PlaceDaniel()
        {
            Random random = new Random();

            int danielX = random.Next(9, 57);
            int danielY = random.Next(1, 20);
            if (Board.View[danielY].Substring(danielX, 1) != "@" || Board.View[danielY].Substring(danielX, 1) != "#")
            {
                Board.View[danielY] = Board.View[danielY].Insert(danielX, "d").Remove(danielX + 1, 1);
            }
            else PlaceDaniel();

            return Board.View;
        }

        public Board GrowTrees(int userX, int userY)
        {
            Board.View[userY - 1] = Board.View[userY - 1].Insert(userX - 1, "#").Remove(userX, 1);
            Board.View[userY + 1] = Board.View[userY + 1].Insert(userX - 1, "#").Remove(userX, 1);

            Board.View[userY - 1] = Board.View[userY - 1].Insert(userX + 1, "#").Remove(userX + 2, 1);
            Board.View[userY + 1] = Board.View[userY + 1].Insert(userX + 1, "#").Remove(userX + 2, 1);
            return Board;
        }

        public void Draw()
        {
            for (int i = 0; i < Board.View.Length; i++)
            {
                Console.WriteLine(Board.View[i]);
            }
        }
    }
}
