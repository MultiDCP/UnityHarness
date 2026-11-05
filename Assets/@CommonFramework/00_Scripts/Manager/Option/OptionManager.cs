using Cappcn.Data;
using Cappcn.DI;
using Cysharp.Threading.Tasks;

namespace Cappcn.Manager
{
    public sealed class OptionManager : IRootTask
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

        public async UniTask WaitUntilReadyAsync()
        {
            _data = await _dataProvider.Load<OptionsData>();
        }
    }
}