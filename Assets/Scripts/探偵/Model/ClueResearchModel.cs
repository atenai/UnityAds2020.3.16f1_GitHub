using System;
using System.Collections.Generic;

namespace 探偵
{
    /// <summary>手掛かりを受け取ってAIに調べてもらう。同時に動かす調査は1つだけ。</summary>
    public class ClueResearchModel
    {
        public const int MaxClueLength = 200;

        readonly IAiResearcher _researcher;
        int _requestId; // 中止したあとに古い調査の結果が届いても捨てられるように、依頼ごとに番号を振る

        public bool IsResearching { get; private set; }
        public string CurrentClue { get; private set; } = "";
        public DateTime StartedAt { get; private set; }

        /// <summary>次に調べるときに推測させるもの。</summary>
        public GuessTarget SelectedTarget { get; private set; } = GuessTarget.Password;

        /// <summary>調査中（または直前の調査）で推測させているもの。</summary>
        public GuessTarget CurrentTarget { get; private set; } = GuessTarget.Password;

        /// <summary>電話番号を推測しているときの、黒丸つきの形。パスワードのときはnull。</summary>
        public PhoneMask CurrentMask { get; private set; }

        /// <summary>直前の調査で、電話番号の形に合わずに除外した候補の数。</summary>
        public int LastExcludedCount { get; private set; }

        public event Action OnStarted;
        public event Action<ResearchResult> OnCompleted;
        public event Action OnCancelled;

        public ClueResearchModel(IAiResearcher researcher)
        {
            _researcher = researcher;
        }

        /// <summary>手掛かりとして受け付けられなければ理由を返す。問題なければnull。</summary>
        public string Validate(string clue)
        {
            string trimmed = (clue ?? "").Trim();
            if (trimmed.Length == 0)
            {
                return SelectedTarget == GuessTarget.Person ? "調べたい人物のフルネームを入力してください。" : "手掛かりを入力してください。";
            }
            if (trimmed.Length > MaxClueLength) return "手掛かりは" + MaxClueLength + "文字以内で入力してください。";
            if (SelectedTarget == GuessTarget.PhoneNumber && !PhoneMask.TryExtract(trimmed, out _))
            {
                return "電話番号の形（例：•••-••••-••05）を手掛かりに入れてください。黒丸のところは ● ・ * ? でも入力できます。";
            }
            return null;
        }

        /// <summary>調査中は変えられない（今の調査の結果と食い違わないように）。</summary>
        public bool SelectTarget(GuessTarget target)
        {
            if (IsResearching) return false;
            SelectedTarget = target;
            return true;
        }

        public bool Start(string clue)
        {
            if (IsResearching || Validate(clue) != null) return false;

            IsResearching = true;
            CurrentClue = clue.Trim();
            CurrentTarget = SelectedTarget;
            CurrentMask = null;
            if (CurrentTarget == GuessTarget.PhoneNumber && PhoneMask.TryExtract(CurrentClue, out PhoneMask mask))
            {
                CurrentMask = mask;
            }
            LastExcludedCount = 0;
            StartedAt = DateTime.Now;
            int requestId = ++_requestId;
            OnStarted?.Invoke();

            _researcher.ResearchAsync(CurrentTarget, ResearchPromptBuilder.Build(CurrentClue, CurrentTarget, CurrentMask), result =>
            {
                if (requestId != _requestId) return;

                IsResearching = false;
                OnCompleted?.Invoke(KeepMatchingAnswers(result));
            });
            return true;
        }

        public void Cancel()
        {
            if (!IsResearching) return;

            _requestId++;
            IsResearching = false;
            _researcher.Cancel();
            OnCancelled?.Invoke();
        }

        // AIが形を守らないこともあるので、電話番号は黒丸の形に合う候補だけを残す
        ResearchResult KeepMatchingAnswers(ResearchResult result)
        {
            if (!result.Success || CurrentMask == null) return result;

            List<AnswerCandidate> matching = CurrentMask.Filter(result.Report.Answers, out int excluded);
            LastExcludedCount = excluded;
            return ResearchResult.Ok(new ResearchReport(result.Report.Summary, matching.ToArray()));
        }
    }
}
