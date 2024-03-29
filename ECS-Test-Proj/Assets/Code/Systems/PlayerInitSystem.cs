﻿using Assets.Code.Components;
using Assets.Code.Data;
using Assets.Code.Infrastructure.AssetManagment;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Code.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private const string InitialPointTag = "InitialPoint";
        
        private readonly EcsWorld _world = null;
        private readonly IAssetProvider _assetProvider;

        public PlayerInitSystem(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Init()
        {
            PlayerDataObject playerData = _assetProvider.GetData<PlayerDataObject>(AssetPaths.PlayerDataPath);

            var player = _world.NewEntity();

            ref var movableComponent = ref player.Get<MovableComponent>();

            GameObject playerObject = GameObject.Instantiate(playerData.PlayerObjectPrefab, GameObject.FindGameObjectWithTag(InitialPointTag).transform);
            playerObject.transform.parent = null;

            movableComponent.Transform = playerObject.transform;
            movableComponent.Speed = playerData.Speed;
            
            player.Get<DirectionComponent>();

        }
    }
}
