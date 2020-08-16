using System;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            MainMenu mainMenu = new MainMenu("MainMenu");
            MenuService menuService = new MenuService(mainMenu);
            menuService.ServeMenu();
            
            Console.ReadKey();
            Console.WriteLine("zjebałes");
            Console.ReadKey();

            Console.CursorVisible = false;

            Game newGame = new Game();
            GameService newGameService = new GameService();
            newGame = newGameService.Set(newGame);
            newGameService.Start(newGame);

            int exit3 = 0;
            ConsoleKey exit;
            do
            {
                Console.Clear();
                Console.WriteLine($"\t\t{newGame.Outcome}");
                Console.WriteLine($"\t3 x Escape to Quit");
                exit = Console.ReadKey().Key;
                if (exit == ConsoleKey.Escape) { exit3 += 1; }

            } while (exit3 < 3);
        }
    }
}
