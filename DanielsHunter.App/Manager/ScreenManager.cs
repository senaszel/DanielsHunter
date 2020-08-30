using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;

namespace DanielsHunter.App.Manager
{
    public class ScreenManager
    {
        private readonly Screen screen;
        public ScreenManager()
        {
        }
        public ScreenManager(Screen screen)
        {
            this.screen = screen;
        }

        public (int, int) FillFooterMenuWithContent(int chosen, params string[] message)
        {
            screen.Footer = new string[message.Length];
            for (int i = 0; i < message.Length; i++)
            {
                if (i == chosen)
                {
                    screen.Footer[i] = string.Concat(new string(' ', screen.Board.Offset - 2), ">>> ", message[i], " <<<");
                }
                else
                {
                    screen.Footer[i] = string.Concat(new string(' ', screen.Board.Offset), message[i]);
                }

            }
            return (chosen, message.Length);
        }

        public void EraseFooter()
        {
            FillFooterMenuWithContent(-1, string.Empty);
        }

        public void ShowScreen(bool displayFooter = false)
        {
            if (!displayFooter)
            {
                EraseFooter();
            }

            string separator = "\r\n\r\n";
            GenerateView();
            string screen = string.Concat(string.Join('\n', this.screen.Header), separator, string.Join('\n', this.screen.CommStrip), separator, string.Join('\n', this.screen.View), separator, string.Join('\n', this.screen.Footer));
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

        public void GenerateUpperScreen(AssetService assetService)
        {
            GenerateHeader();
            GenerateCommStrip(assetService);
        }

        private void GenerateCommStrip(AssetService assetService)
        {
            Daniel daniel = (Daniel)assetService.GetAsset("Daniel");

            User user = (User)assetService.GetAsset("User");

            screen.CommStrip[0] = $"\t\t\tDaniel\tX : {daniel.X}\tY : {daniel.Y}";
            screen.CommStrip[1] = $"\t\t\tUser\tX : {user.X}\tY : {user.Y}";
            screen.CommStrip[2] = $"\t\t\tchosenAction : {user.ChosenAction}";
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