using System;

namespace DanielsHunter
{
    static class PlayerInputService
    {

        public static ConsoleKey GetPlayersInput(Board board, User user)
        {
            ConsoleKey playersKeyInput = Console.ReadKey(true).Key;

            switch (playersKeyInput)
            {
                case ConsoleKey.NumPad1:
                    if (user.UserX - 1 != 4 || user.UserY - 1 != 5)
                    {
                        if (board.Screen.View[user.UserY - 1].Substring(user.UserX - 1, 1) != "#") { user.UserY += 1; user.UserX -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad3:
                    if (user.UserX + 1 != 57 || user.UserY - 1 != 8)
                    {
                        if (board.Screen.View[user.UserY + 1].Substring(user.UserX - 1, 1) != "#") { user.UserY -= 1; user.UserX += 1; }
                    }
                    break;
                case ConsoleKey.NumPad8:
                    if (user.UserY - 1 != 0)
                    {
                        if (board.Screen.View[user.UserY - 1].Substring(user.UserX, 1) != "#") { user.UserY -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad2:
                    if (user.UserY + 1 != board.Height)
                    {
                        if (board.Screen.View[user.UserY + 1].Substring(user.UserX, 1) != "#") { user.UserY += 1; }
                    }
                    break;
                case ConsoleKey.NumPad7:
                    if (user.UserX - 1 != 8 || user.UserY + 1 != 5)
                    {
                        if (board.Screen.View[user.UserY + 1].Substring(user.UserX - 1, 1) != "#") { user.UserY -= 1; user.UserX -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad4:
                    if (user.UserX - 1 != 8)
                    {
                        if (board.Screen.View[user.UserY].Substring(user.UserX - 1, 1) != "#") { user.UserX -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad6:
                    if (user.UserX + 1 != 57)
                    {
                        if (board.Screen.View[user.UserY].Substring(user.UserX + 1, 1) != "#") { user.UserX += 1; }
                    }
                    break;
                case ConsoleKey.Escape:
                    break;
            }

            return playersKeyInput;
        }



    }
}
