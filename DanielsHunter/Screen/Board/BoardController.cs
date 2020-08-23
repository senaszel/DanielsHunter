using System;
using System.Linq;

namespace DanielsHunter
{
    public class BoardController
    {
        public Board Board;
        AssetsRepository AssetsRepository;
        public BoardController()
        {

        }
        public BoardController(Board board, AssetsRepository assetsRepository)
        {
            Board = board;
            AssetsRepository = assetsRepository;
        }


        public void PlaceDanielAtRandomPlaceOnTheBoard()
        {
            Daniel daniel = new Daniel();
            Random random = new Random();

            daniel.X = random.Next(0, Board.Width);
            daniel.Y = random.Next(0, Board.Height);

            bool placed = false;
            do
            {
                foreach (string symbol in AssetsRepository.GetAllSymbols())
                    if (Board.PlayArea[daniel.Y].Substring(daniel.X, 1) != symbol)
                    {
                        PlaceAssetOnABoard(daniel);
                        placed = true;
                    }
            } while (!placed);
        }

        public void PlaceAssetOnABoard(Asset asset)
        {
            Board.PlayArea[asset.Y] = Board.PlayArea[asset.Y].Insert(asset.X, asset.Symbol).Remove(asset.X + 1, 1);
        }

        public void RemoveAssetFromTheBoard(Asset asset)
        {
            Board.PlayArea[asset.Y] = Board.PlayArea[asset.Y].Insert(asset.X, " ").Remove(asset.X + 1, 1);
        }


    }
}
