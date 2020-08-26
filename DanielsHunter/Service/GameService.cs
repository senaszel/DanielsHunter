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
            game.screenService.ShowScreen();
            do
            {
                System.Console.Clear();

                game.gameStateService.AdvanceCounter(1);
                game.userService.user.Provisions -= 1;

                game.gameStateService.CheckIfStarved(game);

                game.boardService.PlaceAssetOnTheBoard(game.userService.user);
                game.gameStateService.HasDanielBeenCought(game);

                game.screenService.GenerateUpperScreen(game.assetsService);
                game.screenService.ShowScreen();

                game.boardService.RemoveAssetFromTheBoard(game.userService.user);
                UserInputService.GetPlayersInput(game.screenService.screen,game.userService.user);

            } while (game.gameState.Outcome == GameOutcome.PENDING);
            return this;
        }

        public GameService Set()
        {
            game.screenService = new ScreenService(new Screen(25, new Board(25, 50, 8, game.assetsService)));
            //ScreenController = new ScreenController(new Screen(3, 4, 25, 3, new Board(5, 5, 16, AssetsRepository)));
            game.userService.user = new User()
            {
                Provisions = 101,
                Meat = 0,
                X = game.screenService.screen.Board.Width / 2,
                Y = game.screenService.screen.Board.Height / 2
            };
            game.assetsService.AddToAssetRepository(game.userService.user);
            game.boardService = new BoardService(game.screenService.screen.Board);
            game.gameStateService = new GameStateService(game.gameState);

            game.screenService.InitialisePlayArea();
            new DanielService(new Daniel()).PlaceDanielAtRandomPlaceOnTheBoard(game.screenService.screen.Board);
            return this;
        }
    }
}

