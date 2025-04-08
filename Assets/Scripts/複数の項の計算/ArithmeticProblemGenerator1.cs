using System.Collections.Generic;
using UnityEngine;

public class ArithmeticProblemGenerator1 : MonoBehaviour
{
	[SerializeField] int loopCount = 5;
	[SerializeField] int numberCount = 3; // 使用する数値の数（2以上推奨）

	// 四則演算の出現割合（最初の1回目のみ使用）
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

		for (int i = 0; i < loopCount; i++)
		{
			GenerateValidProblem();
		}
	}

	void GenerateValidProblem()
	{
		System.Random rand = new System.Random();

		// ✅ 最初の演算子用プール（全種類含む）
		List<string> firstOperatorPool = new List<string>();
		for (int i = 0; i < plusWeight; i++) firstOperatorPool.Add("+");
		for (int i = 0; i < minusWeight; i++) firstOperatorPool.Add("-");
		for (int i = 0; i < multiplyWeight; i++) firstOperatorPool.Add("*");
		for (int i = 0; i < divideWeight; i++) firstOperatorPool.Add("/");

		// ✅ 2回目以降の演算子は + と - のみ
		List<string> limitedOperatorPool = new List<string> { "+", "-" };

		bool isValid = false;

		while (!isValid)
		{
			// ランダムな0〜9の整数をnumberCount分生成
			List<int> numbers = new List<int>();
			for (int i = 0; i < numberCount; i++)
			{
				numbers.Add(rand.Next(0, 10));
			}

			int result = numbers[0];
			string expression = result.ToString();
			isValid = true;

			for (int i = 1; i < numbers.Count; i++)
			{
				string op;

				// 最初の演算子は full pool、それ以降は限定された演算子
				if (i == 1)
				{
					op = firstOperatorPool[rand.Next(firstOperatorPool.Count)];
				}
				else
				{
					op = limitedOperatorPool[rand.Next(limitedOperatorPool.Count)];
				}

				int current = numbers[i];

				// 割り算チェック（1回目のみ可能）
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

				// 結果が0〜99を超える場合も無効
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

// NOTE

// ・問題の答えは必ず1桁または2桁の整数のみになります。
// 3桁やマイナスの数値、小数点付き数にはなりません。

// ・+のみや-のみの単一の計算式があります。

// ・+や-がランダムで複数組み合わさった計算式があります。

// ・演算子はこちらで出やすさを変動させることができます。

// ・問題の数値
// 1桁(0～9)のみです。

// ・項の数
// 3～9個指定できます。

// ==========================================================================

// 問題に使う数値はランダムな 0～9 の1桁の整数

// 数値は指定された個数分、連続して並べる（例：3個 → 4 + 7 × 2）

// 四則演算（+ - * /）は指定した割合でランダムに選ばれる

// 答えは必ず 0〜99 の整数のみ有効（負の数・100以上・割り切れない除算は無効）

// 条件に合わない場合は、再度最初から問題を再生成する

// ==========================================================================

// 項目		詳細
// 項の数	　　　　2～9個
// 数値の範囲	0～9
// 演算子の種類	＋,－,×,÷ (ランダム)
// 割り算の扱い	必ず割り切れる数値のみ許可
// 答えの範囲	整数のみ（0～99）
// 範囲外の処理	条件に合わない場合は再抽選