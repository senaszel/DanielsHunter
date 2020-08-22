using System;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            GameController newGameService = new GameController();
            newGameService.Set();
            newGameService.Start();

        }
    }
}
