using DanielsHunter.Domain.Common;
using DanielsHunter.Domain.Enum;

namespace DanielsHunter.Domain.Entity
{
    public class User : Asset
    {
        public int Meat { get; set; }
        public int Provisions { get; set; }
        public UserActionEnum ChosenAction { get; set; }

        public User()
        {
            Name = "User";
            Symbol = "@";
            ChosenAction = UserActionEnum.MOVE;
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
