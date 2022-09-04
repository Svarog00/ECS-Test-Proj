using Assets.Code.Data;
using UnityEngine;

namespace Assets.Code.Infrastructure.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public DataType GetData<DataType>(string path) where DataType : ScriptableObject
        {
            var obj = Resources.Load(AssetPaths.PlayerDataPath) as PlayerDataObject;
            return obj as DataType;
        }

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 position)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
