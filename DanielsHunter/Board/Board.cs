namespace DanielsHunter
{
    public class Board
    {
        public int Height { get => 25; }
        public int Width { get => 50; }

        public int Offset { get => 4; }
        public string[] View { get; set; }

        public Board()
        {
            View = new string[Height + 1];
        }
    }
}