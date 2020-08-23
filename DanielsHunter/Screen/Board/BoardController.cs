using System;

namespace DanielsHunter
{
    public class BoardController
    {
        private Board Board;
        public BoardController()
        {
        }
        public BoardController(Board board)
        {
            Board = board;
        }

        
        public void PlaceAssetOnTheBoard(IAsset asset)
        {
            Board.AssetsRepository.AddToAssetRepository(asset);
            PlaceAssetOnTheBoard(asset.X, asset.Y, asset.Symbol);
        }
        public void PlaceAssetOnTheBoard(int x, int y, string symbol)
        {
            Board.PlayArea[y] = Board.PlayArea[y].Insert(x, symbol).Remove(x + 1, 1);
        }


        public void RemoveAssetFromTheBoard(IAsset asset)
        {
            if (Board.AssetsRepository.RemoveFromAssetsRepository(asset))
            {
                RemoveAssetFromTheBoard(asset.X, asset.Y);
            }
        }
        internal void RemoveAssetFromTheBoard(int x, int y)
        {
            Board.PlayArea[y] = Board.PlayArea[y].Insert(x, " ").Remove(x + 1, 1);
        }


    }
}
