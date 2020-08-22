using System;

namespace DanielsHunter
{
    public class GameController
    {
        public GameState GameState;
        public UserService UserService;
        public ScreenController ScreenController;

        public GameController()
        {
            GameState = new GameState();
            UserService = new UserService(new User());
            ScreenController = new ScreenController(new Screen(3, 4, 25, 3, new Board(25, 50, 8)));
        }
        public GameController Start()
        {
            ScreenController.ShowScreen();
            ConsoleKey playersKeyInput = ConsoleKey.Enter;
            do
            {
                GameState.TurnCounter += 1;
                UserService.User.Provisions -= 1;

                Console.Clear();

                new GameStateController(this).CheckIfStarved();

                if (GameState.Outcome == GameOutcome.PENDING)
                {
                    //todo co tutaj robi podnoszenie przedmiotu przemyslec przeniesc w odpowiednie miejsce
                    if (ScreenController.Screen.Board.PlayArea[UserService.User.Y].Substring(UserService.User.X, 1) == "d")
                    {
                        UserService.User.Meat += 10;
                        new GameStateController(this).CheckIfEnoughCollected();
                        UserService.User.Provisions += 21;
                        ScreenController.GenerateUpperScreen(UserService.User);
                        new BoardService(ScreenController.Screen.Board).PlaceDaniel();
                        new TreeService().GrowTrees(ScreenController.Screen.Board, UserService.User);
                    }
                    new BoardService(ScreenController.Screen.Board).PlaceAssetOnABoard(UserService.User);
                    ScreenController.GenerateUpperScreen(UserService.User);
                    ScreenController.ShowScreen();

                    new BoardService(ScreenController.Screen.Board).RemoveAssetFromTheBoard(UserService.User);
                    playersKeyInput = PlayerInputService.GetPlayersInput(ScreenController.Screen.Board, UserService.User);
                }

            } while (playersKeyInput != ConsoleKey.Escape);
            return this;
        }



        public GameController Set()
        {
            UserService.User = new User()
            {
                Provisions = 101,
                Meat = 0,
                X = ScreenController.Screen.Board.Width / 2,
                Y = ScreenController.Screen.Board.Height / 2
            };
            ScreenController.GenerateUpperScreen(UserService.User);
            ScreenController.InitialisePlayArea();
            new BoardService(ScreenController.Screen.Board).PlaceAssetOnABoard(UserService.User);
            new BoardService(ScreenController.Screen.Board).PlaceDaniel();
            return this;
        }
    }
}

