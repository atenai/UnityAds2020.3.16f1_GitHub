using UnityEngine;

public class SudokuGameManager : MonoBehaviour
{
	public static SudokuGameManager Instance { get; private set; }

	[SerializeField] private CellButton selectedCell;

	void Awake()
	{
		Instance = this;
	}

	public void SelectCell(CellButton cell)
	{
		selectedCell = cell;
		Debug.Log($"ボタン (縦:{selectedCell.Row}, 横:{selectedCell.Col}) がクリックされました!");
		Debug.Log($"答え番号: {selectedCell.AnswerNumber}");
		Debug.Log($"問題番号: {selectedCell.QuestionNumber}");
	}

	//3
	public void InputNumber(int number)
	{
		if (selectedCell != null)
		{
			//4
			selectedCell.SetNumber(number);
			selectedCell = null;
		}
	}

	//7
	// 判定処理
	public void CheckAnswer(CellButton cell, int number)
	{
		if (number == 0) return; // 入力を消した場合は判定しない

		if (cell.AnswerNumber == number)
		{
			Debug.Log($"({cell.Row},{cell.Col}) 正解！");
			cell.SetColor(Color.green);
			cell.LockCell(); // 正解したらそのセルをロック
		}
		else
		{
			Debug.Log($"({cell.Row},{cell.Col}) 不正解！");
			cell.SetColor(Color.red);
		}
	}
}
