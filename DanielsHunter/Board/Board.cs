namespace DanielsHunter
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public int Offset { get; set; }
        public string[] View { get; set; }
        public string[] PlayArea { get; set; }
        public string[] Header { get; set; }
        public string[] CommStrip { get; set; }
        public string[] Footer { get; set; }

        public Board(int height, int width, int offset, int headerLength, int commStripLength, int viewLength, int footerLength)
        {
            Height = height;
            Width = width;
            Offset = offset;
            View = new string[viewLength + 2];
            PlayArea = new string[viewLength];
            Header = new string[headerLength];
            CommStrip = new string[commStripLength];
            Footer = new string[footerLength];
        }
    }
}