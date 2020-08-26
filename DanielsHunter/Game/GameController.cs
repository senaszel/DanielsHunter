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
        public AssetsRepository AssetsRepository;

        public GameController()
        {
            GameState = new GameState();
            UserService = new UserService();
            ScreenController = new ScreenController();
            GameStateController = new GameStateController();
            BoardController = new BoardController();
            AssetsRepository = new AssetsRepository();
        }

        public GameController Start()
        {
            ScreenController.ShowScreen();
            do
            {
                GameStateController.AdvanceCounter(1);
                UserService.User.Provisions -= 1;

                Console.Clear();

                GameStateController.CheckIfStarved();

                BoardController.PlaceAssetOnTheBoard(UserService.User);
                GameStateController.HasDanielBeenCought(this);

                ScreenController.GenerateUpperScreen(AssetsRepository);
                ScreenController.ShowScreen();

                BoardController.RemoveAssetFromTheBoard(UserService.User);
                PlayerInputService.GetPlayersInput(ScreenController.Screen, UserService.User);

            } while (GameState.Outcome == GameOutcome.PENDING) ;
            return this;
        }

        public GameController Set()
        {
            ScreenController = new ScreenController(new Screen(3, 4, 25, 3, new Board(25, 50, 8, AssetsRepository)));
            //ScreenController = new ScreenController(new Screen(3, 4, 25, 3, new Board(5, 5, 16, AssetsRepository)));
            UserService.User = new User()
            {
                Provisions = 101,
                Meat = 0,
                X = ScreenController.Screen.Board.Width / 2,
                Y = ScreenController.Screen.Board.Height / 2
            };
            AssetsRepository.AddToAssetRepository(UserService.User);
            Daniel daniel = new Daniel()
            {
                X = 0,
                Y = 0,
            };
            AssetsRepository.AddToAssetRepository(daniel);
            BoardController = new BoardController(ScreenController.Screen.Board);
            GameStateController = new GameStateController(this);

            ScreenController.InitialisePlayArea();
            new DanielController(daniel).PlaceDanielAtRandomPlaceOnTheBoard(ScreenController.Screen.Board);
            return this;
        }
    }
}

