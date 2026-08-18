using UnityEngine;

namespace ポイ活
{
    public class Main : MonoBehaviour
    {
        [SerializeField] TaskCatalog taskCatalog;
        [SerializeField] PoikatsuView poikatsuView;

        PoikatsuPresenter _presenter;

        void Start()
        {
            PoikatsuModel model = new PoikatsuModel(taskCatalog, Factories.CreateRepository(),
                Factories.CreateLedgerRepository(), Factories.CreateSettingsRepository());
            _presenter = new PoikatsuPresenter(model, poikatsuView, Factories.CreateNotifier(poikatsuView),
                Factories.CreateLinkOpener());
        }
    }
}
