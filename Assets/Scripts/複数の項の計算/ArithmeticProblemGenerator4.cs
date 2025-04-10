using System.Collections.Generic;
using UnityEngine;

namespace Test
{
	[System.Serializable]
	public class NumberRange
	{
		public int min = 0;
		public int max = 9;
	}

	public class ArithmeticProblemGenerator4 : MonoBehaviour
	{
		[Header("数値ごとのランダム範囲（項目ごとに個別指定）")]
		[SerializeField] List<NumberRange> numberRanges = new List<NumberRange>(); // 各項目の範囲

		[Header("四則演算の出現割合（1回目のみ使用）")]
		[SerializeField] int plusWeight = 50;
		[SerializeField] int minusWeight = 20;
		[SerializeField] int multiplyWeight = 20;
		[SerializeField] int divideWeight = 10;

		void Start()
		{
			if (numberRanges.Count < 2)
			{
				Debug.LogError("数値の項目は最低2つ必要です");
				return;
			}

			foreach (var range in numberRanges)
			{
				if (range.min < 0 || range.max > 9 || range.min > range.max)
				{
					Debug.LogError("各項目の範囲は 0〜9 かつ min ≤ max にしてください");
					return;
				}
			}

			for (int i = 0; i < 100; i++)
				GenerateValidProblem();
		}

		void GenerateValidProblem()
		{
			System.Random rand = new System.Random();

			// ✅ 1項目目の演算子は全種類使える
			List<string> firstOperatorPool = new List<string>();
			for (int i = 0; i < plusWeight; i++) firstOperatorPool.Add("+");
			for (int i = 0; i < minusWeight; i++) firstOperatorPool.Add("-");
			for (int i = 0; i < multiplyWeight; i++) firstOperatorPool.Add("*");
			for (int i = 0; i < divideWeight; i++) firstOperatorPool.Add("/");

			// ✅ 2項目目以降は + - のみ
			List<string> limitedOperatorPool = new List<string> { "+", "-" };

			bool isValid = false;

			while (!isValid)
			{
				// ✅ 各項目の指定された範囲でランダムな数値を生成
				List<int> numbers = new List<int>();
				foreach (var range in numberRanges)
				{
					numbers.Add(rand.Next(range.min, range.max + 1));
				}

				int result = numbers[0];
				string expression = result.ToString();
				isValid = true;

				for (int i = 1; i < numbers.Count; i++)
				{
					string op = (i == 1)
						? firstOperatorPool[rand.Next(firstOperatorPool.Count)]
						: limitedOperatorPool[rand.Next(limitedOperatorPool.Count)];

					int current = numbers[i];

					// 割り算無効条件チェック
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
}