using System;
using UnityEngine;
using VContainer.Unity;

namespace Cappcn.Input
{
    public sealed class InputManager : IInputReader, IInitializable, IDisposable
    {
        public Vector2 Move => _inputActions.Player.Move.ReadValue<Vector2>();
        public bool isJumpPressed => _inputActions.Player.Jump.WasPressedThisFrame();

        private GameInput _inputActions;
        public void Initialize()
        {
            _inputActions = new();
            _inputActions.Enable();
        }

        public void Dispose()
        {
            _inputActions.Disable();
            _inputActions.Dispose();
        }
    }
}