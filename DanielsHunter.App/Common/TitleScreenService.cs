using System;
using System.Linq;

namespace DanielsHunter.App.Common
{
    public class TitleScreenService
    {
        public void TitleScreen()
        {
            string title = "D A N I E L S   H U N T E R";
            Display(title);
        }

        public void FullScreenWarning()
        {
            string warning = "W A R N I N G  !";
            string please = "Please use F11 or alt+enter to enter Full Screen mode";
            string otherwise = "otherwise game may crash.";
            Display(warning,please,otherwise);
        }

        private static void Display(params string[] stringish)
        {

            int longestStrLength = string.Empty.Length;
            stringish.ToList().ForEach(str => longestStrLength = str.Length > longestStrLength ? str.Length : longestStrLength);
            Console.Clear();
            for (int currentParam = 0; currentParam <stringish.Length ; currentParam++)
            {
            Console.SetCursorPosition(Console.WindowWidth / 2 - longestStrLength, Console.WindowHeight / 2 + currentParam);
            Console.WriteLine(stringish[currentParam]);
            }
            Console.ReadKey(true);
        }
    }
}
