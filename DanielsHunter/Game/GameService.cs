using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter
{
    class GameService
    {
        public void Start(Game game)
        {
            UserService userService = new UserService(game.User);
            BoardService boardService = new BoardService(game.Board);

            ConsoleKey exit;
            do
            {
                int Provisions = 100 - game.TurnCounter;
                game.TurnCounter++;

                Console.Clear();
                PlayerService.PrintUpperScreen(Provisions, game.User.Meat);

                if (Provisions == 0)
                {
                    game.Outcome = "Game Over!";
                    exit = ConsoleKey.Escape;
                }
                else
                {
                    game.Board = userService.Place(game);

                    boardService.Draw();
                    exit = Console.ReadKey(true).Key;
                }

                if (game.User.Meat == 300)
                {
                    game.Outcome = "You have Won!";
                    exit = ConsoleKey.Escape;
                }

                exit = PlayerService.GetPlayersInput(game, exit);

            } while (exit != ConsoleKey.Escape);
        }

        public User Set(Game game)
        {
            BoardService boardService = new BoardService(game.Board);
            game.User = new User()
            {
                Meat = 0,
                UserX = 25,
                UserY = 10
            };
            game.Board.View = boardService.Generate();
            boardService.PlaceDaniel();
            return game.User;
        }
    }
}

