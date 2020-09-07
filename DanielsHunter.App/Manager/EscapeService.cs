using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using System;
using System.Linq;

namespace DanielsHunter.App.Manager
{
    public class EscapeService : BaseService<MenuItem>
    {
        private Game game;
        private ConsoleKey lastPressedKey;
        private int CurrentIndex { get { return Items.IndexOf(Current as MenuItem); } }
        private MenuItem FirstEligibleItem
        {
            get { return Items.Where(w => w.CanNOTbeChosen == false).FirstOrDefault(); }
        }
        private MenuItem LastEligibleItem
        {
            get { return Items.Where(w => w.CanNOTbeChosen == false).LastOrDefault(); }
        }

        public EscapeService(Game game)
        {
            this.game = game;
            Initialise();
        }

        private void Initialise()
        {
            Items.Add(new MenuItem("", false, true));
            Items.Add(new MenuItem(name: "", isCurrent: false, canNOTbeChosen: true));
            Items.Add(new MenuItem("", false, true));
            Items.Add(new MenuItem("continue", true, false));
            Items.Add(new MenuItem("", false, true));
            Items.Add(new MenuItem("options", false, false));
            Items.Add(new MenuItem("", false, true));
            Items.Add(new MenuItem("save & exit", false, false));
            Items.Add(new MenuItem("", false, true));
            Items.Add(new MenuItem("", false, true));
            Items.Add(new MenuItem("", false, true));
        }

        internal void Run()
        {
            do
            {
                PresentOptions();
                EnableChoice();

            } while (lastPressedKey != ConsoleKey.NumPad5);
            ProccedWithMadeChoice();
        }

        private void ProccedWithMadeChoice()
        {
            switch ((Current as MenuItem).Name)
            {
                case "continue":
                    break;
                case "options":
                    //todo OPTIONS
                    break;
                case "save & exit":
                    //todo SAVE 
                    Environment.Exit(0);
                    break;
            }
        }

        private void EnableChoice()
        {
            lastPressedKey = Console.ReadKey(true).Key;
            switch (lastPressedKey)
            {
                case ConsoleKey.NumPad8:
                    MoveDown();
                    break;
                case ConsoleKey.NumPad2:
                    MoveUp();
                    break;
            }
        }

        private void MoveDown()
        {
            int newIndex;
            if (CurrentIndex == Items.IndexOf(FirstEligibleItem))
            {
                newIndex = Items.IndexOf(LastEligibleItem);
            }
            else
            {
                newIndex = CurrentIndex - 1;
            }
            Current.IsCurrent = false;
            Items[newIndex].IsCurrent = true;
            if (Items[newIndex].CanNOTbeChosen == true)
            {
                MoveDown();
            }
        }

        private void MoveUp()
        {
            int newIndex;
            if (CurrentIndex == Items.IndexOf(LastEligibleItem))
            {
                newIndex = Items.IndexOf(FirstEligibleItem);
            }
            else
            {
                newIndex = CurrentIndex + 1;
            }

            Current.IsCurrent = false;
            Items[newIndex].IsCurrent = true;
            if (Items[newIndex].CanNOTbeChosen == true)
            {
                MoveUp();
            }
        }

        private void PresentOptions()
        {
            int longestStrLength = string.Empty.Length;
            Items.ForEach(str =>
            longestStrLength = str.Name.Length > longestStrLength ? str.Name.Length : longestStrLength);
            int border = longestStrLength + 18;

            for (int currentIndex = 0; currentIndex < Items.Count; currentIndex++)
            {
                Console.SetCursorPosition
                    (
                        (Console.WindowWidth
                        - game.boardService.Board.Width
                        - game.boardService.Board.Offset
                        ) / 2,
                        Console.WindowHeight / 2 + currentIndex
                     );
                Console.WriteLine(new string('.', border));

                Console.SetCursorPosition
                    (
                        (Console.WindowWidth
                        - game.boardService.Board.Width
                        - game.boardService.Board.Offset
                        + border
                        ) / 2
                        - Items[currentIndex].Name.Length,
                        Console.WindowHeight / 2 + currentIndex
                    );
                if (Items[currentIndex].IsCurrent)
                {
                    Console.WriteLine($">>>.{Items[currentIndex].Name}.<<<");
                }
                else
                {
                    Console.WriteLine($"....{Items[currentIndex].Name}....");
                }
            }
        }
    }
}

