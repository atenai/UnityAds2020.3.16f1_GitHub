using UnityEngine;

namespace 探偵
{
    public class Main : MonoBehaviour
    {
        [SerializeField] ClueResearchView clueResearchView;
        [SerializeField, Tooltip("オンにするとAIを呼ばずにテスト用の結果を返す（Claudeの使用量が減らない）")]
        bool useFakeResearcher;

        IAiResearcher _researcher;
        ClueResearchPresenter _presenter;

        void Start()
        {
            _researcher = Factories.CreateResearcher(useFakeResearcher);
            ClueResearchModel model = new ClueResearchModel(_researcher);
            _presenter = new ClueResearchPresenter(model, clueResearchView, Factories.CreateLinkOpener());
        }

        void OnDestroy()
        {
            _researcher?.Cancel(); // ゲームを閉じたときに、Claude Codeが裏に残らないように
        }
    }
}
