using UnityEngine;
using UnityEngine.UI;

public class ClearButton : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private SudokuGameManager sudokuGameManager;

	void Start()
	{
		button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		sudokuGameManager.InputNumber(0); // ✅ number=0で選択セルをクリア
	}
}
