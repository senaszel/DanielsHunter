using System.Linq;

namespace DanielsHunter
{
    class UserService
    {
        public User User { get; set; }

        public UserService(User user)
        {
            User = user;
        }

        internal Board ScratchLastPlayerPosition(Board board)
        {
            string row = board.Screen.PlayArea.ToList().FirstOrDefault(x => x.Contains('@'));
            int previousPosition = row.IndexOf('@');
            row.Insert(previousPosition, " ").Remove(previousPosition + 1, 1);
            return board;

            //for (int i = 0; i < board.View.Length; i++)
            //{
            //    if (board.View[i].Substring(i, 1) == "@")
            //    {
            //        board.View[i] = board.View[i].Insert(i, " ").Remove(i + 1, 1);
            //        return board;
            //    }
            //}
        }

        internal Board PlaceUserOnABoard(Board board)
        {
            board.Screen.PlayArea[User.UserY].Insert(User.UserX, "@").Remove(User.UserX + 2, 1);
            return board;
        }
    }
}
