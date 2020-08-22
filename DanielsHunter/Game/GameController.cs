using DanielsHunter.Game;
using System;

namespace DanielsHunter
{
    public class GameController
    {
        public GameState GameState;
        public UserService UserService;
        public ScreenController ScreenService;

        public GameController()
        {
            GameState = new GameState();
            UserService = new UserService(new User());
            ScreenService = new ScreenController(new Screen(3, 4, 25, 3, new Board(25, 50, 8)));
        }
        public void Start()
        {
            ScreenService.ShowScreen();
            ConsoleKey playersKeyInput = ConsoleKey.Enter;
            do
            {
                GameState.TurnCounter += 1;
                UserService.User.Provisions -= 1;

                Console.Clear();


                new GameStateController().CheckIfStarved(this);

                if (GameState.Outcome == GameOutcome.PENDING)
                {
                    //todo co tutaj robi podnoszenie przedmiotu przemyslec przeniesc w odpowiednie miejsce
                    if (ScreenService.Screen.Board.PlayArea[UserService.User.UserY].Substring(UserService.User.UserX, 1) == "d")
                    {
                        UserService.User.Meat += 10;
                        new GameStateController().CheckIfEnoughCollected(this);
                        UserService.User.Provisions += 21;
                        ScreenService.GenerateUpperScreen(UserService.User);
                        ScreenService.Update(new BoardService(ScreenService.Screen.Board).PlaceDaniel());
                        new TreeService().GrowTrees(ScreenService.Screen.Board, UserService.User);
                    }
                    ScreenService.Update(new BoardService(ScreenService.Screen.Board).PlaceUserOnABoard(UserService.User));
                    ScreenService.GenerateUpperScreen(UserService.User);
                    ScreenService.GenerateView();
                    ScreenService.ShowScreen();

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

