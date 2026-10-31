using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cappcn.Input
{
    public class UIInputModule : GameInput.IUIActions, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OnNewaction(InputAction.CallbackContext context)
        {
            throw new NotImplementedException();
        }
    }
}