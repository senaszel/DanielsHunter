namespace DanielsHunter
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Offset { get; set; }
        public string[] PlayArea { get; set; }
        public AssetsRepository AssetsRepository;


        public Board(int height, int width, int offset,AssetsRepository assetsRepository)
        {
            Height = height;
            Width = width;
            Offset = offset;
            PlayArea = new string[height];
            AssetsRepository = assetsRepository;
        }
    }
}