namespace DanielsHunter
{
    static class User
    {
        public static int UserX { get; set; }
        public static int UserY { get; set; }
        public static int Meat { get; set; }

        public static string[] Place(string[] board)
        {
            if (board[UserY].Substring(UserX, 1) == "d")
            {
                Meat += 10;
                Game.TurnCounter -= 20;
                board = Board.PlaceDaniel();
                board = Board.GrowTrees(board, UserX, UserY);
            }
            board = ScratchLastPlayerPosition(board);
            board[UserY] = board[UserY].Insert(UserX, "@").Remove(UserX + 1, 1);

            return board;
        }

        static string[] ScratchLastPlayerPosition(string[] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i].Substring(j, 1) == "@")
                    {
                        board[i] = board[i].Insert(j, " ").Remove(j + 1, 1);
                        return board;
                    }
                }
            }
            return board;
        }


    }
}
