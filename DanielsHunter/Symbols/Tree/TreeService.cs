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
            string[] playArea = board.PlayArea;
            int x = user.UserX;
            int y = user.UserY;
            //todo aktualnie jak bedzie mialo urodzic poza playArea to sypnie bledem
            // poprawilem ale lamie SRP -- FluentValidowac to!
            if ((y - 1 >= 0) && (x - 1 >= 0))
                playArea[y - 1] = playArea[y - 1].Insert(x - 1, Tree.Symbol).Remove(x, 1);

            if ((y + 1 < board.Height) && (x - 1 >= 0))
                playArea[y + 1] = playArea[y + 1].Insert(x - 1, Tree.Symbol).Remove(x, 1);

            if ((y - 1 >= 0) && (x + 2 < board.Width))
                playArea[y - 1] = playArea[y - 1].Insert(x + 1, Tree.Symbol).Remove(x + 2, 1);

            if ((y + 1 < board.Height) && (x + 2 < board.Width))
                playArea[y + 1] = board.PlayArea[y + 1].Insert(x + 1, Tree.Symbol).Remove(x + 2, 1);


            board.PlayArea = playArea;
        }
    }
}
