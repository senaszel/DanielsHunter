using System;
using System.Collections.Generic;
using System.Text;

namespace DanielsHunter
{
    public class SymbolRepository
    {
        public Tree Tree { get; set; }

        public SymbolRepository()
        {
            Tree = new Tree();
        }

        public List<string> Symbols
        {
            get => new List<string>()
        {
            Tree.Symbol,
            "d",
            "m",
            "@"

        };

        }
    }
}
