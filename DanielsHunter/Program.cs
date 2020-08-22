using System;

namespace DanielsHunter
{
    class Program
    {
        static void Main()
        {
            Common.Intro();
            Common.TitleScreen();
            new GameController().Set().Start();
        }
    }
}
