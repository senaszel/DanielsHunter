using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;

namespace DanielsHunter.App.Manager
{
    public class GameManager
    {
        private readonly Game game;
        public GameManager()
        {
            game = new Game();
        }
        public GameManager(Game game)
        {
            this.game = game;
        }

        public GameManager Run()
        {
            do
            {
                UserInputManager.GetPlayersInput(game);
                                game.upkeepPhase.Conduct();

            } while (game.gameState.Outcome == GameOutcome.PENDING);
            return this;
        }

        public GameManager Set()
        {
            Board board = new Board(25, 50, 8);
            //Board board = new Board(10, 10, 8);
            Screen screen = new Screen(board);
            game.screenService.AddItem(screen);
            game.screenManager = new ScreenManager(game.screenService.Screen);
            game.boardService.AddItem(board);
            game.boardManager = new BoardManager(game.boardService.Board);
            game.assetManager = new AssetManager(game);
            game.upkeepPhase = new UpkeepPhase(game);
            User user = new User()
            {
                Provisions = 101,
                Meat = 0,
                X = game.boardService.Board.Width / 2,
                Y = game.boardService.Board.Height / 2
            };
            game.userService.AddItem(user);
            game.userActionManager = new UserActionManager(game.userService.User);
            game.assetService.AddToAssets(game.userService.User);
            game.actionService = new ActionService(game.userService.User);

            game.gameStateManager = new GameStateManager(game.gameState);
            game.screenManager.InitialisePlayArea();
            game.assetManager.InitialiseWithTrees(game.boardService,40);
            new DanielManager(new Daniel()).PlaceDanielAtRandomPlaceOnTheBoard(game);
            game.screenManager.UpdateScreen(game);
            return this;
        }
    }
}

