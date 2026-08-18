using System;
using UnityEngine;
using UnityEngine.UI;

namespace ポイ活
{
    /// <summary>タスク一覧の1行。表示するだけで、何を出すかはPresenterが決める。</summary>
    public class TaskRowView : MonoBehaviour
    {
        [SerializeField] Toggle doneToggle;
        [SerializeField] Text titleText;
        [SerializeField] Text detailText;
        [SerializeField] Text remainText;
        [SerializeField] Button openButton;
        [SerializeField] Image background;
        [SerializeField] InputField pointsInput;

        static readonly Color DoneColor = new Color(0.82f, 0.88f, 0.82f);
        static readonly Color TodoColor = new Color(1f, 1f, 1f);

        public void Bind(string title, string detail, string remain, bool isDone, bool canOpen, int earnedPoints,
            Action<bool> onToggle, Action onOpen, Action<int> onPointsChanged)
        {
            titleText.text = title;
            detailText.text = detail;
            remainText.text = remain;

            pointsInput.onEndEdit.RemoveAllListeners();
            pointsInput.text = earnedPoints.ToString();
            pointsInput.onEndEdit.AddListener(value =>
            {
                int parsed;
                if (!int.TryParse(value, out parsed) || parsed < 0) parsed = 0;
                pointsInput.text = parsed.ToString(); // 変な入力は直して見せる
                onPointsChanged?.Invoke(parsed);
            });

            doneToggle.onValueChanged.RemoveAllListeners();
            doneToggle.isOn = isDone; // リスナー登録前に入れて、初期化でコールバックが飛ばないようにする
            doneToggle.onValueChanged.AddListener(value =>
            {
                SetCompletedLook(value);
                onToggle?.Invoke(value);
            });
            SetCompletedLook(isDone);

            openButton.onClick.RemoveAllListeners();
            openButton.onClick.AddListener(() => onOpen?.Invoke());
            openButton.gameObject.SetActive(canOpen);
        }

        public void SetRemainText(string remain)
        {
            remainText.text = remain;
        }

        void SetCompletedLook(bool isDone)
        {
            background.color = isDone ? DoneColor : TodoColor;
            titleText.color = isDone ? new Color(0.45f, 0.45f, 0.45f) : new Color(0.15f, 0.15f, 0.15f);
        }
    }
}
