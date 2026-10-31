using Cappcn.Input;
using UnityEngine;
using VContainer;

namespace Cappcn.Actors
{
    public sealed class PlayerContext : MonoBehaviour
    {
        [SerializeField] private PlayerView _view;
        private PlayerActor _actor;

        [Inject]
        public void Init(IInputReader input)
        {
            _actor = new(input, _view);
            _actor.Init();
        }

        private void Destroy()
        {
            _actor?.Dispose();
        }
    }
}