using System.Collections.Generic;
using UnityEngine;

public class 数独唯一解生成1 : MonoBehaviour
{
	const int Cell_Number = 9;
	const int Separator_Block = 3;

	/// <summary>
	/// 答えグリッド
	/// </summary>
	int[,] answerGrid = new int[Cell_Number, Cell_Number];
	/// <summary>
	/// 問題グリッド
	/// </summary>
	int[,] questionGrid = new int[Cell_Number, Cell_Number];

	[SerializeField] int emptyCellTarget = 40; // 難易度に応じた空白数

	[SerializeField] バックトラック法 backtrackMethod;

	void Start()
	{
		// 1. 完全な数独を生成
		CreateAnswerGrid(0, 0, ref answerGrid);
		Debug.Log("<color=red>答えを生成しました！</color>");
		DebugGrid(ref answerGrid);

		// 2. 完全解をコピーして問題用にする
		System.Array.Copy(answerGrid, questionGrid, answerGrid.Length);

		// 3. マスを1つずつ消して唯一解を保つ
		CreateQuestionGrid();
		Debug.Log("<color=blue>問題を生成しました！</color>");
		DebugGrid(ref questionGrid);

		backtrackMethod.StartBacktracking(questionGrid);
	}

	/// <summary>
	/// 答えグリッドを作成
	/// </summary>
	/// <remarks>
	/// 再帰的に数独の解を生成します。
	/// 各マスに1から9の数字を配置し、
	/// そのマスに数字を配置できるかチェックします。
	/// 成功した場合は次のマスに進み、
	/// すべてのマスが埋まったら成功とします。
	/// </remarks>
	/// <param name="row"></param>
	/// <param name="col"></param>
	/// <param name="aGrid"></param>
	/// <returns></returns>
	bool CreateAnswerGrid(int row, int col, ref int[,] aGrid)
	{
		if (row == Cell_Number)
		{
			// 全てのマスが埋まったら成功
			return true;
		}

		int nextRow = (col == Cell_Number - 1) ? row + 1 : row;
		int nextCol = (col + 1) % Cell_Number;

		List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		ShuffleNumbers(numbers);

		foreach (int num in numbers)
		{
			if (CheckNumber(row, col, num, ref aGrid) == true)
			{
				aGrid[row, col] = num;
				if (CreateAnswerGrid(nextRow, nextCol, ref aGrid) == true)
				{
					return true;
				}
				aGrid[row, col] = 0;
			}
		}

		return false;
	}

	/// <summary>
	/// 指定された行と列のマスに数字が配置できるかチェックします。
	/// 行に同じ数字がある場合はfalseを返し、
	/// 列に同じ数字がある場合はfalseを返し、
	/// 3×3ブロックに同じ数字がある場合はfalseを返します。
	/// </summary>
	/// <param name="row">横</param>
	/// <param name="col">縦</param>
	/// <param name="num">数値</param>
	/// <param name="grid">チェックするグリッド</param>
	/// <returns>数字が配置できる場合はtrueを返します。数字が配置できない場合はfalseを返します。</returns>
	bool CheckNumber(int row, int col, int num, ref int[,] grid)
	{
		for (int i = 0; i < Cell_Number; i++)
		{
			if (grid[row, i] == num) { return false; }// 行に同じ数字があるか
			if (grid[i, col] == num) { return false; }// 列に同じ数字があるか
		}

		int startRow = row / Separator_Block * Separator_Block;
		int startCol = col / Separator_Block * Separator_Block;
		for (int r = 0; r < Separator_Block; r++)
		{
			for (int c = 0; c < Separator_Block; c++)
			{
				if (grid[startRow + r, startCol + c] == num) { return false; }// 3×3ブロックに同じ数字があるか
			}
		}

		return true;
	}

	/// <summary>
	/// リスト内の要素をシャッフルします。
	/// </summary>
	/// <typeparam name="T">あらゆる型</typeparam>
	/// <param name="list">シャフルするリスト</param>
	void ShuffleNumbers<T>(List<T> list)
	{
		for (int i = 0; i < list.Count; i++)
		{
			int rand = Random.Range(i, list.Count);
			T temp = list[i];
			list[i] = list[rand];
			list[rand] = temp;
		}
	}

	/// <summary>
	/// 問題グリッドを生成します。
	/// 問題グリッドは、空白のマスを持ち、唯一の解を持つように調整されます。
	/// 空白のマスの数は、`emptyCellTarget`で指定された数に基づいています。
	/// </summary>
	void CreateQuestionGrid()
	{
		List<Vector2Int> cells = new List<Vector2Int>();
		for (int r = 0; r < Cell_Number; r++)
		{
			for (int c = 0; c < Cell_Number; c++)
			{
				cells.Add(new Vector2Int(r, c));
			}
		}
		ShuffleNumbers(cells);

		int removed = 0;
		foreach (var cell in cells)
		{
			if (removed >= emptyCellTarget) { break; }

			int backup = questionGrid[cell.x, cell.y];
			questionGrid[cell.x, cell.y] = 0;

			int solutions = CountSolutions((int[,])questionGrid.Clone());

			if (solutions == 1)
			{
				removed++;
			}
			else
			{
				// 一意解でない → 元に戻す
				questionGrid[cell.x, cell.y] = backup;
			}
		}
	}

	int CountSolutions(int[,] board)
	{
		int count = 0;
		Solve(0, 0, board, ref count);
		return count;
	}

	bool Solve(int row, int col, int[,] board, ref int count)
	{
		if (count >= 2) { return false; } // 2個以上見つかったら打ち切り

		if (row == Cell_Number)
		{
			count++;
			return true;
		}

		int nextRow = (col == Cell_Number - 1) ? row + 1 : row;
		int nextCol = (col + 1) % Cell_Number;

		if (board[row, col] != 0)
		{
			return Solve(nextRow, nextCol, board, ref count);
		}

		for (int num = 1; num <= Cell_Number; num++)
		{
			if (CheckNumber(row, col, num, ref board))
			{
				board[row, col] = num;
				Solve(nextRow, nextCol, board, ref count);
				board[row, col] = 0;
			}
		}
		return false;
	}

	/// <summary>
	/// デバッグ用：グリッドの内容をコンソールに出力します。
	/// </summary>
	/// <param name="grid">デバッグログに表示したいグリッド</param>
	void DebugGrid(ref int[,] grid)
	{
		string s = "";
		for (int r = 0; r < Cell_Number; r++)
		{
			s = s + "|";
			for (int c = 0; c < Cell_Number; c++)
			{
				s = s + grid[r, c].ToString();
				if (c % 3 == 2)
				{
					s = s + "|";
				}
			}
			s = s + "\n";
		}
		Debug.Log(s);
	}
}
