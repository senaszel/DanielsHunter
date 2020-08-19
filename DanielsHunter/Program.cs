using System;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            //BoardService testboardserv = new BoardService(new Board(height: 25, width: 50, offset: 10, new Screen(headerLength: 3, commStripLength: 4, viewLength: 25, footerLength: 3)));
            //ScreenService screenService = new ScreenService(testboardserv.Board.Screen);
            //screenService.GeneratePlayArea(testboardserv.Board);
            //string screen = screenService.GenerateScreen();
            //Console.WriteLine(screen);

            //Console.WriteLine("\t\t!!!!!!!!!!!!!");
            //Console.ReadKey();

            GameService newGameService = new GameService(new GameState());
            newGameService.Set();
            newGameService.Start();

            Common.Quit(ConsoleKey.Escape, 3);
        }
    }
}
