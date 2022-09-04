using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Code.Input
{
    class InputService : IInputService
    {
        private readonly Controls _inputSource;
        private readonly InputAction _movement;

        public InputService()
        {
            _inputSource = new Controls();

            _movement = _inputSource.Player.Movement;
            _movement.Enable();
        }

        public Vector2 GetInput()
        {
            return _movement.ReadValue<Vector2>();
        }

        ~InputService()
        {
            _movement.Disable();
        }
    }
}
