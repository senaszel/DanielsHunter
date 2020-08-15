using System;
using System.Collections.Generic;
using System.Text;

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

            if (game.Board.View[User.UserY].Substring(User.UserX, 1) == "d")
            {
                User.Meat += 10;
                game.TurnCounter -= 20;
                game.Board.View = boardService.PlaceDaniel();
                game.Board = boardService.GrowTrees(User.UserX, User.UserY);
            }
            game.Board = ScratchLastPlayerPosition(game.Board);
            game.Board.View[User.UserY] = game.Board.View[User.UserY].Insert(User.UserX, "@").Remove(User.UserX + 1, 1);

            return game.Board;
        }

        static Board ScratchLastPlayerPosition(Board board)
        {
            for (int i = 0; i < board.View.Length; i++)
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
