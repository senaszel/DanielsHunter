using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Concrete
{
    public class Game : BaseEntity
    {
        public AssetService assetService;
        public GameState gameState;
        public GameStateManager gameStateManager;
        public UserService userService;
        public UserActionManager userActionManager;
        public BoardService boardService;
        public BoardManager boardManager;
        public ScreenService screenService;
        public ScreenManager screenManager;

        public Game()
        {
            gameState = new GameState();
            userActionManager = new UserActionManager();
            screenService = new ScreenService();
            screenManager = new ScreenManager();
            gameStateManager = new GameStateManager();
            boardManager = new BoardManager();
            assetService = new AssetService();
            userService = new UserService();
            boardService = new BoardService();
        }

    }
}
