using DanielsHunter.Model;

namespace DanielsHunter.Service
{
    public class BoardService
    {
        public Board board;
        public BoardService()
        {
        }
        public BoardService(Board board)
        {
            this.board = board;
        }

        
        public void PlaceAssetOnTheBoard(IAsset asset)
        {
            board.AssetsRepository.AddToAssetRepository(asset);
            PlaceAssetOnTheBoard(asset.X, asset.Y, asset.Symbol);
        }
        public void PlaceAssetOnTheBoard(int x, int y, string symbol)
        {
            board.PlayArea[y] = board.PlayArea[y].Insert(x, symbol).Remove(x + 1, 1);
        }


        public void RemoveAssetFromTheBoard(IAsset asset)
        {
            if (board.AssetsRepository.RemoveFromAssetsRepository(asset))
            {
                RemoveAssetFromTheBoard(asset.X, asset.Y);
            }
        }
        internal void RemoveAssetFromTheBoard(int x, int y)
        {
            board.PlayArea[y] = board.PlayArea[y].Insert(x, " ").Remove(x + 1, 1);
        }


    }
}
