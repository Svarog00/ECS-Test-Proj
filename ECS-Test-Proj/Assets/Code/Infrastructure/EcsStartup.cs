using Assets.Code.Systems;
using Leopotam.Ecs;
using System;
using UnityEngine;

namespace Assets.Code.Infrastructure
{
    class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            InitEntities();
            InitSystems();
            
        }


        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }

        private void InitEntities()
        {
            
        }

        private void InitSystems()
        {
            _systems.Add(new PlayerInputSystem());
            _systems.Add(new MovementSystem());

            _systems.Init();
        }
    }
}
