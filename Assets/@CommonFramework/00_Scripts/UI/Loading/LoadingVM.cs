using System;
using R3;
using UnityEngine;

namespace Cappcn.UI
{
    public class LoadingVM : IDisposable
    {
        public ReadOnlyReactiveProperty<float> Progress { get; }
        public LoadingVM(ILoadingSource source)
        {
            Progress = source.LoadingProgress;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}