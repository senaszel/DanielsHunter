namespace DanielsHunter
{
    public class Screen
    {
        public string[] View { get; set; }
        public string[] PlayArea { get; set; }
        public string[] Header { get; set; }
        public string[] CommStrip { get; set; }
        public string[] Footer { get; set; }


        public Screen(int headerLength, int commStripLength, int viewLength, int footerLength)
        {
            View = new string[viewLength + 2];
            PlayArea = new string[viewLength];
            Header = new string[headerLength];
            CommStrip = new string[commStripLength];
            Footer = new string[footerLength];

        }
    }
}
