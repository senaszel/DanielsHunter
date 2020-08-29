using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Common;

namespace DanielsHunter.App.Manager
{
    class AssetManager
    {
        private AssetService assetService;
        private BoardManager boardManager;
        public AssetManager(Game game)
        {
            this.assetService = game.assetService;
            this.boardManager = game.boardManager;
        }

        public void PlaceAssetOnTheBoard(Asset asset)
        {
            assetService.AddToAssetRepository(asset);
            boardManager.InsertSymbolIntoPlayArea(asset.X, asset.Y, asset.Symbol);
        }

        public void RemoveAssetFromTheBoard(Asset asset)
        {
            assetService.RemoveFromAssetsRepository(asset);
            boardManager.RemoveSymbolFromPlayArea(asset.X, asset.Y);
        }
    }
}
