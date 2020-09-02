using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Common;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Manager
{
    public class BoardManager
    {
        private readonly Board board;

        public BoardManager()
        {
        }
        public BoardManager(Board board)
        {
            this.board = board;
        }

        public void InsertSymbolIntoPlayArea(Asset asset)
        {
            board.PlayArea[asset.Y] = board.PlayArea[asset.Y].Insert(asset.X, asset.Symbol).Remove(asset.X + 1, 1);
        }

        public void RemoveSymbolFromPlayArea((int x, int y)key)
        {
            board.PlayArea[key.y] = board.PlayArea[key.y].Insert(key.x, " ").Remove(key.x + 1, 1);
        }
    }
}
