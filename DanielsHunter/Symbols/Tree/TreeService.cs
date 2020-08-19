namespace DanielsHunter
{
    class TreeService
    {
        public Tree Tree { get; set; }

        public TreeService()
        {
            Tree = new Tree();
        }

        public void GrowTrees(Board board, User user)
        {
            board.Screen.PlayArea[user.UserY - 1] = board.Screen.PlayArea[user.UserY - 1].Insert(user.UserX - 1, Tree.Symbol).Remove(user.UserX, 1);
            board.Screen.PlayArea[user.UserY + 1] = board.Screen.PlayArea[user.UserY + 1].Insert(user.UserX - 1, Tree.Symbol).Remove(user.UserX, 1);

            board.Screen.PlayArea[user.UserY - 1] = board.Screen.PlayArea[user.UserY - 1].Insert(user.UserX + 1, Tree.Symbol).Remove(user.UserX + 2, 1);
            board.Screen.PlayArea[user.UserY + 1] = board.Screen.PlayArea[user.UserY + 1].Insert(user.UserX + 1, Tree.Symbol).Remove(user.UserX + 2, 1);
        }
    }
}
