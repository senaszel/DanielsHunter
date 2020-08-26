namespace DanielsHunter.Model
{
    public class Screen
    {
        public string[] View { get; set; }
        public Board Board { get; set; }
        public string[] Header { get; set; }
        public string[] CommStrip { get; set; }
        public string[] Footer { get; set; }

        public Screen(int headerLength, int commStripLength, int viewLength, int footerLength, Board board)
        {
            View = new string[viewLength + 2];
            Header = new string[headerLength];
            CommStrip = new string[commStripLength];
            Board = board;
            Footer = new string[footerLength];
        }
    }
}
