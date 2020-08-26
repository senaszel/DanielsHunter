using DanielsHunter.Model;
using System;
using System.Reflection.Metadata.Ecma335;

namespace DanielsHunter.Service
{
    internal class MenuService
    {
        public MenuService()
        {
        }

        internal void EnabelActionChoice(Screen screen, User user)
        {
            int currentChoice = 0;
            (ConsoleKey key, int newChoice) usersChoice;
            GameState.Wait = true;
            do
            {
                Console.Clear();
                (int currentlyPointedAt, int lengthOf) crossMediaBar = new ScreenService(screen).FillFooterMenuWithContent(currentChoice, "chop tree", "brak opcji", "brak opcji", "brak opcji");
                new ScreenService(screen).ShowScreen(true);
                usersChoice = ChooseAction(crossMediaBar);
                currentChoice = usersChoice.newChoice;
                GameState.Wait = usersChoice.key == ConsoleKey.NumPad5 ? false : true;

            } while (GameState.Wait == true);
          
            if (currentChoice == 0)
            {
                new UserService(user).ChopTree(screen.Board);
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