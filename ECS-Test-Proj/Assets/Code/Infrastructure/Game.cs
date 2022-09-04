using Assets.Code.Infrastructure.AssetManagment;
using Assets.Code.Infrastructure.Factory;
using Assets.Code.Systems;
using Leopotam.Ecs;

namespace Assets.Code.Infrastructure
{
    class Game
    {
        private readonly EcsWorld _world;
        private readonly EcsSystems _updateSystems;
        private readonly EcsSystems _fixedUpdateSystems;
        private readonly IGameFactory _gameFactory;
        private readonly IAssetProvider _assetProvider;

        public Game()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);

            _assetProvider = new AssetProvider();
            _gameFactory = new GameFactory(_assetProvider);

            InitEntities();
            InitSystems();
        }

        private void InitSystems()
        {
            _updateSystems
                .Add(new PlayerInitSystem(_assetProvider))
                .Add(new PlayerInputSystem())
                .Add(new MovementSystem());

            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        ~Game()
        {
            _updateSystems.Destroy();
            _world.Destroy();
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

    }
}
