using System;

namespace DanielsHunter
{
    static class Game
    {
        public static int TurnCounter { get; set; }
        public static string[] View { get; set; }
        public static string Outcome { get; set; }


        public static void Start()
        {
            ConsoleKey exit;
            do
            {
                TurnCounter++;
                int Provisions = 100 - TurnCounter;

                Console.Clear();
                Console.WriteLine("\r\n");
                Console.WriteLine(string.Concat(new string(' ',20),"D A N I E L S   H U N T E R :"));
                Console.WriteLine("\r\n");
                Console.WriteLine($"Provision's Left: {Provisions}\t\t\t\t\tAquired Meat: {User.Meat}");
                Console.WriteLine("\r\n");
                if (Provisions == 0)
                {
                    Outcome = "Game Over!";
                    exit = ConsoleKey.Escape;
                }
                else
                {
                    View = User.Place(View);
                    Board.Draw(View);
                    exit = Console.ReadKey(true).Key;

                }

                if (User.Meat == 300)
                {
                    Outcome = "You have Won!";
                    exit = ConsoleKey.Escape;
                }

                switch (exit)
                {
                    case ConsoleKey.UpArrow:
                        if (User.UserY - 1 != 0)
                        {
                            if (View[User.UserY - 1].Substring(User.UserX, 1) != "#") { User.UserY -= 1; }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (User.UserY + 1 != Board.Height)
                        {
                            if (View[User.UserY + 1].Substring(User.UserX, 1) != "#") { User.UserY += 1; }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (User.UserX - 1 != 8)
                        {
                            if (View[User.UserY].Substring(User.UserX - 1, 1) != "#") { User.UserX -= 1; }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (User.UserX + 1 != 57)
                        {
                            if (View[User.UserY].Substring(User.UserX + 1, 1) != "#") { User.UserX += 1; }
                        }
                        break;
                    default:
                        break;
                }

            } while (exit != ConsoleKey.Escape);
        }


        public static void Set()
        {
            View = Board.Generate();
            Board.PlaceDaniel();
            User.UserY = 10;
            User.UserX = 25;
        }

    }
}
