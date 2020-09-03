using System.Linq;

namespace DanielsHunter.Domain.Entity
{
    public class Board : BaseEntity
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Offset { get; set; }
        public string[] PlayArea { get; set; }

        public Board()
        {
            this.PlayArea = new string[0];
        }
        public Board(int height, int width, int offset)
        {
            Height = height;
            Width = width;
            Offset = offset;
            PlayArea = new string[height];
        }
    }
}