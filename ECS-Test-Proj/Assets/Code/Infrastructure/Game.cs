using Assets.Code.Infrastructure.AssetManagment;
using Assets.Code.Infrastructure.Factory;
using Assets.Code.Input;
using Assets.Code.Systems;
using Leopotam.Ecs;
using System;

namespace Assets.Code.Infrastructure
{
    class Game : IDisposable
    {
        private readonly EcsWorld _world;
        private readonly EcsSystems _updateSystems;
        private readonly EcsSystems _fixedUpdateSystems;

        private readonly IGameFactory _gameFactory;
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _inputService;

        public Game()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);

            _assetProvider = new AssetProvider();
            _inputService = new InputService();
            _gameFactory = new GameFactory(_assetProvider);

            InitEntities();
            InitSystems();
        }

        private void InitSystems()
        {
            _updateSystems
                .Add(new PlayerInitSystem(_assetProvider))
                .Add(new PlayerInputSystem(_inputService))
                .Add(new MovementSystem());

            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        public void RunUpdate()
        {
            _updateSystems.Run();
        }

        public void RunFixedUpdate()
        {
            _fixedUpdateSystems.Run();
        }

        private void InitEntities()
        {

        }

        public void Dispose()
        {
            _updateSystems.Destroy();
            _fixedUpdateSystems.Destroy();
            _world.Destroy();
        }
    }
}
