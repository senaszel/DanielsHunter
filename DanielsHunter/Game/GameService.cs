using System;

namespace DanielsHunter
{
    class GameService
    {
        public void Start(Game game)
        {
            UserService userService = new UserService(game.User);
            BoardService boardService = new BoardService(game.Board);

            ConsoleKey playersKeyInput = ConsoleKey.Enter;
            do
            {
                game = boardService.GenerateUpperScreen(game);
                boardService.Draw();

                game.TurnCounter += 1;
                game.User.Provisions -= 1;

                Console.Clear();

                if (game.User.Meat == 300)
                {
                    game.Outcome = GameOutcome.WON;
                    //game.Board = PlayerService.GenerateUpperScreen(game);
                    playersKeyInput = ConsoleKey.Escape;
                }

                if (game.User.Provisions == 0)
                {
                    game.Outcome = GameOutcome.LOOSE;
                    //game.Board = PlayerService.GenerateUpperScreen(game);
                    playersKeyInput = ConsoleKey.Escape;
                }

                if (game.Outcome == GameOutcome.PENDING)
                {
                    game.Board = userService.Place(game);
                    game = boardService.GenerateUpperScreen(game);
                    boardService.Draw();
                    playersKeyInput = PlayerInputService.GetPlayersInput(game);
                }

            } while (playersKeyInput != ConsoleKey.Escape);
        }

        public Game Set(Game game)
        {
            BoardService boardService = new BoardService(game.Board);
            game.User = new User()
            {
                Provisions = 101,
                Meat = 0,
                UserX = 25,
                UserY = 10
            };
            game = boardService.GenerateUpperScreen(game);
            game.Board = boardService.GenerateLowerScreen();
            boardService.PlaceDaniel();
            return game;
        }
    }
}

