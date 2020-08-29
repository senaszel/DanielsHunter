using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Entity;
using System;

namespace DanielsHunter.App.Manager
{
    internal class MenuManager
    {
        public MenuManager()
        {
        }

        internal void EnabelActionChoice(Screen screen, User user,AssetService assetService)
        {
            int currentChoice = 0;
            (ConsoleKey key, int newChoice) usersChoice;
            GameState.Wait = true;
            do
            {
                Console.Clear();
                (int currentlyPointedAt, int lengthOf) crossMediaBar = new ScreenManager(screen).FillFooterMenuWithContent(currentChoice, "chop tree", "brak opcji", "brak opcji", "brak opcji");
                new ScreenManager(screen).ShowScreen(true);
                usersChoice = ChooseAction(crossMediaBar);
                currentChoice = usersChoice.newChoice;
                GameState.Wait = usersChoice.key == ConsoleKey.NumPad5 ? false : true;

            } while (GameState.Wait == true);

            if (currentChoice == 0)
            {
                new UserActionManager(user).ChopTree(screen.Board,assetService);
            }
        }


        private (ConsoleKey, int) ChooseAction((int currentlyPointedAt, int maxNb) crossMediaBar)
        {
            ConsoleKey usersChoice;
            int newChoice;
            do
            {
                usersChoice = Console.ReadKey(true).Key;
                newChoice = usersChoice switch
                {
                    ConsoleKey.NumPad5 => crossMediaBar.currentlyPointedAt,
                    ConsoleKey.NumPad8 => crossMediaBar.currentlyPointedAt - 1 >= 0 ? crossMediaBar.currentlyPointedAt - 1 : crossMediaBar.maxNb - 1,
                    ConsoleKey.NumPad2 => crossMediaBar.currentlyPointedAt + 1 < crossMediaBar.maxNb ? crossMediaBar.currentlyPointedAt + 1 : 0,
                    _ => int.MaxValue
                };
            } while (newChoice == int.MaxValue);
            return (usersChoice, newChoice);
        }
    }
}