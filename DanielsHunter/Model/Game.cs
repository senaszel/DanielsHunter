using DanielsHunter.Service;

namespace DanielsHunter.Model
{
    public class Game
    {
        public GameState gameState;
        public UserService userService;
        public ScreenService screenController;
        public BoardService boardController;
        public GameStateService gameStateController;
        public AssetService assetsRepository;

        public Game()
        {
            gameState = new GameState();
            userService = new UserService();
            screenController = new ScreenService();
            gameStateController = new GameStateService();
            boardController = new BoardService();
            assetsRepository = new AssetService();
        }

    }
}
