using UnityEngine;
using System.Data; // DataTable.Computeを使用するため
using System;       // Convertのために追加

public class RandomArithmeticGenerator3 : MonoBehaviour
{
	[Tooltip("項")]
	int term = 4; // ← ここを2～8の任意の数字に変更可能
	[Tooltip("問題文")]
	string question;
	[Tooltip("答えの数値")]
	int answer;

	void Start()
	{
		for (int i = 0; i < 100; i++)
		{
			StartGenerateArithmeticQuestion();
		}
	}

	void StartGenerateArithmeticQuestion()
	{
		GenerateArithmeticQuestion(term, out question, out answer);

		Debug.Log($"問題: {question} = {answer}");
	}

	void GenerateArithmeticQuestion(int term, out string question, out int answer)
	{
		//四則演算の文字
		string[] operators = { "+", "-", "*", "/" };

		while (true)
		{
			question = "";
			//現在のナンバーをランダムで0~9の値を抽選して入れる
			int currentNum = UnityEngine.Random.Range(0, 10);
			//現在のナンバーを文字列にして問題文に追加する
			question = question + currentNum.ToString();

			bool validExpression = true;

			for (int i = 1; i < term; i++)
			{
				//四則演算をランダムで抽選する
				string op = operators[UnityEngine.Random.Range(0, operators.Length)];
				int nextNum;

				if (op == "/")
				{
					//次のナンバーをランダムで1~9の値を抽選して入れる
					nextNum = UnityEngine.Random.Range(1, 10);
					int count = 0;
					//現在のナンバー　÷　次のナンバー　が0じゃない　かつ　カウントが10以下の場合に中身を実行する
					while (currentNum % nextNum != 0 && count < 10)
					{
						//次のナンバーをランダムで1~9の値を抽選して入れる
						nextNum = UnityEngine.Random.Range(1, 10);
						count++;
					}

					//カウントが10になったら
					if (count == 10)
					{
						validExpression = false;
						break; // 式を作り直す
					}
				}
				else
				{
					nextNum = UnityEngine.Random.Range(0, 10);
				}

				question = question + $" {op} {nextNum}";
				currentNum = nextNum;
			}

			if (validExpression == false)
			{
				//切り上げて次のループを行う
				continue;
			}

			object evalResult = EvaluateExpression(question);

			//object型をdouble型にする
			double evalDouble = Convert.ToDouble(evalResult);

			//evalDoubleが0~9の値かつevalDouble ÷ 1 == 0 になるなら中身を実行する
			if (evalDouble % 1 == 0 && 0 <= evalDouble && evalDouble <= 99)
			{
				answer = (int)evalDouble;
				break;
			}
		}
	}

	object EvaluateExpression(string expression)
	{
		DataTable dt = new DataTable();
		object result = dt.Compute(expression, "");
		return result;
	}
}
