using System;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            GameService newGameService = new GameService(new GameState());
            newGameService.Set();
            newGameService.Start();

            Common.Quit(ConsoleKey.Escape, 3);
        }
    }
}
