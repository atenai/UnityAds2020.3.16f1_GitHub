using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{
	[SerializeField] private Image image;
	[SerializeField] private Button button;
	[SerializeField] private TextMeshProUGUI buttonText;
	[SerializeField] private TextMeshProUGUI[] memoTexts; // 9個の小テキスト
	private bool[] memoActive = new bool[9]; // メモON/OFF管理

	private int row;
	public int Row { get => row; set => row = value; }
	private int col;
	public int Col { get => col; set => col = value; }
	private int answerNumber;
	public int AnswerNumber { get => answerNumber; set => answerNumber = value; }
	private int questionNumber;
	public int QuestionNumber { get => questionNumber; set => questionNumber = value; }

	private SudokuGameManager sudokuGameManager;

	/// <summary>
	/// 初期化処理
	/// </summary>
	/// <param name="row"></param>
	/// <param name="col"></param>
	/// <param name="answerNumber"></param>
	/// <param name="questionNumber"></param>
	public void Initialize(int row, int col, int answerNumber, int questionNumber, SudokuGameManager sudokuGameManager)
	{
		this.row = row;
		this.col = col;
		this.answerNumber = answerNumber;
		this.questionNumber = questionNumber;
		this.sudokuGameManager = sudokuGameManager;

		buttonText.text = questionNumber == 0 ? "" : questionNumber.ToString();
		button.onClick.AddListener(OnClick);

		// 問題に数字があるセルは入力不可にする
		button.interactable = questionNumber == 0;

		// メモ初期化
		ClearMemos();
	}

	public void OnClick()
	{
		Debug.Log($"ボタン (縦:{row}, 横:{col}) がクリックされました!");
		Debug.Log($"答え番号: {answerNumber}");
		Debug.Log($"問題番号: {questionNumber}");

		sudokuGameManager.SelectCell(this);
	}

	//5
	/// <summary>
	/// 入力番号
	/// </summary>
	/// <param name="number"></param>
	public void SetNumber(int number)
	{
		Debug.Log("<color=green>入力番号 : " + number + "</color>");
		buttonText.text = number == 0 ? "" : number.ToString();

		// 数字を入れたらメモを全消去
		ClearMemos();

		//6
		// 入力ごとに判定する
		sudokuGameManager.CheckAnswer(this, number);
	}

	// メモON/OFF切り替え
	public void ToggleMemo(int number)
	{
		int index = number - 1;
		if (index < 0 || index >= 9) return;

		memoActive[index] = !memoActive[index];
		memoTexts[index].gameObject.SetActive(memoActive[index]);
	}

	// 全メモをクリア
	public void ClearMemos()
	{
		for (int i = 0; i < memoTexts.Length; i++)
		{
			memoTexts[i].gameObject.SetActive(false);
			memoActive[i] = false;
		}
	}

	public void Highlight(bool isSelected)
	{
		if (isSelected)
		{
			SetColor(Color.cyan); // ✅ 選択中は水色で表示
		}
		else
		{
			SetColor(Color.white); // ✅ 通常時は白
		}
	}

	/// <summary>
	/// セルの背景色を変更する（正解・不正解・選択状態）
	/// </summary>
	/// <param name="color"></param>
	public void SetColor(Color color)
	{
		if (image != null)
		{
			image.color = color;
		}
	}

	/// <summary>
	/// 正解時にセルを固定
	/// </summary>
	public void LockCell()
	{
		button.interactable = false;
		ClearMemos(); // ✅ 正解時にメモも削除
	}
}