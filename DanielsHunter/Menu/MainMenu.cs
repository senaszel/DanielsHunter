using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter
{
    public class MainMenu : Menu
    {
        public MainMenu(string name) : base(name)
        {
            Seed();
        }

        private void Seed()
        {
            MenuService menuService = new MenuService(this);
            menuService.Add(new MenuItem("1 Plansza"));
            menuService.Add(new MenuItem("Wyjście"));
        }
    }
}
