using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Code.Input
{
    class PlayerControl
    {
        private Controls _inputSource;
        private InputAction _movement;

        public PlayerControl()
        {
            _inputSource = new Controls();

            _movement = _inputSource.Player.Movement;
            _movement.Enable();
        }

        public Vector2 GetInput()
        {
            return _movement.ReadValue<Vector2>();
        }

        ~PlayerControl()
        {
            _movement.Disable();
        }
    }
}
