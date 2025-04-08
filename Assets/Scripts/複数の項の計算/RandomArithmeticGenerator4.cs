using UnityEngine;
using System.Collections.Generic;

public class RandomArithmeticGenerator4 : MonoBehaviour
{
	void Start()
	{
		int numCount = 4; // 2～8まで指定可能
		string question;
		int answer;

		GenerateArithmeticQuestion(numCount, out question, out answer);
		Debug.Log($"問題: {question} ＝ {answer}");
	}

	void GenerateArithmeticQuestion(int numCount, out string question, out int answer)
	{
		string[] operators = { "+", "-", "*", "/" };

		while (true)
		{
			List<int> numbers = new List<int>();
			List<string> ops = new List<string>();

			int currentNum = Random.Range(0, 10);
			numbers.Add(currentNum);

			bool validExpression = true;

			for (int i = 1; i < numCount; i++)
			{
				string op = operators[Random.Range(0, operators.Length)];
				int nextNum;

				if (op == "/")
				{
					nextNum = Random.Range(1, 10);
					int attempts = 0;
					while (currentNum % nextNum != 0 && attempts < 10)
					{
						nextNum = Random.Range(1, 10);
						attempts++;
					}
					if (attempts == 10)
					{
						validExpression = false;
						break;
					}
				}
				else
				{
					nextNum = Random.Range(0, 10);
				}

				ops.Add(op);
				numbers.Add(nextNum);
				currentNum = nextNum;
			}

			if (!validExpression) continue;

			// 式を文字列で生成
			question = numbers[0].ToString();
			for (int i = 0; i < ops.Count; i++)
			{
				question += $" {ops[i]} {numbers[i + 1]}";
			}

			// DataTableの代わりに自作の計算関数を呼ぶ
			int evalResult;
			if (TryEvaluateExpression(numbers, ops, out evalResult))
			{
				if (evalResult >= 0 && evalResult <= 99)
				{
					answer = evalResult;
					break;
				}
			}
		}
	}

	// 自作の計算関数（四則演算の優先順位対応）
	bool TryEvaluateExpression(List<int> numbers, List<string> ops, out int result)
	{
		result = 0;
		try
		{
			// まず掛け算と割り算を処理
			for (int i = 0; i < ops.Count; i++)
			{
				if (ops[i] == "*" || ops[i] == "/")
				{
					int temp = ops[i] == "*"
						? numbers[i] * numbers[i + 1]
						: numbers[i] / numbers[i + 1];

					numbers[i] = temp;
					numbers.RemoveAt(i + 1);
					ops.RemoveAt(i);
					i--; // リストが縮んだのでインデックス調整
				}
			}

			// 次に足し算と引き算を処理
			result = numbers[0];
			for (int i = 0; i < ops.Count; i++)
			{
				if (ops[i] == "+")
					result += numbers[i + 1];
				else if (ops[i] == "-")
					result -= numbers[i + 1];
			}

			return true;
		}
		catch
		{
			// エラーがあった場合はfalseを返す
			return false;
		}
	}
}
