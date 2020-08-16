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
                case ConsoleKey.Escape:
                    break;
                default:
                    GetPlayersInput(game);
                    break;
            }

            return playersKeyInput;
        }

       

    }
}
