using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter
{
    class PlayerService
    {

        public static ConsoleKey GetPlayersInput(Game game, ConsoleKey exit)
        {
            switch (exit)
            {
                case ConsoleKey.UpArrow:
                    if (game.User.UserY - 1 != 0)
                    {
                        if (game.Board.View[game.User.UserY - 1].Substring(game.User.UserX, 1) != "#") { game.User.UserY -= 1; }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (game.User.UserY + 1 != game.Board.Height)
                    {
                        if (game.Board.View[game.User.UserY + 1].Substring(game.User.UserX, 1) != "#") { game.User.UserY += 1; }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (game.User.UserX - 1 != 8)
                    {
                        if (game.Board.View[game.User.UserY].Substring(game.User.UserX - 1, 1) != "#") { game.User.UserX -= 1; }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (game.User.UserX + 1 != 57)
                    {
                        if (game.Board.View[game.User.UserY].Substring(game.User.UserX + 1, 1) != "#") { game.User.UserX += 1; }
                    }
                    break;
                default:
                    break;
            }
            return exit;
        }

        public static void PrintUpperScreen(int Provisions, int Meat)
        {
            Console.WriteLine("\r\n");
            Console.WriteLine(string.Concat(new string(' ', 20), "D A N I E L S   H U N T E R :"));
            Console.WriteLine("\r\n");
            Console.WriteLine($"Provision's Left: {Provisions}\t\t\t\t\tAquired Meat: {Meat}");
            Console.WriteLine("\r\n");
        }

    }
}
