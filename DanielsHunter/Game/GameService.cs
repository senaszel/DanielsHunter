using System;

namespace DanielsHunter
{
    class GameService
    {
        Game Game;

        public GameService(Game game)
        {
            Game = game;
        }
        public void Start()
        {
            UserService userService = new UserService(Game.User);
            BoardService boardService = new BoardService(Game.Board);

            ConsoleKey playersKeyInput = ConsoleKey.Enter;
            do
            {
                Game.TurnCounter += 1;
                Game.User.Provisions -= 1;

                Console.Clear();

                if (Game.User.Meat == 300)
                {
                    Game.Outcome = GameOutcome.WON;
                    playersKeyInput = ConsoleKey.Escape;
                }

                if (Game.User.Provisions == 0)
                {
                    Game.Outcome = GameOutcome.LOOSE;
                    playersKeyInput = ConsoleKey.Escape;
                }

                if (Game.Outcome == GameOutcome.PENDING)
                {
                    Game.Board = userService.Place(Game);
                    boardService.GenerateUpperScreen(Game);
                    boardService.DrawScreen();
                    playersKeyInput = PlayerInputService.GetPlayersInput(Game);
                }

            } while (playersKeyInput != ConsoleKey.Escape);
        }

        public Game Set()
        {
            BoardService boardService = new BoardService(Game.Board);
            Game.User = new User()
            {
                Provisions = 101,
                Meat = 0,
                UserX = Game.Board.Width/2,
                UserY = Game.Board.Height/2
            };
            boardService.GenerateUpperScreen(Game);
            Game.Board.PlayArea[Game.User.UserY] = Game.Board.PlayArea[Game.User.UserY].Insert(Game.User.UserX, "@").Remove(Game.User.UserX + 1, 1);
            Game.Board = boardService.DrawBoard();
            boardService.PlaceDaniel();
            return Game;
        }
    }
}

