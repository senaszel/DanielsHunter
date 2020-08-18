using System.Linq;

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
            //todo co tutaj robi podnoszenie przedmiotu przemyslec przeniesc w odpowiednie miejsce
            if (game.Board.View[User.UserY].Substring(User.UserX, 1) == "d")
            {
                User.Meat += 10;
                game.User.Provisions += 21;
                boardService.GenerateUpperScreen(game);
                boardService.PlaceDaniel();
                treeService.GrowTrees(game.Board, User.UserX, User.UserY);
            }
            game.Board = ScratchLastPlayerPosition(game.Board);
            game.Board.PlayArea[User.UserY] = game.Board.PlayArea[User.UserY].Insert(User.UserX, "@").Remove(User.UserX + 1, 1);

            return game.Board;
        }

        static Board ScratchLastPlayerPosition(Board board)
        {
            string row = board.PlayArea.ToList().FirstOrDefault(x => x.Contains('@'));
            int previousPosition = row.IndexOf('@');
            row.Insert(previousPosition, " ").Remove(previousPosition + 1, 1);


            //for (int i = 0; i < board.View.Length; i++)
            //{
            //    if (board.View[i].Substring(i, 1) == "@")
            //    {
            //        board.View[i] = board.View[i].Insert(i, " ").Remove(i + 1, 1);
            //        return board;
            //    }
            //}
            return board;
        }


    }
}
