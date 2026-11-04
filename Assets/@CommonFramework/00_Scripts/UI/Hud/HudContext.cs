using Cappcn.DataStore;
using UnityEngine;
using VContainer;

namespace Cappcn.UI
{
    public class HudContext : MonoBehaviour
    {
        [SerializeField] private HudView _view;
        private HudVM _vm;

        [Inject]
        public void Inject(IUIReader reader, IPlayerDataReader playerData)
        {
           _vm = new HudVM(reader, playerData);
           _view.Bind(_vm);
        }

        void OnDestroy()
        {
            _vm?.Dispose();
        }
    }
}