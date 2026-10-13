using System;
using System.Threading;
using System.Threading.Tasks;

namespace 探偵
{
    /// <summary>AIを呼ばずに画面や流れを確かめたいときの差し替え用。Claudeの使用量も減らない。</summary>
    public sealed class FakeAiResearcher : IAiResearcher
    {
        const int DelayMilliseconds = 2500; // 「調査中」の表示も確かめられるように少し待たせる

        CancellationTokenSource _cancellation;

        public void ResearchAsync(string request, Action<ResearchResult> onCompleted)
        {
            SynchronizationContext mainThread = SynchronizationContext.Current;
            _cancellation = new CancellationTokenSource();
            CancellationToken token = _cancellation.Token;

            Task.Delay(DelayMilliseconds, token).ContinueWith(task =>
            {
                ResearchResult result = task.IsCanceled ? ResearchResult.Failure("調査を中止しました。")
                    : PhoneMask.TryExtract(request, out PhoneMask mask) ? CreatePhoneResult(mask) : CreateResult();
                if (mainThread != null) mainThread.Post(_ => onCompleted(result), null);
                else onCompleted(result);
            });
        }

        public void Cancel()
        {
            _cancellation?.Cancel();
        }

        // 依頼文に電話番号の形があれば、黒丸を埋めた番号を返す。形に合わない候補も1つ混ぜて、除外の動きも確かめられるようにする
        static ResearchResult CreatePhoneResult(PhoneMask mask)
        {
            AnswerCandidate[] answers =
            {
                new AnswerCandidate(Fill(mask, 1), AnswerCandidate.High, "テスト用の理由です（黒丸を1から順に埋めた番号）。",
                    new[] { new SourceLink("テスト用の出典A", "https://example.com/source/a") }),
                new AnswerCandidate(Fill(mask, 5), AnswerCandidate.Medium, "テスト用の理由です（黒丸を5から順に埋めた番号）。",
                    new[] { new SourceLink("テスト用の出典B", "https://example.com/source/b") }),
                new AnswerCandidate("0120-000-000", AnswerCandidate.Low, "形に合わないテスト用の候補です。画面には出ないはずです。",
                    new[] { new SourceLink("テスト用の出典C", "https://example.com/source/c") })
            };
            return ResearchResult.Ok(new ResearchReport("これはテスト用の調査の概要です。", answers));
        }

        static string Fill(PhoneMask mask, int start)
        {
            char[] digits = mask.Pattern.ToCharArray();
            int next = start;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] != PhoneMask.Hidden) continue;
                digits[i] = (char)('0' + next % 10);
                next++;
            }
            return new string(digits);
        }

        static ResearchResult CreateResult()
        {
            AnswerCandidate[] answers =
            {
                new AnswerCandidate("テスト用の答え1", AnswerCandidate.High,
                    "これはテスト用の理由です。実際のAIは、手掛かりのどの部分がどう当てはまるかをここに書きます。",
                    new[]
                    {
                        new SourceLink("テスト用の出典A", "https://example.com/source/a"),
                        new SourceLink("テスト用の出典B", "https://example.com/source/b")
                    }),
                new AnswerCandidate("テスト用の答え2", AnswerCandidate.Medium,
                    "2件目のテスト用の理由です。長めの文章が入ったときに、カードの高さが文章に合わせて伸びるかを確かめるために、少し長く書いています。",
                    new[] { new SourceLink("テスト用の出典C", "https://example.com/source/c") }),
                new AnswerCandidate("テスト用の答え3", AnswerCandidate.Low, "3件目のテスト用の理由です。",
                    new[] { new SourceLink("テスト用の出典D", "https://example.com/source/d") })
            };
            return ResearchResult.Ok(new ResearchReport(
                "これはテスト用の調査の概要です。実際のAIは、どんな方針で何回ほど調べたかをここに書きます。", answers));
        }
    }
}
