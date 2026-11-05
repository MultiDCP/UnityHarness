using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using R3;
using TMPro;

namespace Cappcn.UI
{
    public class LoadingView : MonoBehaviour
    {
        [SerializeField] private Image _progress;
        [SerializeField] private TMP_Text _text;

        public void Bind(LoadingVM vm)
        {
            vm.Progress.Subscribe(x =>
            {
               _progress.fillAmount = x;
               _text.SetText("{0} %", x * 100); 
            }).AddTo(this);
        }
    }
}