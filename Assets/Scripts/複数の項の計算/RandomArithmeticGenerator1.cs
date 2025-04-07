using UnityEngine;
using System.Data; // DataTable.Computeを使用するため
using System;       // Convertのために追加

public class RandomArithmeticGenerator1 : MonoBehaviour
{
	void Start()
	{
		int numCount = 4; // ← ここを2～8の任意の数字に変更可能
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
			question = "";
			int currentNum = UnityEngine.Random.Range(0, 10);
			question += currentNum.ToString();

			bool validExpression = true;

			for (int i = 1; i < numCount; i++)
			{
				string op = operators[UnityEngine.Random.Range(0, operators.Length)];
				int nextNum;

				if (op == "/")
				{
					nextNum = UnityEngine.Random.Range(1, 10);
					int attempts = 0;
					while (currentNum % nextNum != 0 && attempts < 10)
					{
						nextNum = UnityEngine.Random.Range(1, 10);
						attempts++;
					}
					if (attempts == 10)
					{
						validExpression = false;
						break; // 式を作り直す
					}
				}
				else
				{
					nextNum = UnityEngine.Random.Range(0, 10);
				}

				question += $" {op} {nextNum}";
				currentNum = nextNum;
			}

			if (!validExpression) continue;

			object evalResult = EvaluateExpression(question);
			if (evalResult == null) continue;

			double evalDouble;
			try
			{
				evalDouble = Convert.ToDouble(evalResult);
			}
			catch
			{
				continue; // 変換失敗は再抽選
			}

			if (evalDouble % 1 == 0 && evalDouble >= 0 && evalDouble <= 9)
			{
				answer = (int)evalDouble;
				break;
			}
		}
	}

	object EvaluateExpression(string expression)
	{
		try
		{
			DataTable dt = new DataTable();
			object result = dt.Compute(expression, "");
			return result;
		}
		catch
		{
			return null;
		}
	}
}
