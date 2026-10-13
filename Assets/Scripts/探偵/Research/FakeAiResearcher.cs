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

        public void ResearchAsync(GuessTarget target, string request, Action<ResearchResult> onCompleted)
        {
            SynchronizationContext mainThread = SynchronizationContext.Current;
            _cancellation = new CancellationTokenSource();
            CancellationToken token = _cancellation.Token;

            Task.Delay(DelayMilliseconds, token).ContinueWith(task =>
            {
                ResearchResult result = task.IsCanceled ? ResearchResult.Failure("調査を中止しました。") : CreateResult(target, request);
                if (mainThread != null) mainThread.Post(_ => onCompleted(result), null);
                else onCompleted(result);
            });
        }

        public void Cancel()
        {
            _cancellation?.Cancel();
        }

        static ResearchResult CreateResult(GuessTarget target, string request)
        {
            switch (target)
            {
                case GuessTarget.Person:
                    return CreatePersonResult();
                case GuessTarget.PhoneNumber:
                    return PhoneMask.TryExtract(request, out PhoneMask mask) ? CreatePhoneResult(mask) : CreatePasswordResult();
                default:
                    return CreatePasswordResult();
            }
        }

        // 画像の読み込み（成功・失敗・画像なし）を確かめられるように3パターン返す
        static ResearchResult CreatePersonResult()
        {
            AnswerCandidate[] answers =
            {
                new AnswerCandidate("テスト人物A", "テスト用の作品『サンプル』の登場人物", AnswerCandidate.High,
                    "これはテスト用の説明です。実際のAIは、この人物がどんな人物かをここに書きます。",
                    "https://upload.wikimedia.org/wikipedia/commons/a/a9/Example.jpg",
                    new[]
                    {
                        new DetailItem("作品", "サンプル"),
                        new DetailItem("声優", "テスト声優"),
                        new DetailItem("誕生日", "1月1日")
                    },
                    new[] { new SourceLink("テスト用の出典A", "https://example.com/source/a") }),
                new AnswerCandidate("テスト人物A", "同じ名前のテスト用の俳優", AnswerCandidate.Medium,
                    "同じ名前の別の人物の例です。画像のURLが壊れているときの表示を確かめます。",
                    "https://example.com/no-such-image.jpg",
                    new[] { new DetailItem("職業", "俳優"), new DetailItem("代表作", "テストドラマ") },
                    new[] { new SourceLink("テスト用の出典B", "https://example.com/source/b") }),
                new AnswerCandidate("テスト人物A", "画像のないテスト用の人物", AnswerCandidate.Low,
                    "画像が見つからなかったときの表示を確かめます。", "",
                    new[] { new DetailItem("職業", "歌手") },
                    new[] { new SourceLink("テスト用の出典C", "https://example.com/source/c") })
            };
            return ResearchResult.Ok(new ResearchReport("これはテスト用の調査の概要です。", answers));
        }

        // 黒丸を埋めた番号を返す。形に合わない候補も1つ混ぜて、除外の動きも確かめられるようにする
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

        static ResearchResult CreatePasswordResult()
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
