using UnityEngine;

namespace 人物検索
{
    public class Main : MonoBehaviour
    {
        [SerializeField] PersonTableView personTableView;

        PersonTablePresenter _presenter;

        void Start()
        {
            PersonTableModel model = new PersonTableModel(Factories.CreateSearchService());
            _presenter = new PersonTablePresenter(model, personTableView, Factories.CreateImageLoader(personTableView));
        }
    }
}
