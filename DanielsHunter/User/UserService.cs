namespace DanielsHunter
{
    class UserService
    {
        public User User { get; set; }

        public UserService(User user)
        {
            User = user;
        }

        public Board Place(Game game)
        {
            BoardService boardService = new BoardService(game.Board);
            TreeService treeService = new TreeService();

            if (game.Board.View[User.UserY].Substring(User.UserX, 1) == "d")
            {
                User.Meat += 10;
                game.User.Provisions += 21;
                game = boardService.GenerateUpperScreen(game);
                game.Board = boardService.PlaceDaniel();
                game.Board = treeService.GrowTrees(game.Board, User.UserX, User.UserY);
            }
            game.Board = ScratchLastPlayerPosition(game.Board);
            game.Board.View[User.UserY] = game.Board.View[User.UserY].Insert(User.UserX, "@").Remove(User.UserX + 1, 1);

            return game.Board;
        }

        static Board ScratchLastPlayerPosition(Board board)
        {
            for (int i = 5; i < board.View.Length; i++)
            {
                for (int j = 0; j < board.View[i].Length; j++)
                {
                    if (board.View[i].Substring(j, 1) == "@")
                    {
                        board.View[i] = board.View[i].Insert(j, " ").Remove(j + 1, 1);
                        return board;
                    }
                }
            }
            return board;
        }


    }
}
