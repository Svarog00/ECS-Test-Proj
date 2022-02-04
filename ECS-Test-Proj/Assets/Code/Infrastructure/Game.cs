using Assets.Code.Infrastructure.AssetManagment;
using Assets.Code.Infrastructure.Factory;
using Assets.Code.Systems;
using Leopotam.Ecs;

namespace Assets.Code.Infrastructure
{
    class Game
    {
        private readonly EcsWorld _world;
        private readonly EcsSystems _systems;
        private readonly IGameFactory _gameFactory;
        private readonly IAssetProvider _assetProvider;

        //TODO:
        //private IGameFactory _gameFactory
        //InitPlayerSystem

        public Game()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _assetProvider = new AssetProvider();
            _gameFactory = new GameFactory(_assetProvider);

            InitEntities();
            InitSystems();
        }

        ~Game()
        {
            _systems.Destroy();
            _world.Destroy();
        }

        public void Run()
        {
            _systems.Run();
        }

        private void InitEntities()
        {

        }

        private void InitSystems()
        {
            _systems
                .Add(new PlayerInitSystem(_assetProvider))
                .Add(new PlayerInputSystem())
                .Add(new MovementSystem());

            _systems.Init();
        }
    }
}
