using DanielsHunter.Domain.Common;

namespace DanielsHunter.Domain.Entity
{
    public class User : Asset
    {
        public int Meat { get; set; }
        public int Provisions { get; set; }

        public User()
        {
            Name = "User";
            Symbol = "@";
        }

        public User(int provisions, int meat, int userX, int userY)
            : this()
        {
            Provisions = provisions;
            Meat = meat;
            X = userX;
            Y = userY;
        }
    }
}
