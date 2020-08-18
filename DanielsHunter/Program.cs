using System;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            //MainMenu mainMenu = new MainMenu("MainMenu");
            //MenuService menuService = new MenuService(mainMenu);
            //menuService.ServeMenu();
            

            GameService newGameService = new GameService(new Game());
            newGameService.Set();
            newGameService.Start();

            Common.Quit(ConsoleKey.Escape, 3);
        }
    }
}
