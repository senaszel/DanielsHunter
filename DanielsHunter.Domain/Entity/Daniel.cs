
using DanielsHunter.Domain.Common;

namespace DanielsHunter.Domain.Entity
{
    public class Daniel : Asset
    {
        public Daniel()
        {
            Name = "Daniel";
            Symbol = "d";
        }
        public Daniel(int x, int y)
            :this()
        {
            X = x;
            Y = y;
        }
    }
}
