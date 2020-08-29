using DanielsHunter.Domain.Common;

namespace DanielsHunter.Domain.Entity
{
    public class Tree : Asset
    {
        public Tree()
        {
            Name = "Tree";
            Symbol = "#";
        }

        public Tree(int x, int y)
            : this()
        {
            X = x;
            Y = y;
        }

        public Tree(string name, int x, int y)
            : this()
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
