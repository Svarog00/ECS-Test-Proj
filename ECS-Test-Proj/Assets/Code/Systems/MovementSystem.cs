using Assets.Code.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Code.Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<DirectionComponent, MovableComponent> _movableFilter = null;

        public void Run()
        {
            foreach (var entity in _movableFilter)
            {
                ref var directionComponent = ref _movableFilter.Get1(entity);
                ref var movableComponent = ref _movableFilter.Get2(entity);

                movableComponent.Transform.position += movableComponent.Speed * Time.deltaTime * (Vector3)directionComponent.Direction;
            }
        }
    }
}