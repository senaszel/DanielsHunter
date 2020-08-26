using DanielsHunter.Common;
using DanielsHunter.Service;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            IntroService.Intro();
            TitleScreenService.TitleScreen();
            new GameService().Set().Start();
        }
    }
}
