using DanielsHunter.Enum;
using DanielsHunter.Model;

namespace DanielsHunter.Service
{
    public class GameService
    {
        private Game game;
        public GameService()
        {
            game = new Game();
        }
        public GameService(Game game)
        {
            this.game = game;
        }

        public GameService Start()
        {
            game.screenController.ShowScreen();
            do
            {
                System.Console.Clear();

                game.gameStateController.AdvanceCounter(1);
                game.userService.user.Provisions -= 1;

                game.gameStateController.CheckIfStarved(game);

                game.boardController.PlaceAssetOnTheBoard(game.userService.user);
                game.gameStateController.HasDanielBeenCought(game);

                game.screenController.GenerateUpperScreen(game.assetsRepository);
                game.screenController.ShowScreen();

                game.boardController.RemoveAssetFromTheBoard(game.userService.user);
                UserInputService.GetPlayersInput(game.screenController.screen, game.userService.user);

            } while (game.gameState.Outcome == GameOutcome.PENDING);
            return this;
        }

        public GameService Set()
        {
            game.screenController = new ScreenService(new Screen(3, 4, 25, 3, new Board(25, 50, 8, game.assetsRepository)));
            //ScreenController = new ScreenController(new Screen(3, 4, 25, 3, new Board(5, 5, 16, AssetsRepository)));
            game.userService.user = new User()
            {
                Provisions = 101,
                Meat = 0,
                X = game.screenController.screen.Board.Width / 2,
                Y = game.screenController.screen.Board.Height / 2
            };
            game.assetsRepository.AddToAssetRepository(game.userService.user);
            Daniel daniel = new Daniel()
            {
                X = 0,
                Y = 0,
            };
            game.assetsRepository.AddToAssetRepository(daniel);
            game.boardController = new BoardService(game.screenController.screen.Board);
            game.gameStateController = new GameStateService(game.gameState);

            game.screenController.InitialisePlayArea();
            new DanielService(daniel).PlaceDanielAtRandomPlaceOnTheBoard(game.screenController.screen.Board);
            return this;
        }
    }
}

