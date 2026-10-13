using System;
using System.Collections.Generic;

namespace 探偵
{
    /// <summary>
    /// 推測するもの（パスワード／電話番号）を選んで手掛かりを入力 → AIが隠されたヒントをたどる
    /// → 根拠つきの候補を表示、の流れをつなぐ。
    /// </summary>
    public class ClueResearchPresenter
    {
        const string ReadyMessage = "推測するものを選び、手掛かりを入力して「AIに調べてもらう」を押してください。";

        readonly ClueResearchModel _model;
        readonly ClueResearchView _view;
        readonly ILinkOpener _opener;

        public ClueResearchPresenter(ClueResearchModel model, ClueResearchView view, ILinkOpener opener)
        {
            _model = model;
            _view = view;
            _opener = opener;

            _model.OnStarted += () =>
            {
                _view.SetBusy(true);
                _view.ClearResults();
                RenderElapsed();
            };
            _model.OnCompleted += Render;
            _model.OnCancelled += () =>
            {
                _view.SetBusy(false);
                _view.SetStatus("調査を中止しました。" + ReadyMessage);
            };

            _view.PasswordTargetButton.onClick.AddListener(() => SelectTarget(GuessTarget.Password));
            _view.PhoneTargetButton.onClick.AddListener(() => SelectTarget(GuessTarget.PhoneNumber));
            _view.SearchButton.onClick.AddListener(Submit);
            _view.CancelButton.onClick.AddListener(_model.Cancel);
            _view.OnTick += RenderElapsed;

            _view.SetBusy(false);
            RenderTarget(_model.SelectedTarget);
            _view.SetStatus(ReadyMessage);
        }

        void SelectTarget(GuessTarget target)
        {
            if (_model.SelectTarget(target)) RenderTarget(target);
        }

        void RenderTarget(GuessTarget target)
        {
            _view.SetTarget(target);
            _view.SetPlaceholder(target == GuessTarget.PhoneNumber
                ? "電話番号の形と手掛かりを入力（例：•••-••••-••05　喫茶ポラリス）"
                : "手掛かりを入力（例：赤いマフラー　雪の山荘　停電）");
        }

        void Submit()
        {
            string error = _model.Validate(_view.ClueText);
            if (error != null)
            {
                _view.SetStatus(error);
                return;
            }
            _model.Start(_view.ClueText);
        }

        void RenderElapsed()
        {
            if (!_model.IsResearching) return;

            TimeSpan elapsed = DateTime.Now - _model.StartedAt;
            _view.SetStatus("AIが「" + _model.CurrentClue + "」から" + GuessTargetNames.Of(_model.CurrentTarget)
                + "を推測しています…（" + (int)elapsed.TotalMinutes + "分" + elapsed.Seconds.ToString("00") + "秒）\n"
                + "隠されたヒントを探してページをたどるので、数分〜十数分かかることがあります。");
        }

        void Render(ResearchResult result)
        {
            _view.SetBusy(false);
            if (!result.Success)
            {
                _view.SetStatus(result.ErrorMessage);
                return;
            }

            IReadOnlyList<AnswerCandidate> answers = result.Report.Answers;
            _view.SetStatus(ResultMessage(answers.Count));
            _view.SetSummary(result.Report.Summary);

            IReadOnlyList<AnswerCardView> cards = _view.CreateCards(answers.Count);
            for (int i = 0; i < answers.Count; i++)
            {
                AnswerCandidate answer = answers[i];
                cards[i].Bind(i + 1, answer.Title, answer.Confidence, answer.ConfidenceLabel, answer.Reasoning,
                    answer.Sources, SystemBrowserLinkOpener.IsWebUrl, _opener.Open);
            }
        }

        string ResultMessage(int count)
        {
            PhoneMask mask = _model.CurrentMask;
            if (mask == null)
            {
                return "「" + _model.CurrentClue + "」から、" + GuessTargetNames.Of(_model.CurrentTarget)
                    + "の候補が" + count + "件見つかりました。";
            }

            int excluded = _model.LastExcludedCount;
            if (count == 0 && excluded > 0)
            {
                return "AIの候補は、どれも電話番号の形（" + mask.Pattern + "）に合いませんでした。手掛かりを変えて、もう一度試してください。";
            }
            return "電話番号（" + mask.Pattern + "）の候補が" + count + "件見つかりました。"
                + (excluded > 0 ? "（形に合わない候補" + excluded + "件は除外しました）" : "");
        }
    }
}
