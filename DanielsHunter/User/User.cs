namespace DanielsHunter
{
    public class User
    {
        public int UserX { get; set; }
        public int UserY { get; set; }
        public int Meat { get; set; }
        public int Provisions { get; set; }

        public User()
        {
            Meat = 0;
            Provisions = 0;
            UserX = 0;
            UserY = 0;
        }

        public User(int provisions, int meat, int userX, int userY)
            : base()
        {
            Provisions = provisions;
            Meat = meat;
            UserX = userX;
            UserY = userY;
        }
    }
}
