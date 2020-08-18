namespace DanielsHunter
{
    public class MenuItem
    {
        private static int nextId = 1;
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal bool IsChosen { get; set; }

        private MenuItem()
        {
            IsChosen = false;
            Id = nextId++;
        }

        public MenuItem(string name)
            : base()
        {
            Name = name;
        }
    }
}