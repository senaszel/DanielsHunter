using System.Collections.Generic;
using System.Linq;

namespace DanielsHunter
{
    public class AssetsRepository
    {
        private List<Asset> Assets { get; set; }
        private List<string> Symbols { get; set; }

        public AssetsRepository()
        {
            Symbols = new List<string>();
            Add2Symbols(new User());
            Add2Symbols(new Daniel());
            Add2Symbols(new Tree());
        }

        public void Add2Assets(Asset asset)
        {
            Assets.Add(asset);
        }

        public void Add2Symbols(Asset asset)
        {
            Symbols.Add(asset.Symbol);
        }

        public string GetSymbol(Asset asset)
        {
            return Symbols.Find(x => x == asset.Symbol).FirstOrDefault().ToString();
        }

        public List<Asset> GetAllAssets()
        {
            return Assets;
        }

        public List<string> GetAllSymbols()
        {
            return Symbols;
        }
    }
}
