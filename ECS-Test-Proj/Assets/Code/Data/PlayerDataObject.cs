using UnityEngine;

namespace Assets.Code.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 0)]
    public class PlayerDataObject : ScriptableObject
    {
        public GameObject PlayerObjectPrefab;
        public float Speed;
        public int HealthPoints;
    }
}