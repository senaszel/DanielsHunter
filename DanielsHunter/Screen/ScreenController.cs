namespace DanielsHunter
{
    public class ScreenController
    {

        public Screen Screen { get; set; }
        public ScreenController()
        {

        }
        public ScreenController(Screen screen)
        {
            Screen = screen;
        }

        public void ShowScreen()
        {
            GenerateView();
            string screen = string.Concat(string.Join('\n', Screen.Header), string.Join('\n', Screen.CommStrip),"\r\n",string.Join('\n', Screen.View), string.Join('\n', Screen.Footer));
            System.Console.CursorVisible = false;
            System.Console.WriteLine(screen);
        }

        public void GenerateView()
        {
            int upperBoarder = 0;
            int lowerBoarder = Screen.Board.Height + 1;
            for (int i = upperBoarder; i <= lowerBoarder; i++)
            {
                if (i == upperBoarder || i == lowerBoarder)
                {
                    Screen.View[i] = string.Concat(new string(' ', Screen.Board.Offset), new string('#', Screen.Board.Width + 2));
                }
                else
                {
                    Screen.View[i] = string.Concat(new string(' ', Screen.Board.Offset), '#', Screen.Board.PlayArea[i - 1], '#');
                }
            }
        }

        public void GenerateUpperScreen(AssetsRepository assetsRepository)
        {
             GenerateHeader();
             GenerateCommStrip(assetsRepository);
        }

        private void GenerateCommStrip(AssetsRepository assetsRepository)
        {
            Daniel daniel = (Daniel)assetsRepository.GetAsset("Daniel");

            User user = (User)assetsRepository.GetAsset("User");

            Screen.CommStrip[0] = string.Empty;
            Screen.CommStrip[1] = $"\t\t\tDaniel\tX : {daniel.X}\tY : {daniel.Y}";
            Screen.CommStrip[2] = $"\t\t\tUser\tX : {user.X}\tY : {user.Y}";
            Screen.CommStrip[3] = $"Provision's Left: {user.Provisions}\t\t\t\t\tAquired Meat: {user.Meat}";
        }

        private void GenerateHeader()
        {
            Screen.Header[0] = "\r\n";
            Screen.Header[1] = string.Concat(new string(' ', 20), "D A N I E L S   H U N T E R :");
            Screen.Header[2] = "\r\n";
        }

        public void InitialisePlayArea()
        {
            int upperBoarder = 0;
            int lowerBoarder = Screen.Board.Height + 1;
            for (int i = upperBoarder; i <= lowerBoarder; i++)
            {
                if (i == upperBoarder || i == lowerBoarder)
                {
                    Screen.View[i] = string.Concat(new string(' ', Screen.Board.Offset), new string('#', Screen.Board.Width + 2));
                }
                else
                {
                    if (i <= Screen.Board.Width)
                    {
                        Screen.Board.PlayArea[i - 1] = new string(' ', Screen.Board.Width);
                    }
                    Screen.View[i] = string.Concat(new string(' ', Screen.Board.Offset), '#', Screen.Board.PlayArea[i - 1], '#');
                }
            }
        }
    }
}