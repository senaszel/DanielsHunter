namespace DanielsHunter
{
    public class Tree : IAsset
    {
        public string Name { get; set; }
        public string Symbol => "#";
        public int X { get; set; }
        public int Y { get; set; }
        public (int x, int y) Key => (X,Y);

        public Tree()
        {
        }

        public Tree(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Tree(string name,int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
