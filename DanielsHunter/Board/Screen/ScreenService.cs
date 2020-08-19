namespace DanielsHunter
{
    public class ScreenService
    {

        public Screen Screen { get; set; }
        public ScreenService(Screen screen)
        {
            Screen = screen;
        }

        public string GenerateScreen()
        {
            //Console.CursorVisible = false;
            string screen = string.Concat(string.Join('\n', Screen.Header), string.Join('\n', Screen.CommStrip), string.Join('\n', Screen.View), string.Join('\n', Screen.Footer));
            return screen;
            //Console.Write(screen);
        }

        public Screen GenerateUpperScreen(User user)
        {
            Screen = GenerateHeader();
            Screen = GenerateCommStrip(user);
            return Screen;
        }

        private Screen GenerateCommStrip(User user)
        {
            Screen.CommStrip[0] = "\r\n";
            Screen.CommStrip[1] = $"\t\t\t\tX : {user.UserX}\tY : {user.UserY}";
            Screen.CommStrip[2] = $"Provision's Left: {user.Provisions}\t\t\t\t\tAquired Meat: {user.Meat}";
            Screen.CommStrip[3] = "\r\n";
            return Screen;
        }

        private Screen GenerateHeader()
        {
            Screen.Header[0] = "\r\n";
            Screen.Header[1] = (string.Concat(new string(' ', 20), "D A N I E L S   H U N T E R :"));
            Screen.Header[2] = "\r\n";
            return Screen;
        }

        public Screen GeneratePlayArea(Board board)
        {
            int upperBoarder = 0;
            int lowerBoarder = board.Height + 1;
            for (int i = upperBoarder; i <= lowerBoarder; i++)
            {
                if (i == upperBoarder || i == lowerBoarder)
                {
                    Screen.View[i] = string.Concat(new string(' ', board.Offset), new string('#', board.Width + 2));
                }
                else
                {
                    if (i <= Screen.PlayArea.Length)
                    {
                        Screen.PlayArea[i - 1] = new string(' ', board.Width);
                    }
                    Screen.View[i] = string.Concat(new string(' ', board.Offset), '#', Screen.PlayArea[i - 1], '#');
                }
            }
            return Screen;
        }
    }
}