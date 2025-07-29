using System.Collections.Generic;
using UnityEngine;

public class 数独バックトラック法1 : MonoBehaviour
{
	int[,] questionGrid = new int[9, 9];
	int[,] answerGrid = new int[9, 9];

	// 空白の数を設定する
	int emptyCellCount = 35;

	// 難易度
	enum Difficulties
	{
		DEBUG,
		EASY,
		MEDIUM,
		HARD,
		INSANE,
	}
	[SerializeField] Difficulties difficulty;

	/* ボードの幅・高さ・数字の最大値 */
	const int NUM = 9;

	/* ブロックの幅・高さ */
	const int BLOCK = 3;

	/* 見つかった答えの個数 */
	int answer = 0;

	int[,] copyBoard = new int[NUM, NUM];

	void Start()
	{
		CreateBaseGrid(ref questionGrid);
		CreateQuestionGrid(ref questionGrid);

		bool unique = false;
		while (!unique)
		{
			CreateAnswerGrid(ref questionGrid, ref answerGrid);
			int solutions = StartBacktracking(answerGrid);

			Debug.Log("解の数：" + solutions);

			if (solutions == 1)
			{
				unique = true;
				Debug.Log("<color=green>一意解の問題を生成しました！</color>");
			}
			else
			{
				Debug.Log("<color=red>再生成します（解が" + solutions + "個）</color>");
			}
		}
	}

	void CreateBaseGrid(ref int[,] grid)
	{
		List<int> rowValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		List<int> colValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

		int value = rowValues[Random.Range(0, rowValues.Count)];
		grid[0, 0] = value;
		rowValues.Remove(value);
		colValues.Remove(value);

		// 1行目をランダムに埋める
		for (int i = 1; i < 9; i++)
		{
			value = rowValues[Random.Range(0, rowValues.Count)];
			grid[i, 0] = value;
			rowValues.Remove(value);
		}

		// 1列目をランダムに埋める
		for (int i = 1; i < 9; i++)
		{
			value = colValues[Random.Range(0, colValues.Count)];
			if (i < 3)
			{
				while (BlockContainsNumber(0, 0, value, ref grid))
				{
					value = colValues[Random.Range(0, colValues.Count)];
				}
			}
			grid[0, i] = value;
			colValues.Remove(value);
		}

		DebugGrid(ref grid);
	}

	bool BlockContainsNumber(int x, int y, int value, ref int[,] grid)
	{
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (grid[x - (x % 3) + i, y - (y % 3) + j] == value)
				{
					return true;
				}
			}
		}
		return false;
	}

	bool CreateQuestionGrid(ref int[,] grid)
	{
		if (IsValidGrid(ref grid) == true)
		{
			return true;
		}

		int x = 0;
		int y = 0;

		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				if (grid[i, j] == 0)
				{
					x = i;
					y = j;
					break;
				}
			}
		}
		List<int> possibilities = GetAllPossibilities(x, y, ref grid);
		for (int p = 0; p < possibilities.Count; p++)
		{
			grid[x, y] = possibilities[p];
			if (CreateQuestionGrid(ref grid))
			{
				return true;
			}
			grid[x, y] = 0;
		}
		return false;
	}

	bool IsValidGrid(ref int[,] grid)
	{
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				if (grid[i, j] == 0)
				{
					return false;
				}
			}
		}
		return true;
	}

	List<int> GetAllPossibilities(int x, int y, ref int[,] grid)
	{
		List<int> possibilities = new List<int>();
		for (int val = 1; val <= 9; val++)
		{
			if (CheckAll(x, y, val, ref grid))
			{
				possibilities.Add(val);
			}
		}
		return possibilities;
	}

	bool CheckAll(int x, int y, int value, ref int[,] grid)
	{
		if (ColumnContainsNumber(y, value, ref grid)) return false;
		if (RowContainsNumber(x, value, ref grid)) return false;
		if (BlockContainsNumber(x, y, value, ref grid)) return false;
		return true;
	}

	bool ColumnContainsNumber(int y, int value, ref int[,] grid)
	{
		for (int x = 0; x < 9; x++)
		{
			if (grid[x, y] == value) return true;
		}
		return false;
	}

	bool RowContainsNumber(int x, int value, ref int[,] grid)
	{
		for (int y = 0; y < 9; y++)
		{
			if (grid[x, y] == value) return true;
		}
		return false;
	}

	void CreateAnswerGrid(ref int[,] qGrid, ref int[,] aGrid)
	{
		System.Array.Copy(qGrid, aGrid, qGrid.Length);
		SetDifficulty();

		for (int i = 0; i < emptyCellCount; i++)
		{
			int x1 = Random.Range(0, 9);
			int y1 = Random.Range(0, 9);
			while (aGrid[x1, y1] == 0)
			{
				x1 = Random.Range(0, 9);
				y1 = Random.Range(0, 9);
			}
			aGrid[x1, y1] = 0;
		}

		DebugGrid(ref answerGrid);
	}

	void DebugGrid(ref int[,] grid)
	{
		string s = "";
		for (int i = 0; i < 9; i++)
		{
			s += "|";
			for (int j = 0; j < 9; j++)
			{
				s += grid[i, j].ToString();
				if (j % 3 == 2) s += "|";
			}
			s += "\n";
		}
		Debug.Log(s);
	}

	void SetDifficulty()
	{
		switch (difficulty)
		{
			case Difficulties.DEBUG: emptyCellCount = 5; break;
			case Difficulties.EASY: emptyCellCount = 35; break;
			case Difficulties.MEDIUM: emptyCellCount = 40; break;
			case Difficulties.HARD: emptyCellCount = 45; break;
			case Difficulties.INSANE: emptyCellCount = 55; break;
		}
	}

	public int StartBacktracking(int[,] originalBoard)
	{
		copyBoard = (int[,])originalBoard.Clone();
		answer = 0;
		Solve(0, 0);
		return answer;
	}

	bool Solve(int i, int j)
	{
		if (answer >= 2) return false;

		if (copyBoard[j, i] != 0)
		{
			return NextCell(i, j);
		}

		for (int n = 1; n <= NUM; n++)
		{
			if (CheckNumber(i, j, n))
			{
				copyBoard[j, i] = n;
				if (NextCell(i, j)) return true;
				copyBoard[j, i] = 0;
			}
		}
		return false;
	}

	bool NextCell(int i, int j)
	{
		if (i == NUM - 1 && j == NUM - 1)
		{
			answer++;
			return true;
		}

		int next_i = (i + 1) % NUM;
		int next_j = j + (i + 1) / NUM;

		return Solve(next_i, next_j);
	}

	bool CheckNumber(int i, int j, int number)
	{
		for (int x = 0; x < NUM; x++)
			if (copyBoard[j, x] == number) return false;

		for (int y = 0; y < NUM; y++)
			if (copyBoard[y, i] == number) return false;

		int bi = i / BLOCK * BLOCK;
		int bj = j / BLOCK * BLOCK;

		for (int y = 0; y < BLOCK; y++)
			for (int x = 0; x < BLOCK; x++)
				if (copyBoard[bj + y, bi + x] == number) return false;

		return true;
	}
}
