using System;
using System.Linq;

namespace DanielsHunter
{
    class Board
    {
        public int Height { get => 20; }
        public int Width { get => 50; }

        public int Offset { get => 4; }
        public string[] View { get; set; }

        public Board()
        {
            View = new string[Height + 1];
        }
    }
}