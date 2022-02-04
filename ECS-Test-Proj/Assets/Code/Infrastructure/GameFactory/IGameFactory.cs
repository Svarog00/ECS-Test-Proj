using UnityEngine;

namespace Assets.Code.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateHero(GameObject initialPoint);
        void CreateHud();
    }
}