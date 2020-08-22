namespace DanielsHunter
{
    public class User : Asset
    {
        public override int X { get; set; }
        public override int Y { get; set; }
        public int Meat { get; set; }
        public int Provisions { get; set; }
        public override string Symbol { get => "@"; }

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
