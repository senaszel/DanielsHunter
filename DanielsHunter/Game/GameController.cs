using System;

namespace DanielsHunter
{
    public class GameController
    {
        public GameState GameState;
        public UserService UserService;
        public ScreenController ScreenController;
        public BoardController BoardController;
        public GameStateController GameStateController;

        public GameController()
        {
            GameState = new GameState();
            UserService = new UserService();
            ScreenController = new ScreenController();
            BoardController = new BoardController();
            GameStateController = new GameStateController();
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

                GameStateController.CheckIfStarved();

                if (GameState.Outcome == GameOutcome.PENDING)
                {
                    //todo co tutaj robi podnoszenie przedmiotu przemyslec przeniesc w odpowiednie miejsce
                    if (ScreenController.Screen.Board.PlayArea[UserService.User.Y].Substring(UserService.User.X, 1) == "d")
                    {
                        UserService.User.Meat += 10;
                        GameStateController.CheckIfEnoughCollected();
                        UserService.User.Provisions += 21;
                        BoardController.PlaceDanielAtRandomPlaceOnTheBoard();
                        new TreeService().GrowTrees(ScreenController.Screen.Board, UserService.User);
                    }
                    BoardController.PlaceAssetOnABoard(UserService.User);
                    ScreenController.GenerateUpperScreen(UserService.User);
                    ScreenController.ShowScreen();

                    BoardController.RemoveAssetFromTheBoard(UserService.User);
                    playersKeyInput = PlayerInputService.GetPlayersInput(ScreenController.Screen, UserService.User);
                }

            } while (playersKeyInput != ConsoleKey.Escape);
            return this;
        }



        public GameController Set()
        {
            ScreenController = new ScreenController(new Screen(3, 4, 25, 3, new Board(25, 50, 8)));
            UserService.User = new User()
            {
                Provisions = 101,
                Meat = 0,
                X = ScreenController.Screen.Board.Width / 2,
                Y = ScreenController.Screen.Board.Height / 2
            };
            BoardController = new BoardController(ScreenController.Screen.Board);
            GameStateController = new GameStateController(this);

            ScreenController.InitialisePlayArea();
            BoardController.PlaceAssetOnABoard(UserService.User);
            BoardController.PlaceDanielAtRandomPlaceOnTheBoard();
            return this;
        }
    }
}

