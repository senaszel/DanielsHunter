using DanielsHunter.Model;

namespace DanielsHunter.Service
{
    public class ScreenService
    {
        public Screen screen;
        public ScreenService()
        {

        }
        public ScreenService(Screen screen)
        {
            this.screen = screen;
        }

        public void ShowScreen()
        {
            GenerateView();
            string screen = string.Concat(string.Join('\n', this.screen.Header), string.Join('\n', this.screen.CommStrip),"\r\n",string.Join('\n', this.screen.View), string.Join('\n', this.screen.Footer));
            System.Console.CursorVisible = false;
            System.Console.WriteLine(screen);
        }

        public void GenerateView()
        {
            int upperBoarder = 0;
            int lowerBoarder = screen.Board.Height + 1;
            for (int i = upperBoarder; i <= lowerBoarder; i++)
            {
                if (i == upperBoarder || i == lowerBoarder)
                {
                    screen.View[i] = string.Concat(new string(' ', screen.Board.Offset), new string('#', screen.Board.Width + 2));
                }
                else
                {
                    screen.View[i] = string.Concat(new string(' ', screen.Board.Offset), '#', screen.Board.PlayArea[i - 1], '#');
                }
            }
        }

        public void GenerateUpperScreen(AssetService assetsRepository)
        {
             GenerateHeader();
             GenerateCommStrip(assetsRepository);
        }

        private void GenerateCommStrip(AssetService assetsRepository)
        {
            Daniel daniel = (Daniel)assetsRepository.GetAsset("Daniel");

            User user = (User)assetsRepository.GetAsset("User");

            screen.CommStrip[0] = string.Empty;
            screen.CommStrip[1] = $"\t\t\tDaniel\tX : {daniel.X}\tY : {daniel.Y}";
            screen.CommStrip[2] = $"\t\t\tUser\tX : {user.X}\tY : {user.Y}";
            screen.CommStrip[3] = $"Provision's Left: {user.Provisions}\t\t\t\t\tAquired Meat: {user.Meat}";
        }

        private void GenerateHeader()
        {
            screen.Header[0] = "\r\n";
            screen.Header[1] = string.Concat(new string(' ', 20), "D A N I E L S   H U N T E R :");
            screen.Header[2] = "\r\n";
        }

        public void InitialisePlayArea()
        {
            int upperBoarder = 0;
            int lowerBoarder = screen.Board.Height + 1;
            for (int i = upperBoarder; i <= lowerBoarder; i++)
            {
                if (i == upperBoarder || i == lowerBoarder)
                {
                    screen.View[i] = string.Concat(new string(' ', screen.Board.Offset), new string('#', screen.Board.Width + 2));
                }
                else
                {
                    if (i <= screen.Board.Width)
                    {
                        screen.Board.PlayArea[i - 1] = new string(' ', screen.Board.Width);
                    }
                    screen.View[i] = string.Concat(new string(' ', screen.Board.Offset), '#', screen.Board.PlayArea[i - 1], '#');
                }
            }
        }
    }
}