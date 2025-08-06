using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoButton : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private SudokuGameManager sudokuGameManager;
	[SerializeField] private TextMeshProUGUI buttonLabel; // ボタン上のテキスト
	[SerializeField] private Image buttonImage; // 背景色用

	private Color onColor = Color.green;
	private Color offColor = Color.white;

	void Start()
	{
		button.onClick.AddListener(OnClick);
		UpdateVisual(); // 初期状態を反映
	}

	void OnClick()
	{
		sudokuGameManager.ToggleMemoMode();
		UpdateVisual();
	}

	private void UpdateVisual()
	{
		if (sudokuGameManager.memoMode)
		{
			if (buttonLabel != null) buttonLabel.text = "Memo: ON";
			if (buttonImage != null) buttonImage.color = onColor;
		}
		else
		{
			if (buttonLabel != null) buttonLabel.text = "Memo: OFF";
			if (buttonImage != null) buttonImage.color = offColor;
		}
	}
}
