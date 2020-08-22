using System;
using System.Linq;

namespace DanielsHunter
{
    public class BoardService
    {
        public Board Board { get; set; }

        public BoardService(Board board)
        {
            Board = board;
        }


        //TODO to oczywiscie jest do zgeneryfikowania
        public void PlaceDaniel()
        {
            AssetsRepository assetsRepository = new AssetsRepository();
            Random random = new Random();

            int danielX = random.Next(0, Board.Width);
            int danielY = random.Next(0, Board.Height);

            bool placed = false;
            foreach (string symbol in assetsRepository.GetAllSymbols())
            {
                if (Board.PlayArea[danielY].Substring(danielX, 1) != symbol)
                {
                    Board.PlayArea[danielY] = Board.PlayArea[danielY].Insert(danielX, "d").Remove(danielX + 1, 1);
                    placed = true;
                }
            };
            if (!placed) PlaceDaniel();
        }

        // todo do przeniesienia do kontrollera
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
