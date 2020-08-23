namespace DanielsHunter
{
    public interface IAsset
    {
        public abstract string Name { get; }
        public abstract string Symbol { get; }
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract (int x,int y) Key { get; }
    }
}