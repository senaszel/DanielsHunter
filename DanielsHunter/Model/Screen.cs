namespace DanielsHunter.Model
{
    public class Screen
    {
        public string[] View { get; set; }
        public Board Board { get; set; }
        public string[] Header { get; set; }
        public string[] CommStrip { get; set; }
        public string[] Footer { get; set; }

        public Screen(int viewLength, Board board)
        {
            View = new string[viewLength + 2];
            Header = new string[3];
            CommStrip = new string[4];
            Board = board;
            Footer = new string[4];
        }
    }
}
