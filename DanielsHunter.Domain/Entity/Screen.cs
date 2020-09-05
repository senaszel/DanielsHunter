namespace DanielsHunter.Domain.Entity
{
    public class Screen : BaseEntity
    {
        public string[] View { get; set; }
        public Board Board { get; set; }
        public string[] Header { get; set; }
        public string[] CommStrip { get; set; }
        public string[] Footer { get; set; }
        public int totalWidth { get {return View.Length; } }
        public int totalHeight { get {return Header.Length+CommStrip.Length+View.Length+Footer.Length; } }

        public Screen(Board board)
        {
            View = new string[board.Height + 2];
            Header = new string[4];
            CommStrip = new string[6];
            Board = board;
            Footer = new string[4];
        }
    }
}
