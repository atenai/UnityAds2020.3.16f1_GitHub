using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] int number;

	void Start()
	{
		button.onClick.AddListener(OnClick);
	}

	//1
	public void OnClick()
	{
		//2
		SudokuGameManager.Instance.InputNumber(number);
	}
}
