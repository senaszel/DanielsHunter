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
        public Board PlaceDaniel()
        {
            SymbolRepository symbolRepository = new SymbolRepository();
            Random random = new Random();

            int danielX = random.Next(0, Board.Width);
            int danielY = random.Next(0, Board.Height);

            bool placed = false;
            foreach (string symbol in symbolRepository.Symbols)
            {
                if (Board.PlayArea[danielY].Substring(danielX, 1) != symbol)
                {
                    Board.PlayArea[danielY] = Board.PlayArea[danielY].Insert(danielX, "d").Remove(danielX + 1, 1);
                    placed = true;
                }
            };
            if (!placed) PlaceDaniel();
            return Board;
        }

        //TODO do zgeneryfikowania
        public Board PlaceUserOnABoard(User user)
        {
            Board.PlayArea[user.UserY] = Board.PlayArea[user.UserY].Insert(user.UserX, "@").Remove(user.UserX + 1, 1);
            return Board;
        }

        //TODO do zgeneryfikowania
        public Board ScratchLastPlayerPosition(User user)
        {
            Board.PlayArea[user.UserY] = Board.PlayArea[user.UserY].Insert(user.UserX," ").Remove(user.UserX+1, 1);
            return Board;
        }

    }
}
