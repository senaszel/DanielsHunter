namespace DanielsHunter
{
    public class Daniel : IAsset
    {
        public  string Name => "Daniel";
        public  string Symbol => "d";
        public  int X { get; set; }
        public  int Y { get; set; }
        public  (int x, int y) Key => (X, Y);
        public Daniel()
        {
        }
        public Daniel(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
