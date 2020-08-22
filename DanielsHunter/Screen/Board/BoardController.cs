using System;
using System.Linq;

namespace DanielsHunter
{
    public class BoardController
    {
        public Board Board { get; set; }

        public BoardController()
        {

        }
        public BoardController(Board board)
        {
            Board = board;
        }


        public void PlaceDanielAtRandomPlaceOnTheBoard()
        {
            AssetsRepository assetsRepository = new AssetsRepository();
            Daniel daniel = new Daniel();
            Random random = new Random();

            daniel.X = random.Next(0, Board.Width);
            daniel.Y = random.Next(0, Board.Height);

            bool placed = false;
            foreach (string symbol in assetsRepository.GetAllSymbols())
            {
                if (Board.PlayArea[daniel.Y].Substring(daniel.X, 1) != symbol)
                {
                    PlaceAssetOnABoard(daniel);
                    placed = true;
                }
            };
            if (!placed) PlaceDanielAtRandomPlaceOnTheBoard();
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
