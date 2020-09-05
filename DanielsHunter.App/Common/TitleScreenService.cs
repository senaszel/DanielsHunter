using System;

namespace DanielsHunter.App.Common
{
    public class TitleScreenService
    {
        public void TitleScreen()
        {
            Console.Clear();
            string title = "D A N I E L S   H U N T E R";
            Console.SetCursorPosition(Console.WindowWidth / 2 - title.Length, Console.WindowHeight / 2);
            Console.WriteLine(title);
            Console.ReadKey(true);
        }
    }
}
