using System.Collections.Generic;

namespace DanielsHunter
{
    public class SymbolRepository
    {
        public Tree Tree { get; set; }
        public Daniel Daniel { get; set; }

        public SymbolRepository()
        {
            Tree = new Tree();
            Daniel = new Daniel();
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
