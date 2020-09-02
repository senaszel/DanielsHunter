using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Common;
using DanielsHunter.Domain.Entity;
using System;

namespace DanielsHunter.App.Manager
{
    public class AssetManager
    {
        private readonly AssetService assetService;
        private readonly BoardManager boardManager;
        public AssetManager()
        {
        }
        public AssetManager(Game game)
        {
            this.assetService = game.assetService;
            this.boardManager = game.boardManager;
        }

        public void IntroduceAsset(Asset asset)
        {
            assetService.AddToAssets(asset);
            boardManager.InsertSymbolIntoPlayArea(asset);
        }

        public void DisposeAsset(Asset asset)
        {
            assetService.RemoveFromAssets(asset);
            boardManager.RemoveSymbolFromPlayArea(asset.Key);
        }
    }
}
