using Cappcn.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Cappcn.Manager
{
    public sealed class OptionManager
    {
        private readonly DataProvider _dataProvider;
        public OptionManager(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }    

        private OptionsData _data;
        public void Load()
        {
            _dataProvider.Load<OptionsData>().ContinueWith(x =>
            {
                _data = x;
            });
        }
        public void Save(OptionsData data) => _dataProvider.Save(data);
    }
}