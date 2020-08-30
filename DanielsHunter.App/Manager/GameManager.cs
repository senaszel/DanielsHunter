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
                System.Console.Clear();
                game.screenManager.UpdateScreen(game);

                game.gameStateManager.AdvanceCounter(1);
                game.userService.User.Provisions -= 1;

                game.gameStateManager.CheckIfStarved(game);
                game.gameStateManager.HasDanielBeenCought(game);

                UserInputManager.GetPlayersInput(game);

            } while (game.gameState.Outcome == GameOutcome.PENDING);
            return this;
        }

        public GameManager Set()
        {
            Board board = new Board(25, 50, 8);
            Screen screen = new Screen(25, board);
            game.screenService.AddItem(screen);
            game.screenManager = new ScreenManager(game.screenService.Screen);
            game.boardService.AddItem(board);
            game.boardManager = new BoardManager(game.boardService.Board);

            User user = new User()
            {
                Provisions = 101,
                Meat = 0,
                X = game.boardService.Board.Width / 2,
                Y = game.boardService.Board.Height / 2
            };
            game.userService.AddItem(user);
            game.userActionManager = new UserActionManager(game.userService.User);
            game.assetService.AddToAssetRepository(game.userService.User);
            game.actionService = new ActionService(game.userService.User);

            game.gameStateManager = new GameStateManager(game.gameState);
            game.screenManager.InitialisePlayArea();
            new DanielManager(new Daniel()).PlaceDanielAtRandomPlaceOnTheBoard(game);
            return this;
        }
    }
}

