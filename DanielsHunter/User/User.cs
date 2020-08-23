namespace DanielsHunter
{
    public class User : IAsset
    {
        public string Name => "User";
        public int X { get; set; }
        public int Y { get; set; }
        public string Symbol { get => "@"; }
        public (int x, int y) Key => (X, Y);

        public int Meat { get; set; }
        public int Provisions { get; set; }

        public User()
        {
        }

        public User(int provisions, int meat, int userX, int userY)
            : base()
        {
            Provisions = provisions;
            Meat = meat;
            X = userX;
            Y = userY;
        }
    }
}
