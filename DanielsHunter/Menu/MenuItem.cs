namespace DanielsHunter
{
    public class MenuItem
    {
        internal string Name { get; set; }
        internal bool IsChosen { get; set; }

        private MenuItem()
        {
            IsChosen = false;
        }

        public MenuItem(string name)
            : base()
        {
            Name = name;
        }
    }
}