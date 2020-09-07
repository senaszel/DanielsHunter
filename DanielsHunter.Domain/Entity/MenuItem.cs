using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter.Domain.Entity
{
    public class MenuItem : BaseEntity
    {
        public bool CanNOTbeChosen { get; set; }
        public string Name { get; set; }

        public MenuItem(string name, bool isCurrent, bool canNOTbeChosen)
        {
            Name = name;
            IsCurrent = isCurrent;
            CanNOTbeChosen = canNOTbeChosen;
        }
    }
}
