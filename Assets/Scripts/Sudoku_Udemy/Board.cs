using System.Collections;
using System.Collections.Generic;
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

	//DIFFICULTY
	public enum Difficulties
	{
		DEBUG,
		EASY,
		MEDIUM,
		HARD,
		INSANE,
	}

	public Difficulties difficulty;

	void Start()
	{
		InitGrid(ref solvedGrid);
		//DebugGrid(ref solvedGrid);

		ShuffleGrid(ref solvedGrid, 5);
		CreateRiddleGrid();

		CreateButtons();
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
	/// デバッグログにグリッドを出力します。
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
		//→ これで「空欄のある数独の問題」ができます。
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

		//デバッグ表示
		//DebugGrid(ref riddleGrid);で、作成した問題グリッドをデバッグ出力します。
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

	void SetDifficulty()
	{
		switch (difficulty)
		{
			case Difficulties.DEBUG:
				piecesToErase = 5; //デバッグ
				break;
			case Difficulties.EASY:
				piecesToErase = 35; //簡単な数独
				break;
			case Difficulties.MEDIUM:
				piecesToErase = 40; //中程度の数独
				break;
			case Difficulties.HARD:
				piecesToErase = 45; //難しい数独
				break;
			case Difficulties.INSANE:
				piecesToErase = 55; //非常に難しい数独
				break;
		}
	}

	public void CheckComplete()
	{
		if (CheckIfWon())
		{
			Debug.Log("You won!");
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
}
