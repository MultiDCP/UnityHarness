using Cappcn.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace Cappcn.Actors
{
    public class PlayerView : MonoBehaviour
    {
        private Vector3 _moveDir;

        public void SetVelocity(Vector3 v)
        {
            _moveDir = v;
        }

        private void FixedUpdate()
        {
            transform.Translate(_moveDir * Time.fixedDeltaTime);
        }
    }
}