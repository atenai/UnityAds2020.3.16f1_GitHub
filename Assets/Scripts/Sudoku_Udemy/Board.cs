using System.Collections;
using System.Collections.Generic;
using UnityEditor.Il2Cpp;
using UnityEngine;

public class Board : MonoBehaviour
{
	int[,] solvedGrid = new int[9, 9];
	string s;

	int[,] riddleGrid = new int[9, 9];
	//空白の数を設定する
	int piecesToErase = 35;

	/// 各3x3のセルの位置を取得
	public Transform A1, A2, A3, B1, B2, B3, C1, C2, C3;
	/// 各マスのプレハブ
	public GameObject buttonPrefab;

	List<NumberField> fieldList = new List<NumberField>();

	//DIFFICULTY
	public enum Difficulties
	{
		DEBUG,
		EASY,
		MEDIUM,
		HARD,
		INSANE,
	}
	public GameObject winPanel; //ゲームクリア時に表示するパネル

	public Difficulties difficulty;//難易度
	int maxHint; //最大ヒント数

	void Start()
	{
		winPanel.SetActive(false); //ゲームクリアパネルを非表示にする
		difficulty = (Board.Difficulties)Settings.difficulty;//難易度を設定
		FillGridBase(ref solvedGrid);
		SolveGrid(ref solvedGrid);
		CreateRiddleGrid(ref solvedGrid, ref riddleGrid);
		CreateButtons();

		//1
		// winPanel.SetActive(false); //ゲームクリアパネルを非表示にする
		// difficulty = (Board.Difficulties)Settings.difficulty;//難易度を設定
		// InitGrid(ref solvedGrid);
		// //DebugGrid(ref solvedGrid);
		// ShuffleGrid(ref solvedGrid, 5);
		// CreateRiddleGrid();
		// CreateButtons();
	}


	/// <summary>
	/// ➀ここで縦、横、3x3のセルに1から9の数字を重複せずに配置した数独の解を生成します。
	/// </summary>
	/// <param name="grid"></param>
	void InitGrid(ref int[,] grid)
	{
		//横のセル
		for (int i = 0; i < 9; i++)
		{
			//縦のセル
			for (int j = 0; j < 9; j++)
			{
				//grid[i, j] = (i * 3 + i / 3 + j) % 9 + 1; は必ず以下のような数独の解を生成
				// 123 456 789
				// 456 789 123
				// 789 123 456
				//
				// 234 567 891
				// 567 891 234
				// 891 234 567
				//
				// 345 678 912
				// 678 912 345
				// 912 345 678

				//各セルに値を設定
				grid[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
			}
		}

		int n1 = 8 * 3;//24
		int n2 = 8 / 3;//2
		int n = (n1 + n2 + 0) % 9 + 1;
		Debug.Log(n1 + "+" + n2 + "+" + 0);
		Debug.Log(n);
	}

	/// <summary>
	/// デバッグログにマス情報（グリッド）を出力します。
	/// </summary>
	/// <param name="grid"></param>
	void DebugGrid(ref int[,] grid)
	{
		s = "";

		int sep = 0;

		//横セル
		for (int i = 0; i < 9; i++)
		{
			s += "|";
			//縦セル
			for (int j = 0; j < 9; j++)
			{
				//各セルの値を文字列に変換して追加
				s += grid[i, j].ToString();
				sep = j % 3;
				if (sep == 2)
				{
					s += "|"; //3つごとに区切り線を追加
				}
			}
			//改行を追加
			s += "\n";
		}
		//デバッグログに出力
		Debug.Log(s);
	}

	/// <summary>
	/// ➁ここで数独の解をシャッフルします。
	/// </summary>
	/// <param name="grid"></param>
	/// <param name="shuffleAmount"></param>
	void ShuffleGrid(ref int[,] grid, int shuffleAmount)
	{
		for (int i = 0; i < shuffleAmount; i++)
		{
			int value1 = Random.Range(1, 10);// 1から9のランダムな値を選択
			int value2 = Random.Range(1, 10);// 1から9のランダムな値を選択

			//MIX 2 CELLS
			MixTwoGridCells(ref grid, value1, value2);//↑で出した2つの値を入れ替えます
		}
		//すべてのマスの答えをデバッグログに表示
		DebugGrid(ref grid);
	}

	/// <summary>
	/// ➂ここで2つのセルの値を入れ替えます。
	/// </summary>
	/// <param name="grid"></param>
	/// <param name="value1"></param>
	/// <param name="value2"></param>
	void MixTwoGridCells(ref int[,] grid, int value1, int value2)
	{
		int x1 = 0;
		int x2 = 0;
		int y1 = 0;
		int y2 = 0;

		// 3x3の横セルごとにループ
		for (int i = 0; i < 9; i += 3)
		{
			// 3x3の縦セルごとにループ
			for (int k = 0; k < 9; k += 3)
			{
				for (int j = 0; j < 3; j++)
				{
					for (int l = 0; l < 3; l++)
					{
						if (grid[i + j, k + l] == value1)
						{
							x1 = i + j;
							y1 = k + l;
						}

						if (grid[i + j, k + l] == value2)
						{
							x2 = i + j;
							y2 = k + l;
						}
					}
				}
				grid[x1, y1] = value2;
				grid[x2, y2] = value1;
			}
		}
	}

	/// <summary>
	/// ➃ここで数独の解を元に、難易度に応じて数独の問題を生成します。
	/// 「完成された数独の解答」から、指定数だけランダムにマスを消して「問題」を作り、その内容をデバッグ表示するメソッドです。
	/// </summary>
	void CreateRiddleGrid()
	{
		//解答グリッドのコピー
		//まず、solvedGrid（完成された数独の解答）をriddleGrid（問題用グリッド）にコピーします。
		//→ これでriddleGridは一旦「完成された状態」になります。
		//COPY THE SOLVED GRID
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				riddleGrid[i, j] = solvedGrid[i, j];
			}
		}

		//難易度設定（コメントのみ）
		//ここは何も処理していませんが、難易度調整のための場所です。
		//SET DIFFICULTY
		SetDifficulty();

		//マスを消して問題を作る
		//piecesToErase回だけ、ランダムな位置を選び、そのマスがまだ消されていなければ（0でなければ）、そのマスを0（空欄）にします。
		//これで「空欄のある数独の問題」ができます。
		//ERASE FROM RIDDLE GRID
		for (int i = 0; i < piecesToErase; i++)
		{
			int x1 = Random.Range(0, 9);
			int y1 = Random.Range(0, 9);
			//REROLL UNTIL WE FIND ONE WITHOUT A 0
			while (riddleGrid[x1, y1] == 0)
			{
				x1 = Random.Range(0, 9);
				y1 = Random.Range(0, 9);
			}
			//ONCE WE FOUND ONE WITH NO 0
			riddleGrid[x1, y1] = 0;
		}

		//空白部分を0にした全てのマスの情報をデバッグログに表示します。
		DebugGrid(ref riddleGrid);
	}

	/// <summary>
	/// 各3x3のセルにボタンを生成します。
	/// </summary>
	void CreateButtons()
	{
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				GameObject newButton = Instantiate(buttonPrefab);

				//値をセット
				NumberField numField = newButton.GetComponent<NumberField>();
				numField.SetValues(i, j, riddleGrid[i, j], i + "," + j, this);
				newButton.name = i + "," + j;

				if (riddleGrid[i, j] == 0)
				{
					fieldList.Add(numField); //空白のマスをリストに追加
				}

				//PARENT THE BUTTON
				//A1
				if (i < 3 && j < 3)
				{
					newButton.transform.SetParent(A1, false);
				}
				//A2
				if (i < 3 && j > 2 && j < 6)
				{
					newButton.transform.SetParent(A2, false);
				}
				//A3
				if (i < 3 && j > 5)
				{
					newButton.transform.SetParent(A3, false);
				}

				//B1
				if (i > 2 && i < 6 && j < 3)
				{
					newButton.transform.SetParent(B1, false);
				}
				//B2
				if (i > 2 && i < 6 && j > 2 && j < 6)
				{
					newButton.transform.SetParent(B2, false);
				}
				//B3
				if (i > 2 && i < 6 && j > 5)
				{
					newButton.transform.SetParent(B3, false);
				}

				//C1
				if (i > 5 && j < 3)
				{
					newButton.transform.SetParent(C1, false);
				}
				//C2
				if (i > 5 && j > 2 && j < 6)
				{
					newButton.transform.SetParent(C2, false);
				}
				//C3
				if (i > 5 && j > 5)
				{
					newButton.transform.SetParent(C3, false);
				}
			}
		}
	}

	public void SetInputInRiddleGrid(int x, int y, int value)
	{
		riddleGrid[x, y] = value;
	}

	/// <summary>
	/// 難易度に応じて空白の数を設定します。
	/// </summary>
	void SetDifficulty()
	{
		switch (difficulty)
		{
			case Difficulties.DEBUG:
				piecesToErase = 5; //デバッグ
				maxHint = 2; //デバッグ用のヒント数
				break;
			case Difficulties.EASY:
				piecesToErase = 35; //簡単な数独
				maxHint = 4; //簡単な数独のヒント数
				break;
			case Difficulties.MEDIUM:
				piecesToErase = 40; //中程度の数独
				maxHint = 6; //中程度の数独のヒント数
				break;
			case Difficulties.HARD:
				piecesToErase = 45; //難しい数独
				maxHint = 8; //難しい数独のヒント数
				break;
			case Difficulties.INSANE:
				piecesToErase = 55; //非常に難しい数独
				maxHint = 10; //非常に難しい数独のヒント数
				break;
		}
	}

	/// <summary>
	/// ゲームのクリア状態をチェックします。
	/// 全てのセルが正しい値になっているかを確認し、完成している場合はゲームクリアの処理を行います。
	/// もし完成していれば、"You won!"とデバッグログに表示します
	/// </summary>
	public void CheckComplete()
	{
		if (CheckIfWon())
		{
			Debug.Log("You won!");
			//ここにゲームクリアの処理を追加
			winPanel.SetActive(true); //ゲームクリアパネルを表示
		}
		else
		{
			Debug.Log("Try Again!");
		}
	}

	/// <summary>
	/// 全てのセルが正しい値になっているかをチェックします。
	/// 完成している場合はtrueを返し、まだ完成していない場合はfalseを返します。
	/// もし完成していれば、ゲームクリアの処理を行います。
	/// </summary>
	/// <returns></returns>
	bool CheckIfWon()
	{
		for (int i = 0; i < 9; i++)
		{
			for (int j = 0; j < 9; j++)
			{
				if (riddleGrid[i, j] != solvedGrid[i, j])
				{
					return false; //もし1つでも違うセルがあれば、まだ完成していない
				}
			}
		}
		return true; //全てのセルが一致していれば、完成している
	}

	public void ShowHint()
	{
		if (fieldList.Count > 0 && maxHint > 0)
		{
			int randIndex = Random.Range(0, fieldList.Count);

			maxHint--;
			riddleGrid[fieldList[randIndex].GetX(), fieldList[randIndex].GetY()] = solvedGrid[fieldList[randIndex].GetX(), fieldList[randIndex].GetY()];

			//ヒントを表示
			fieldList[randIndex].SetHint(riddleGrid[fieldList[randIndex].GetX(), fieldList[randIndex].GetY()]);

			fieldList.RemoveAt(randIndex); //ヒントを表示したらリストから削除
		}
		else
		{
			Debug.Log("No Hints Left");
		}

	}

	///BACK TRACKING

	///ALL CHECKS 
	//Columnは横
	bool ColumnContainsNumber(int y, int value, ref int[,] grid)
	{
		for (int x = 0; x < 9; x++)
		{
			if (grid[x, y] == value)
			{
				return true; //もし列に同じ値があればtrueを返す
			}
		}

		return false;
	}
	//Rowは縦
	bool RowContainsNumber(int x, int value, ref int[,] grid)
	{
		for (int y = 0; y < 9; y++)
		{
			if (grid[x, y] == value)
			{
				return true; //もし列に同じ値があればtrueを返す
			}
		}

		return false;
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

	bool CheckAll(int x, int y, int value, ref int[,] grid)
	{
		if (ColumnContainsNumber(y, value, ref grid))
		{
			return false;
		}

		if (RowContainsNumber(x, value, ref grid))
		{
			return false;
		}

		if (BlockContainsNumber(x, y, value, ref grid))
		{
			return false;
		}

		return true;
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
	///GENERATE GRID 
	void FillGridBase(ref int[,] grid)
	{
		List<int> rowValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		List<int> colValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

		int value = rowValues[Random.Range(0, rowValues.Count)];
		grid[0, 0] = value;
		rowValues.Remove(value);
		colValues.Remove(value);
		//ROWs FIRST
		//1行目の値をランダムに設定
		for (int i = 1; i < 9; i++)
		{
			value = rowValues[Random.Range(0, rowValues.Count)];
			grid[i, 0] = value;
			rowValues.Remove(value);
		}

		//COLUMNS HERE
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

	bool SolveGrid(ref int[,] grid)
	{
		DebugGrid(ref grid);

		if (IsValidGrid(ref grid) == true)
		{
			return true;
		}

		//FIND FIRST FREECELL
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
					Debug.Log(x + "," + y);
					break;
				}
			}
		}
		List<int> possibilities = new List<int>();
		possibilities = GetAllPossibilities(x, y, ref grid);
		for (int p = 0; p < possibilities.Count; p++)
		{
			//SET A POSSIBLE VALUE
			grid[x, y] = possibilities[p];
			//BACK TRACK
			if (SolveGrid(ref grid))
			{
				return true; //もし解けたらtrueを返す
			}

			grid[x, y] = 0; //もし解けなかったら、0に戻す
		}

		return false;
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

	//NEW GAME PLAY
	/// <summary>
	/// ➃ここで数独の解を元に、難易度に応じて数独の問題を生成します。
	/// 「完成された数独の解答」から、指定数だけランダムにマスを消して「問題」を作り、その内容をデバッグ表示するメソッドです。
	/// </summary>
	void CreateRiddleGrid(ref int[,] sGrid, ref int[,] rGrid)
	{
		//解答グリッドのコピー
		//まず、solvedGrid（完成された数独の解答）をriddleGrid（問題用グリッド）にコピーします。
		//これでriddleGridは一旦「完成された状態」になります。
		//COPY THE SOLVED GRID
		System.Array.Copy(sGrid, rGrid, sGrid.Length);


		//難易度設定
		//SET DIFFICULTY
		SetDifficulty();

		//マスを消して問題を作る
		//piecesToErase回だけ、ランダムな位置を選び、そのマスがまだ消されていなければ（0でなければ）、そのマスを0（空欄）にします。
		//これで「空欄のある数独の問題」ができます。
		//ERASE FROM RIDDLE GRID
		for (int i = 0; i < piecesToErase; i++)
		{
			int x1 = Random.Range(0, 9);
			int y1 = Random.Range(0, 9);
			//REROLL UNTIL WE FIND ONE WITHOUT A 0
			while (rGrid[x1, y1] == 0)
			{
				x1 = Random.Range(0, 9);
				y1 = Random.Range(0, 9);
			}
			//ONCE WE FOUND ONE WITH NO 0
			rGrid[x1, y1] = 0;
		}

		//空白部分を0にした全てのマスの情報をデバッグログに表示します。
		DebugGrid(ref riddleGrid);
	}
}



