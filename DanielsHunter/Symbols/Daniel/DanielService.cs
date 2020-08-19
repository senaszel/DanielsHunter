using System;

namespace DanielsHunter
{
    class DanielService
    {
        public Daniel Daniel { get; set; }

        public DanielService()
        {
            Daniel = new Daniel();
        }

        public void PlaceDaniel(Board board)
        {
            Random random = new Random();

            int danielX = random.Next(0, board.Width + 1);
            int danielY = random.Next(0, board.Height + 1);
            SymbolRepository symbolRepository = new SymbolRepository();
            bool placed = false;
            foreach (string symbol in symbolRepository.Symbols)
            {
                if (board.Screen.PlayArea[danielY].Substring(danielX, 1) != symbol)
                {
                    board.Screen.PlayArea[danielY] = board.Screen.PlayArea[danielY].Insert(danielX, "d").Remove(danielX + 1, 1);
                    placed = true;
                }
            };
            if (!placed) PlaceDaniel(board);
        }

    }
}
