using System;

namespace DanielsHunter
{
    class GameService
    {
        GameState GameState;
        UserService UserService;
        ScreenService ScreenService;

        public GameService(GameState gameState)
        {
            GameState = gameState;
            UserService = new UserService(new User());
            ScreenService = new ScreenService(new Screen(3, 4, 25, 3, new Board(25, 50, 8)));
        }
        public void Start()
        {
            Console.CursorVisible = false;
            Console.WriteLine(ScreenService.ShowScreen());
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
                    if (ScreenService.Screen.Board.PlayArea[UserService.User.UserY].Substring(UserService.User.UserX, 1) == "d")
                    {
                        UserService.User.Meat += 10;
                        UserService.User.Provisions += 21;
                        ScreenService.GenerateUpperScreen(UserService.User);
                        ScreenService.Update(new BoardService(ScreenService.Screen.Board).PlaceDaniel());
                        new TreeService().GrowTrees(ScreenService.Screen.Board, UserService.User);
                    }
                    ScreenService.Update(new BoardService(ScreenService.Screen.Board).PlaceUserOnABoard(UserService.User));
                    ScreenService.GenerateUpperScreen(UserService.User);
                    ScreenService.GenerateView();
                    Console.WriteLine(ScreenService.ShowScreen());

                    ScreenService.Update(new BoardService(ScreenService.Screen.Board).ScratchLastPlayerPosition(UserService.User));
                    playersKeyInput = PlayerInputService.GetPlayersInput(ScreenService.Screen.Board, UserService.User);
                }

            } while (playersKeyInput != ConsoleKey.Escape);
        }

        public void Set()
        {
            UserService.User = new User()
            {
                Provisions = 101,
                Meat = 0,
                UserX = ScreenService.Screen.Board.Width / 2,
                UserY = ScreenService.Screen.Board.Height / 2
            };
            ScreenService.GenerateUpperScreen(UserService.User);
            ScreenService.InitialisePlayArea();
            ScreenService.Update(new BoardService(ScreenService.Screen.Board).PlaceUserOnABoard(UserService.User));
            ScreenService.Update(new BoardService(ScreenService.Screen.Board).PlaceDaniel());
        }
    }
}

