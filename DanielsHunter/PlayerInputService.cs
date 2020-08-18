using System;

namespace DanielsHunter
{
    static class PlayerInputService
    {

        public static ConsoleKey GetPlayersInput(Game game)
        {
            ConsoleKey playersKeyInput = Console.ReadKey(true).Key;

            switch (playersKeyInput)
            {
                case ConsoleKey.NumPad1:
                    if (game.User.UserX - 1 != 4 || game.User.UserY - 1 != 5)
                    {
                        if (game.Board.View[game.User.UserY - 1].Substring(game.User.UserX - 1, 1) != "#") { game.User.UserY += 1; game.User.UserX -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad3:
                    if (game.User.UserX + 1 != 57 || game.User.UserY - 1 != 8)
                    {
                        if (game.Board.View[game.User.UserY + 1].Substring(game.User.UserX - 1, 1) != "#") { game.User.UserY -= 1; game.User.UserX += 1; }
                    }
                    break;
                case ConsoleKey.NumPad8:
                    if (game.User.UserY - 1 != 0)
                    {
                        if (game.Board.View[game.User.UserY - 1].Substring(game.User.UserX, 1) != "#") { game.User.UserY -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad2:
                    if (game.User.UserY + 1 != game.Board.Height)
                    {
                        if (game.Board.View[game.User.UserY + 1].Substring(game.User.UserX, 1) != "#") { game.User.UserY += 1; }
                    }
                    break;
                case ConsoleKey.NumPad7:
                    if(game.User.UserX-1 !=8 || game.User.UserY+1 != 5)
                    {
                        if (game.Board.View[game.User.UserY + 1].Substring(game.User.UserX-1, 1) != "#") { game.User.UserY -= 1; game.User.UserX -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad4:
                    if (game.User.UserX - 1 != 8)
                    {
                        if (game.Board.View[game.User.UserY].Substring(game.User.UserX - 1, 1) != "#") { game.User.UserX -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad6:
                    if (game.User.UserX + 1 != 57)
                    {
                        if (game.Board.View[game.User.UserY].Substring(game.User.UserX + 1, 1) != "#") { game.User.UserX += 1; }
                    }
                    break;
                case ConsoleKey.Escape:
                    break;
            }

            return playersKeyInput;
        }

       

    }
}
