﻿using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using System;
using System.Linq;

namespace DanielsHunter.App.Manager
{
    public class ScreenManager
    {
        // todo !!! Thats brilliant idea add more nested Services -- footer service, header service.
        private readonly Screen screen;
        public ScreenManager()
        {
        }
        public ScreenManager(Screen screen)
        {
            this.screen = screen;
        }

        public (int?, int) FillFooterMenuWithContent(int? chosen, params string[] message)
        {
            screen.Footer = new string[message.Length + 1];
            screen.Footer[0] = string.Empty;
            for (int i = 1; i < message.Length + 1; i++)
            {
                if (i == chosen + 1)
                {
                    screen.Footer[i] = string.Concat(new string(' ', screen.Board.Offset - 2), ">>> ", message[i - 1], " <<<");
                }
                else
                {
                    screen.Footer[i] = string.Concat(new string(' ', screen.Board.Offset), message[i - 1]);
                }

            }
            return (chosen, message.Length);
        }

        public void EraseFooter()
        {
            FillFooterMenuWithContent(null, string.Empty);
        }

        public void UpdateScreen(Game game, bool displayFooter = false)
        {
            game.screenManager.GenerateUpperScreen(game.assetService);
            game.screenManager.ShowScreen(game, displayFooter);
        }

        private void ShowScreen(Game game, bool displayFooter = false)
        {
            if (!displayFooter)
            {
                EraseFooter();
            }

            GeneratePlayArea(game);
            GenerateView();

            Console.Clear();
            Console.CursorVisible = false;
            int counter = 0;
            counter = PrintEachLine(counter, screen.Header);
            counter = PrintEachLine(counter, screen.CommStrip);
            counter = PrintEachLine(counter, screen.View);
            counter = PrintEachLine(counter, screen.Footer);
        }

        private int PrintEachLine(int counter, string[] arr)
        {
            arr.ToList().ForEach(x =>
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - screen.Board.Width, (Console.WindowHeight- screen.totalHeight) / 2 + counter);
                counter++;
                Console.WriteLine(x);
            });
            return counter;
        }

        private void GeneratePlayArea(Game game)
        {
            var all = game.assetService.GetAllItems().ToList();
            all.ForEach(asset =>
            {
                game.assetManager.DisposeAsset(asset);
                game.assetManager.IntroduceAsset(asset);
            });
        }

        private void GenerateView()
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

        private void GenerateUpperScreen(AssetService assetService)
        {
            GenerateHeader();
            GenerateCommStrip(assetService);
        }

        private void GenerateHeader()
        {
            screen.Header[0] = string.Empty;
            screen.Header[1] = string.Concat(new string(' ', 20), "D A N I E L S   H U N T E R :");
            screen.Header[2] = string.Empty;
            screen.Header[3] = string.Empty;
        }

        private void GenerateCommStrip(AssetService assetService)
        {
            Daniel daniel = (Daniel)assetService.GetAsset("Daniel");
            User user = (User)assetService.GetAsset("User");

            screen.CommStrip[0] = $"\t\t\tDaniel\tX : {daniel.X}\tY : {daniel.Y}";
            screen.CommStrip[1] = $"\t\t\tUser\tX : {user.X}\tY : {user.Y}";
            screen.CommStrip[2] = $"\t\t\tchosenAction : {user.ChosenAction}";
            screen.CommStrip[3] = string.Empty;
            screen.CommStrip[4] = $"Provision's Left: {user.Provisions}\t\t\t\t\tAquired Meat: {user.Meat}";
            screen.CommStrip[5] = string.Empty;
        }
    }
}