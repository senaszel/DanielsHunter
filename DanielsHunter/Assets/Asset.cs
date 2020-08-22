namespace DanielsHunter
{
    public abstract class Asset
    {
        public abstract string Symbol { get; }
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
    }
}