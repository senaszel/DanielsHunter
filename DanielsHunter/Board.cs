using System;
using System.Linq;

namespace DanielsHunter
{
    static class Board
    {
        public static int Height { get => 20; }
        public static int Width { get => 50; }
        static int Offset { get => 4; }


        static string[] View { get; set; }

        public static string[] Generate()
        {
            View = new string[Height + 1];

            Console.WriteLine(string.Concat(Enumerable.Repeat("\r\n", Offset)));
            for (int i = 0; i <= Height; i++)
            {
                if (i == 0 || i == Height)
                {
                    View[i] = string.Concat(new string(' ', Offset * 2), new string('#', Width));
                }
                else
                {
                    View[i] = string.Concat(new string(' ', Offset * 2), '#', new string(' ', Width - 2), '#');
                }
            }
            return View;
        }

        public static string[] PlaceDaniel()
        {
            Random random = new Random();

            int treasureX = random.Next(9, 57);
            int treasureY = random.Next(1, 20);
            if (View[treasureY].Substring(treasureX, 1) != "@" || View[treasureY].Substring(treasureX, 1) != "#")
            {
                View[treasureY] = View[treasureY].Insert(treasureX, "d").Remove(treasureX + 1, 1);
            }
            else PlaceDaniel();

            return View;
        }

        internal static string[] GrowTrees(string[] view, int userX, int userY)
        {
            view[userY - 1] = view[userY - 1].Insert(userX - 1, "#").Remove(userX + 1, 1);
            view[userY + 1] = view[userY + 1].Insert(userX - 1, "#").Remove(userX + 1, 1);

            view[userY - 1] = view[userY - 1].Insert(userX + 1, "#").Remove(userX + 2, 1);
            view[userY + 1] = view[userY + 1].Insert(userX + 1, "#").Remove(userX + 2, 1);
            return view;
        }

        public static void Draw(string[] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                Console.WriteLine(board[i]);
            }
        }


    }
}