using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Common;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Manager
{
    public class BoardManager
    {
        private Board board;

        public BoardManager()
        {
        }
        public BoardManager(Board board)
        {
            this.board = board;
        }

        public void InsertSymbolIntoPlayArea(int x, int y, string symbol)
        {
            board.PlayArea[y] = board.PlayArea[y].Insert(x, symbol).Remove(x + 1, 1);
        }

        internal void RemoveSymbolFromPlayArea(int x, int y)
        {
            // todo Zrobić wspólną walidacje.
            //x = x >= board.Width ? board.Width-1 : x;
            //x = x < 0 ? 0 : x;
            //y = y >= board.Height ? board.Height-1 : y;
            //y = y < 0 ? 0 : y;

            board.PlayArea[y] = board.PlayArea[y].Insert(x, " ").Remove(x + 1, 1);
        }


    }
}
