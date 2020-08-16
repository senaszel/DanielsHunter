using System.Collections.Generic;
using System.Threading.Channels;

namespace DanielsHunter
{
    public class Menu
    {
        internal List<MenuItem> MenuItems { get; set; }
        internal string Name { get; set; }
        internal bool Close { get; set; }

        private Menu()
        {
            MenuItems = new List<MenuItem>();
            Close = false; 
        }
        public Menu(string name) : this()
        {
            Name = name;
        }
    }
}
