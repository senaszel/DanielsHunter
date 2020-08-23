using System;

namespace DanielsHunter
{
    static class PlayerInputService
    {

        public static ConsoleKey GetPlayersInput(Screen screen, User user,AssetsRepository assetsRepository)
        {
            var board = screen.Board;
            var playArea = board.PlayArea;
            var y = user.Y;
            var x = user.X;
            ConsoleKey playersKeyInput = Console.ReadKey(true).Key;

            switch (playersKeyInput)
            {
                case ConsoleKey.NumPad1:
                    if ((x - 1 >= 0) && (y + 1 < board.Height))
                    {
                        if (playArea[y + 1].Substring(x - 1, 1) != "#") { x -= 1; y += 1; }
                    }
                    break;
                case ConsoleKey.NumPad2:
                    if (y + 1 < board.Height)
                    {
                        if (playArea[y + 1].Substring(x, 1) != "#") { y += 1; }
                    }
                    break;
                case ConsoleKey.NumPad3:
                    if ((x + 1 < board.Width) && (y + 1 < board.Height))
                    {
                        if (playArea[y + 1].Substring(x + 1, 1) != "#") { x += 1; y += 1; }
                    }
                    break;
                case ConsoleKey.NumPad4:
                    if (x - 1 >= 0)
                    {
                        if (playArea[y].Substring(x - 1, 1) != "#") { x -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad6:
                    if (x + 1 < board.Width)
                    {
                        if (playArea[y].Substring(x + 1, 1) != "#") { x += 1; }
                    }
                    break;
                case ConsoleKey.NumPad7:
                    if ((x - 1 >= 0) && (y - 1 >= 0))
                    {
                        if (playArea[y - 1].Substring(x - 1, 1) != "#") { x -= 1; y -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad8:
                    if (y - 1 >= 0)
                    {
                        if (playArea[y - 1].Substring(x, 1) != "#") { y -= 1; }
                    }
                    break;
                case ConsoleKey.NumPad9:
                    if ((x + 1 < board.Width) && (y - 1 >= 0))
                    {
                        if (playArea[y - 1].Substring(x + 1, 1) != "#") { x += 1; y -= 1; }
                    }
                    break;
                case ConsoleKey.Escape:
                    break;
                case ConsoleKey.NumPad5:
                      new UserActionController(user).ChopTree(board,assetsRepository);
                    break;
                default:
                    GetPlayersInput(screen, user,assetsRepository);
                    break;
            }
            user.X = x;
            user.Y = y;
            return playersKeyInput;
        }

    }
}
