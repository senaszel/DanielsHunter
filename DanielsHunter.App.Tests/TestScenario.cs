using DanielsHunter.App.Concrete;
using DanielsHunter.App.Helpers;
using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using Moq;

namespace DanielsHunter.App.Tests
{
    public class TestScenario
    {
        private Game game;
        public TestScenario()
        {
            game = new Game();
        }
        public TestScenario(Game game)
        {
            this.game = game;
        }
        public Game PrepareTestScenario1()
        {
            Board board = new Mock<Board>(5, 5, 5).Object;
            game.boardService = new Mock<BoardService>().Object;
            game.boardService.AddItem(board);
            game.boardManager = new Mock<BoardManager>(board).Object;
            game.screenService = new Mock<ScreenService>().Object;
            game.screenService.AddItem(new Mock<Screen>(board).Object); 
            game.screenManager = new Mock<ScreenManager>(game.screenService.GetFirstItem()).Object;
            InitialisationHelper initialisationHelper = new Mock<InitialisationHelper>().Object;
            initialisationHelper.InitialisePlayArea(game.screenService.Screen);
            User user = new Mock<User>(10, 10, 1, 1).Object;
            game.userService = new Mock<UserService>().Object;
            game.userService.AddItem(user);
            Daniel daniel = new Mock<Daniel>(1, 1).Object;
            game.assetService = new Mock<AssetService>().Object;
            game.assetService.AddItem(user);
            game.assetService.AddItem(daniel);
            game.assetManager = new Mock<AssetManager>(game.assetService, game.boardManager).Object;
            game.upkeepPhaseService = new Mock<UpkeepPhaseService>(this.game).Object;
            game.gameState.TurnCounter = 1;
            game.gameStateManager = new Mock<GameStateManager>(game.gameState).Object;
            return game;
        }
    }
}
