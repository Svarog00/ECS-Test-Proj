using Assets.Code.Systems;
using Leopotam.Ecs;
using System;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _updateSystems;

        private void Start()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);

            InitEntities();
            InitSystems();
            
        }


        private void Update()
        {
            _updateSystems.Run();
        }

        private void OnDestroy()
        {
            _updateSystems.Destroy();
            _world.Destroy();
        }

        private void InitEntities()
        {
            
        }

        private void InitSystems()
        {
            _updateSystems.Add(new PlayerInputSystem());
            _updateSystems.Add(new MovementSystem());

            _updateSystems.Init();
        }
    }
}
