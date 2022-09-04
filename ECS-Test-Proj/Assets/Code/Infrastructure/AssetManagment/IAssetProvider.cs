using Assets.Code.Data;
using UnityEngine;

namespace Assets.Code.Infrastructure.AssetManagment
{
    public interface IAssetProvider
    {
        DataType GetData<DataType>(string path) where DataType : ScriptableObject;
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 position);
    }
}