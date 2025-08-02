using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Net.NetworkInformation;

public class CellButton : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private TextMeshProUGUI buttonText;

	private int row;
	public int Row { get => row; set => row = value; }
	private int col;
	public int Col { get => col; set => col = value; }
	private int questionNumber;
	public int QuestionNumber { get => questionNumber; set => questionNumber = value; }

	public void Initialize(int row, int col, int questionNumber)
	{
		this.row = row;
		this.col = col;
		this.questionNumber = questionNumber;

		buttonText.text = questionNumber == 0 ? "" : questionNumber.ToString();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		Debug.Log($"ボタン番号 ({row}, {col}) がクリックされました!");
		Debug.Log($"質問番号: {questionNumber}");
	}
}