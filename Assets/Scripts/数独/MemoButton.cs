using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoButton : MonoBehaviour
{
	[SerializeField] private SudokuGameManager sudokuGameManager;
	/// <summary>
	/// ボタンの背景
	/// </summary>
	[SerializeField] private Image image;
	/// <summary>
	/// ボタン
	/// </summary>
	[SerializeField] private Button button;
	/// <summary>
	/// ボタンのテキスト
	/// </summary>
	[SerializeField] private TextMeshProUGUI text;

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

	/// <summary>
	/// メモボタンのビジュアルを更新
	/// </summary>
	private void UpdateVisual()
	{
		if (sudokuGameManager.memoMode)
		{
			if (text != null)
			{
				text.text = "Memo: ON";
			}
			if (image != null)
			{
				image.color = Color.green;
			}
		}
		else
		{
			if (text != null)
			{
				text.text = "Memo: OFF";
			}
			if (image != null)
			{
				image.color = Color.white;
			}
		}
	}
}
