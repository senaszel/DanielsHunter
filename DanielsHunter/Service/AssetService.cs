using DanielsHunter.Model;
using System.Collections.Generic;
using System.Linq;

namespace DanielsHunter.Service
{
    public class AssetService
    {
        private Dictionary<(int, int), IAsset> Assets { get; set; }
        private List<(string name, (int x, int y) key)> Keys { get; set; }

        public AssetService()
        {
            Assets = new Dictionary<(int, int), IAsset>();
            Keys = new List<(string name, (int x, int y) key)>();
        }


        public void AddToAssetRepository(IAsset asset)
        {
            if (!IsAsset(asset.Key))
            {
                Add2Assets(asset);
                Add2Keys(asset);
            }
            else
            {
                RemoveFromAssetsRepository(asset.Key);
                AddToAssetRepository(asset);
            }
        }

        private void Add2Keys(IAsset asset)
        {
            Keys.Add((asset.Name, asset.Key));
        }


        private void Add2Assets(IAsset asset)
        {
            if (Assets.TryAdd(asset.Key, asset)) { }
            else
            {
                RemoveFromAssetsRepository(asset.Key);
            //    RemoveFromKeys(asset);
                Add2Assets(asset);
            }
        }

        internal bool IsAsset((int x, int y)key)
        {
            return Assets.ContainsKey(key);
        }
        internal bool IsAsset(string name)
        {
            var key = Keys.FirstOrDefault(x => x.name == name);
            return Assets.ContainsKey(key.key);
        }

        public IAsset GetAsset((int x, int y) key)
        {
            Assets.TryGetValue(key, out IAsset asset);
            return asset;
        }

        public IAsset GetAsset(string name)
        {
            (string name, (int x, int y) key) key = Keys.Where(x => x.name == name).FirstOrDefault();
            return Assets[key.key];
        }

        internal bool RemoveFromAssetsRepository((int x, int y) key)
        {
            IAsset asset = GetAsset(key);
            if (IsAsset(key))
            {
                if (RemoveFromAsseets(asset))
                {
                    if (RemoveFromKeys(asset))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        internal bool RemoveFromAssetsRepository(IAsset asset)
        {
            if (IsAsset(asset.Key))
            {
                if (RemoveFromAsseets(asset))
                {
                    if (RemoveFromKeys(asset))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool RemoveFromAsseets(IAsset asset)
        {
            return Assets.Remove((asset.Key));
        }

        private bool RemoveFromKeys(IAsset asset)
        {
            return Keys.Remove((asset.Name, asset.Key));
        }

    }
}
