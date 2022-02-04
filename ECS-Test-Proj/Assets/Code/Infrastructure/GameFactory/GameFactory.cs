using Assets.Code.Data;
using Assets.Code.Infrastructure.AssetManagment;
using UnityEngine;

namespace Assets.Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateHero(GameObject initialPoint)
        {
            return _assetProvider.Instantiate(AssetPaths.PlayerDataPath, position: initialPoint.transform.position);
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPaths.UIPath);
        }
    }
}
