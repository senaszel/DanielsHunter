using DanielsHunter.App.Common;
using DanielsHunter.Domain.Common;
using System.Linq;

namespace DanielsHunter.App.Concrete
{
    public class AssetService : BaseService<Asset>
    {
        public Asset GetAsset(string name)
        {
            return Items.Where(x => x.Name == name).First();
        }

        public Asset GetAsset((int X, int Y) key)
        {
            return Items.Where(x => x.Key == key).First();
        }

        public void RemoveFromAssetsRepository(Asset asset)
        {
            RemoveItem(asset);
        }

        public void AddToAssetRepository(Asset asset)
        {
            AddItem(asset);
        }

        public bool IsAsset((int X, int Y) key)
        {
            return Items.Any(item => item.Key == key);
        }

        public bool IsAsset(string name)
        {
            return Items.Any(item => item.Name == name);
        }
    }
}
