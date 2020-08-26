using DanielsHunter.Service;

namespace DanielsHunter.Model
{
    public class Game
    {
        public GameState gameState;
        public UserService userService;
        public ScreenService screenService;
        public BoardService boardService;
        public GameStateService gameStateService;
        public AssetService assetsService;

        public Game()
        {
            gameState = new GameState();
            userService = new UserService();
            screenService = new ScreenService();
            gameStateService = new GameStateService();
            boardService = new BoardService();
            assetsService = new AssetService();
        }

    }
}
