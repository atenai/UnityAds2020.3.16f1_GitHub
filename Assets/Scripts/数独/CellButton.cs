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
	private int answerNumber;
	public int AnswerNumber { get => answerNumber; set => answerNumber = value; }
	private int questionNumber;
	public int QuestionNumber { get => questionNumber; set => questionNumber = value; }

	public void Initialize(int row, int col, int answerNumber, int questionNumber)
	{
		this.row = row;
		this.col = col;
		this.answerNumber = answerNumber;
		this.questionNumber = questionNumber;

		buttonText.text = questionNumber == 0 ? "" : questionNumber.ToString();
		button.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		Debug.Log($"ボタン (縦:{row}, 横:{col}) がクリックされました!");
		Debug.Log($"答え番号: {answerNumber}");
		Debug.Log($"問題番号: {questionNumber}");
	}
}