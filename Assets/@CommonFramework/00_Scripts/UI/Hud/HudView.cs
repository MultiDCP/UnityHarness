using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using R3;
using TMPro;

namespace Cappcn.UI
{
    public sealed class HudView : MonoBehaviour
    {
        [SerializeField] private Image _progress;
        [SerializeField] private TMP_Text _text;


        public void Bind(HudVM vm)
        {
            vm.IsVisible.Subscribe(x => gameObject.SetActive(x)).AddTo(this);

            vm.CurrentHp.Subscribe(x =>
            {
                _text.SetText("{0}%", x * 100);
                _progress.fillAmount = x;

            }).AddTo(this);
        }
    }
}