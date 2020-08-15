namespace DanielsHunter
{
    class User
    {
        public int UserX { get; set; }
        public int UserY { get; set; }
        public int Meat { get; set; }

        public User()
        {
            Meat = 0;
            UserX = 0;
            UserY = 0;
        }
        
        public User(int meat, int userX, int userY)
        {
            Meat = meat;
            UserX = userX;
            UserY = userY;
        }
    }
}
