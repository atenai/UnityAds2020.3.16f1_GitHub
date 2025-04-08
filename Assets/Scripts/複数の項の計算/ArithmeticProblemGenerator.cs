using System.Collections.Generic;
using UnityEngine;

public class ArithmeticProblemGenerator : MonoBehaviour
{
	[SerializeField] int numberCount = 3; // 使用する数値の数（2以上推奨）

	// 四則演算の出現割合（Inspectorからも調整可）
	[SerializeField] int plusWeight = 50;
	[SerializeField] int minusWeight = 20;
	[SerializeField] int multiplyWeight = 20;
	[SerializeField] int divideWeight = 10;

	void Start()
	{
		if (numberCount < 2)
		{
			Debug.LogError("数値は最低2個必要です");
			return;
		}

		for (int i = 0; i < 5; i++)
		{
			GenerateValidProblem();
		}

	}

	void GenerateValidProblem()
	{
		System.Random rand = new System.Random();

		// 重みに応じた演算子プール作成
		List<string> operatorPool = new List<string>();
		for (int i = 0; i < plusWeight; i++) operatorPool.Add("+");
		for (int i = 0; i < minusWeight; i++) operatorPool.Add("-");
		for (int i = 0; i < multiplyWeight; i++) operatorPool.Add("*");
		for (int i = 0; i < divideWeight; i++) operatorPool.Add("/");

		bool isValid = false;

		while (!isValid)
		{
			// 0〜9の数値をランダムにnumberCount個生成
			List<int> numbers = new List<int>();
			for (int i = 0; i < numberCount; i++)
			{
				numbers.Add(rand.Next(0, 10)); // 0〜9
			}

			int result = numbers[0];
			string expression = result.ToString();
			isValid = true;

			for (int i = 1; i < numbers.Count; i++)
			{
				string op = operatorPool[rand.Next(operatorPool.Count)];
				int current = numbers[i];

				// 割り算チェック（0除算・割り切れない → 無効）
				if (op == "/" && (current == 0 || result % current != 0))
				{
					isValid = false;
					break;
				}

				int tempResult = result;
				switch (op)
				{
					case "+": tempResult += current; break;
					case "-": tempResult -= current; break;
					case "*": tempResult *= current; break;
					case "/": tempResult /= current; break;
				}

				// 結果が負 or 100以上 → 無効
				if (tempResult < 0 || tempResult > 99)
				{
					isValid = false;
					break;
				}

				result = tempResult;
				expression += " " + op + " " + current;
			}

			if (isValid)
			{
				Debug.Log("問題: " + expression);
				Debug.Log("答え: " + result);
			}
		}
	}
}
