using System;

namespace DanielsHunter
{
    class GameService
    {
        GameState GameState;
        UserService UserService;
        BoardService BoardService;
        ScreenService ScreenService;

        public GameService(GameState gameState)
        {
            GameState = gameState;
            UserService = new UserService(new User());
            BoardService = new BoardService(new Board(height: 25, width: 50, offset: 10, new Screen(headerLength: 3, commStripLength: 4, viewLength: 25, footerLength: 3)));
            ScreenService = new ScreenService(BoardService.Board.Screen);
        }
        public void Start()
        {

            ConsoleKey playersKeyInput = ConsoleKey.Enter;
            do
            {
                GameState.TurnCounter += 1;
                UserService.User.Provisions -= 1;

                Console.Clear();

                if (UserService.User.Meat == 300)
                {
                    GameState.Outcome = GameOutcome.WON;
                    playersKeyInput = ConsoleKey.Escape;
                }

                if (UserService.User.Provisions == 0)
                {
                    GameState.Outcome = GameOutcome.LOOSE;
                    playersKeyInput = ConsoleKey.Escape;
                }

                if (GameState.Outcome == GameOutcome.PENDING)
                {
                    //todo co tutaj robi podnoszenie przedmiotu przemyslec przeniesc w odpowiednie miejsce
                    if (BoardService.Board.Screen.PlayArea[UserService.User.UserY].Substring(UserService.User.UserX, 1) == "d")
                    {
                        UserService.User.Meat += 10;
                        UserService.User.Provisions += 21;
                        ScreenService.GenerateUpperScreen(UserService.User);
                        new DanielService().PlaceDaniel(BoardService.Board);
                        new TreeService().GrowTrees(BoardService.Board, UserService.User);
                    }
                    //BoardService.Board = UserService.ScratchLastPlayerPosition(BoardService.Board);
                    BoardService.Board = UserService.PlaceUserOnABoard(BoardService.Board);

                    BoardService.Board.Screen = ScreenService.GenerateUpperScreen(UserService.User);
                    ScreenService.GeneratePlayArea(BoardService.Board);
                    Console.WriteLine(ScreenService.GenerateScreen());

                    Console.ReadKey();

                    playersKeyInput = PlayerInputService.GetPlayersInput(BoardService.Board, UserService.User);
                }

            } while (playersKeyInput != ConsoleKey.Escape);
        }

        public void Set()
        {
            UserService.User = new User()
            {
                Provisions = 101,
                Meat = 0,
                UserX = BoardService.Board.Width / 2,
                UserY = BoardService.Board.Height / 2
            };
            BoardService.Board.Screen = ScreenService.GenerateUpperScreen(UserService.User);
            ScreenService.GeneratePlayArea(BoardService.Board);
            BoardService.Board = UserService.PlaceUserOnABoard(BoardService.Board);
            new DanielService().PlaceDaniel(BoardService.Board);
        }
    }
}

