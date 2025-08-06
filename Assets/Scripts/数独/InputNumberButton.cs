using UnityEngine;
using UnityEngine.UI;

public class InputNumberButton : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] int number;
	[SerializeField] SudokuGameManager sudokuGameManager;

	void Start()
	{
		button.onClick.AddListener(OnClick);
	}

	//1
	private void OnClick()
	{
		//2
		sudokuGameManager.InputNumber(number);
	}
}
