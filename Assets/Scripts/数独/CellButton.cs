using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Net.NetworkInformation;

public class CellButton : MonoBehaviour
{
	[SerializeField] private Button button;
	[SerializeField] private TextMeshProUGUI buttonText;
	[SerializeField] private Image image;

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

		// 問題に数字があるセルは入力不可にする
		button.interactable = questionNumber == 0;
	}

	public void OnClick()
	{
		Debug.Log($"ボタン (縦:{row}, 横:{col}) がクリックされました!");
		Debug.Log($"答え番号: {answerNumber}");
		Debug.Log($"問題番号: {questionNumber}");

		SudokuGameManager.Instance.SelectCell(this);
	}

	//5
	public void SetNumber(int number)
	{
		Debug.Log("<color=green>入力番号 : " + number + "</color>");
		buttonText.text = number == 0 ? "" : number.ToString();

		//6
		// 入力ごとに判定する
		SudokuGameManager.Instance.CheckAnswer(this, number);
	}

	// 背景色を変更する（正解・不正解）
	public void SetColor(Color color)
	{
		if (image != null)
		{
			image.color = color;
		}
	}

	// 正解時にセルを固定
	public void LockCell()
	{
		button.interactable = false;
	}
}