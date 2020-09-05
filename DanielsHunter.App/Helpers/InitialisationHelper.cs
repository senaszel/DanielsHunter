using DanielsHunter.App.Concrete;
using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;
using System;

namespace DanielsHunter.App.Helpers
{
    public class InitialisationHelper
    {
        public void Set(Game game)
        {
            Board board = new Board(25, 50, 8);
            //Board board = new Board(10, 10, 8);
            Screen screen = new Screen(board);
            game.screenService.AddItem(screen);
            game.screenManager = new ScreenManager(game.screenService.Screen);
            game.boardService.AddItem(board);
            game.boardManager = new BoardManager(game.boardService.Board);
            game.assetManager = new AssetManager(game.assetService, game.boardManager);
            game.upkeepPhaseService = new UpkeepPhaseService(game);
            game.userActionService = new UserActionService(game);
            User user = new User()
            {
                Provisions = 41,
                Meat = 0,
                X = game.boardService.Board.Width / 2,
                Y = game.boardService.Board.Height / 2
            };
            game.userService.AddItem(user);
            game.userActionManager = new UserActionManager(game.userService.User);
            game.assetService.AddToAssets(game.userService.User);
            game.actionService = new ActionService(game.userService.User);
            game.gameStateManager = new GameStateManager(game.gameState);
            new InitialisationHelper().InitialisePlayArea(game.screenService.Screen);
            new InitialisationHelper().InitialiseWithTrees(game.boardService, game.assetManager, 40);
            new DanielManager(new Daniel()).PlaceDanielAtRandomPlaceOnTheBoard(game);
            game.screenManager.UpdateScreen(game);
        }

        public void InitialisePlayArea(Screen screen)
        {
            int upperBoarder = 0;
            int lowerBoarder = screen.Board.Height + 1;
            for (int i = upperBoarder; i <= lowerBoarder; i++)
            {
                if (i == upperBoarder || i == lowerBoarder)
                {
                    screen.View[i] = string.Concat(new string(' ', screen.Board.Offset), new string('#', screen.Board.Width + 2));
                }
                else
                {
                    if (i <= screen.Board.Width)
                    {
                        screen.Board.PlayArea[i - 1] = new string(' ', screen.Board.Width);
                    }
                    screen.View[i] = string.Concat(new string(' ', screen.Board.Offset), '#', screen.Board.PlayArea[i - 1], '#');
                }
            }
        }

        public void InitialiseWithTrees(BoardService boardService, AssetManager assetManager, int numberOfTrees)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfTrees; i++)
            {
                int x = random.Next(boardService.Board.Width);
                int y = random.Next(boardService.Board.Height);
                Tree tree = new Tree("Tree-Created-OnInitialisation", x, y);
                assetManager.IntroduceAsset(tree);
            }
        }

    }
}

