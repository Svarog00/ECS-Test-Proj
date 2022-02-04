using Assets.Code.Data;
using UnityEngine;

namespace Assets.Code.Infrastructure.AssetManagment
{
    public interface IAssetProvider
    {
        PlayerDataObject GetPlayerData();
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 position);
    }
}