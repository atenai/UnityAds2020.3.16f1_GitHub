using System.Collections.Generic;
using UnityEngine;

public class ArithmeticProblemGenerator2 : MonoBehaviour
{
	[SerializeField] int ループ回数 = 5;
	[Tooltip("使用する項の数（2以上推奨）")]
	[Range(2, 9)]
	[SerializeField] int 項 = 3;

	// 最初の四則演算の出現割合
	[SerializeField] int 最初の足し算重み = 50;
	[SerializeField] int 最初の引き算重み = 20;
	[SerializeField] int 最初の掛け算重み = 20;
	[SerializeField] int 最初の割り算重み = 10;
	// 2回目以降の四則演算の出現割合
	[SerializeField] int 次の足し算重み = 50;
	[SerializeField] int 次の引き算重み = 50;

	void Start()
	{
		if (項 < 2)
		{
			UnityEngine.Assertions.Assert.IsTrue(false, "項は最低2個必要です");
			return;
		}

		for (int i = 0; i < ループ回数; i++)
		{
			複数の項の計算式();
		}
	}

	void 複数の項の計算式()
	{
		// ✅ 最初の演算子リスト（全種類含む）
		List<string> 最初の四則演算子リスト = new List<string>();
		for (int i = 0; i < 最初の足し算重み; i++)
		{
			最初の四則演算子リスト.Add("+");
		}
		for (int i = 0; i < 最初の引き算重み; i++)
		{
			最初の四則演算子リスト.Add("-");
		}
		for (int i = 0; i < 最初の掛け算重み; i++)
		{
			最初の四則演算子リスト.Add("*");
		}
		for (int i = 0; i < 最初の割り算重み; i++)
		{
			最初の四則演算子リスト.Add("/");
		}

		// ✅ 2回目以降の演算子リスト （+ と - のみ）
		List<string> 次の四則演算子リスト = new List<string>();
		for (int i = 0; i < 次の足し算重み; i++)
		{
			次の四則演算子リスト.Add("+");
		}
		for (int i = 0; i < 次の引き算重み; i++)
		{
			次の四則演算子リスト.Add("-");
		}

		bool isValid = false;

		while (isValid == false)
		{
			// ランダムな0〜9の整数を生成
			List<int> 問題の数値リスト = new List<int>();
			for (int i = 0; i < 項; i++)
			{
				問題の数値リスト.Add(UnityEngine.Random.Range(0, 10));
			}

			int 答え = 問題の数値リスト[0];
			string 問題 = 答え.ToString();
			isValid = true;

			for (int i = 1; i < 問題の数値リスト.Count; i++)
			{
				string 四則演算子;

				if (i == 1)
				{
					四則演算子 = 最初の四則演算子リスト[UnityEngine.Random.Range(0, 最初の四則演算子リスト.Count)];
				}
				else
				{
					四則演算子 = 次の四則演算子リスト[UnityEngine.Random.Range(0, 次の四則演算子リスト.Count)];
				}

				int 現在の数値 = 問題の数値リスト[i];

				// 割り算チェック（1回目のみ可能）
				if (四則演算子 == "/" && (現在の数値 == 0 || 答え % 現在の数値 != 0))
				{
					// やり直し
					isValid = false;
					break;
				}

				int 計算数値 = 答え;
				switch (四則演算子)
				{
					case "+":
						計算数値 = 計算数値 + 現在の数値;
						break;
					case "-":
						計算数値 = 計算数値 - 現在の数値;
						break;
					case "*":
						計算数値 = 計算数値 * 現在の数値;
						break;
					case "/":
						計算数値 = 計算数値 / 現在の数値;
						break;
				}

				// 計算結果が0以下または99以上の場合は無効
				if (計算数値 < 0 || 99 < 計算数値)
				{
					// やり直し
					isValid = false;
					break;
				}

				答え = 計算数値;
				問題 = 問題 + " " + 四則演算子 + " " + 現在の数値;
			}

			if (isValid == true)
			{
				Debug.Log("問題: " + 問題);
				Debug.Log("答え: " + 答え);
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