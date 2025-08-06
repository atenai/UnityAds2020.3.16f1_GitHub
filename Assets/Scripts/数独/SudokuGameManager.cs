using UnityEngine;

public class SudokuGameManager : MonoBehaviour
{
	/// <summary>
	/// 現在選択しているセル
	/// </summary>
	[SerializeField] private CellButton selectedCurrentCell;

	/// <summary>
	/// 生成された全てのセルを管理
	/// </summary>
	private CellButton[,] allCells;

	/// <summary>
	/// ミス数
	/// </summary>
	private int missNumber = 5;

	/// <summary>
	/// ミスカウント
	/// </summary>
	private int missCount = 0;

	/// <summary>
	/// マスを登録
	/// </summary>
	/// <param name="cells"></param>
	public void RegisterCells(CellButton[,] cells)
	{
		allCells = cells;
	}

	/// <summary>
	/// セルを選択
	/// </summary>
	/// <param name="cell"></param>
	public void SelectCell(CellButton cell)
	{
		selectedCurrentCell = cell;
		cell.SetColor(Color.blue);
		Debug.Log($"ボタン (縦:{selectedCurrentCell.Row}, 横:{selectedCurrentCell.Col}) がクリックされました!");
		Debug.Log($"答え番号: {selectedCurrentCell.AnswerNumber}");
		Debug.Log($"問題番号: {selectedCurrentCell.QuestionNumber}");
	}

	//3
	/// <summary>
	/// 数値を入力
	/// </summary>
	/// <param name="number"></param>
	public void InputNumber(int number)
	{
		if (selectedCurrentCell != null)
		{
			//4
			selectedCurrentCell.SetNumber(number);
			selectedCurrentCell = null;
		}
	}

	//7
	/// <summary>
	/// 正誤判定処理
	/// </summary>
	/// <param name="cell"></param>
	/// <param name="number"></param>
	public void CheckAnswer(CellButton cell, int number)
	{
		if (number == 0) return; // 入力を消した場合は判定しない

		if (cell.AnswerNumber == number)
		{
			//Debug.Log($"({cell.Row},{cell.Col}) 正解！");
			Debug.Log("<color=green>正解！</color>");
			cell.SetColor(Color.green);
			cell.LockCell(); // 正解したらそのセルをロック

			// クリア判定
			if (CheckAllCellLock() == true)
			{
				Debug.Log("<color=yellow>ゲームクリア！</color>");
			}
		}
		else
		{
			//Debug.Log($"({cell.Row},{cell.Col}) 不正解！");
			Debug.Log("<color=red>不正解！</color>");
			cell.SetColor(Color.red);
			missCount++;
			if (missNumber <= missCount)
			{
				Debug.Log("<color=red>ゲームオーバー！</color>");
			}
		}
	}

	/// <summary>
	/// 全セルがロックされているかチェック
	/// </summary>
	/// <returns>全てのマスがロックされていたらtrue 1つでもロックされていない場合はfalse</returns>
	private bool CheckAllCellLock()
	{
		foreach (var cell in allCells)
		{
			if (cell.GetComponent<UnityEngine.UI.Button>().interactable)
			{
				return false;
			}
		}
		return true;
	}
}
