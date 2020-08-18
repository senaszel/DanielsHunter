using System;
using System.Linq;

namespace DanielsHunter
{
    class MenuService : IMenu
    {
        private Menu Menu { get; set; }

        public MenuService(Menu menu)
        {
            Menu = menu;
        }

        public void EnableChoice()
        {
            ConsoleKey choice = Console.ReadKey(true).Key;
            switch (choice)
            {
                case ConsoleKey.UpArrow:
                    PreviousItem();
                    break;
                case ConsoleKey.DownArrow:
                    NextItem();
                    break;
                case ConsoleKey.Enter:
                    if (ChosenItem.Name== "1 Plansza")
                    {
                        Console.Clear();
                        Console.WriteLine("1 MIsja");
                        Console.ReadKey();
                    }
                    Menu.Close = true;
                    break;
                default:
                    EnableChoice();
                    break;
            }
            Print();
        }

        internal void ServeMenu()
        {
            do
            {
                Print();
                EnableChoice();

            } while (!Menu.Close);
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine();
            foreach (var menuItem in Menu.MenuItems)
            {
                if (menuItem.IsChosen)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\t{menuItem.Name}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"\t{menuItem.Name}");
                }

            }
        }

        public MenuItem ChosenItem
        {
            get { return Menu.MenuItems.FirstOrDefault(x => x.IsChosen == true); }
        }

        private int ChosenItemIndex
        {
            get { return Menu.MenuItems.IndexOf(ChosenItem); }
        }

        public MenuItem NextItem()
        {
            if (ChosenItem != Menu.MenuItems.Last())
            {
                int newIndex = ChosenItemIndex + 1;
                ChosenItem.IsChosen = false;
                Menu.MenuItems[newIndex].IsChosen = true;
            }
            return ChosenItem;
        }

        public MenuItem PreviousItem()
        {
            if (ChosenItem != Menu.MenuItems.First())
            {
                int newIndex = ChosenItemIndex - 1;
                ChosenItem.IsChosen = false;
                Menu.MenuItems[newIndex].IsChosen = true;
            }
            return ChosenItem;
        }

        public void Add(MenuItem menuItem)
        {
            Menu.MenuItems.Add(menuItem);
            if (Menu.MenuItems.Count == 1)
            {
                menuItem.IsChosen = true;
            }
        }

       
    }
}

