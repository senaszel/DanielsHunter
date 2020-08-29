using DanielsHunter.App.Common;
using DanielsHunter.App.Manager;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
           // IntroService.Intro();
           // TitleScreenService.TitleScreen();
            new GameManager().Set()
                             .Run();
        }
    }
}
