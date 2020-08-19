namespace DanielsHunter
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Offset { get; set; }
        public Screen Screen { get; set; }

        public Board(int height, int width, int offset, Screen screen)
        {
            Height = height;
            Width = width;
            Offset = offset;
            Screen = screen;
        }
    }
}