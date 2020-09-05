using DanielsHunter.App.Common;
using DanielsHunter.App.Concrete;
using DanielsHunter.App.Helpers;
using DanielsHunter.App.Manager;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            new TitleScreenService().FullScreenWarning();
            //new IntroService().Intro();
            //new TitleScreenService().TitleScreen();

            Game newGame = new Game();
            new InitialisationHelper().Set(newGame);
            new GameManager(newGame).Run();
        }
    }
}
