﻿using Assets.Code.Components;
using Assets.Code.Input;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Code.Systems
{
    class PlayerInputSystem : IEcsRunSystem
    {
        private IInputService _playerControl;

        private readonly EcsWorld _world = null;
        private readonly EcsFilter<DirectionComponent> _inputFilter = null;

        public PlayerInputSystem(IInputService inputService)
        {
            _playerControl = inputService;
        }

        public void Run()
        {
            foreach(var i in _inputFilter)
            {
                ref var directionComponent = ref _inputFilter.Get1(i);
                ref var direction = ref directionComponent.Direction;

                direction = _playerControl.GetInput();
            }
        }
    }
}
