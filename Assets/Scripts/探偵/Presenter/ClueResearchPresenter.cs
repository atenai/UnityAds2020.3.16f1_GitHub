using System;
using System.Collections.Generic;

namespace 探偵
{
    /// <summary>
    /// 推測するもの（パスワード／電話番号／人物）を選んで手掛かりを入力 → AIが調べる
    /// → 根拠つきの候補を表示、の流れをつなぐ。人物のときは画像も読み込んで出す。
    /// </summary>
    public class ClueResearchPresenter
    {
        const string ReadyMessage = "推測するものを選び、手掛かりを入力して「AIに調べてもらう」を押してください。";

        readonly ClueResearchModel _model;
        readonly ClueResearchView _view;
        readonly ILinkOpener _opener;
        readonly IImageLoader _imageLoader;

        public ClueResearchPresenter(ClueResearchModel model, ClueResearchView view, ILinkOpener opener,
            IImageLoader imageLoader)
        {
            _model = model;
            _view = view;
            _opener = opener;
            _imageLoader = imageLoader;

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
            _view.PersonTargetButton.onClick.AddListener(() => SelectTarget(GuessTarget.Person));
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
            switch (target)
            {
                case GuessTarget.PhoneNumber:
                    _view.SetPlaceholder("電話番号の形と手掛かりを入力（例：•••-••••-••05　喫茶ポラリス）");
                    break;
                case GuessTarget.Person:
                    _view.SetPlaceholder("調べたい人物のフルネームを入力（例：竈門炭治郎）");
                    break;
                default:
                    _view.SetPlaceholder("手掛かりを入力（例：赤いマフラー　雪の山荘　停電）");
                    break;
            }
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
            string time = "（" + (int)elapsed.TotalMinutes + "分" + elapsed.Seconds.ToString("00") + "秒）\n";
            if (_model.CurrentTarget == GuessTarget.Person)
            {
                _view.SetStatus("AIが「" + _model.CurrentClue + "」という人物を調べています…" + time
                    + "百科事典や公式サイトを読み比べるので、数分かかることがあります。");
                return;
            }
            _view.SetStatus("AIが「" + _model.CurrentClue + "」から" + GuessTargetNames.Of(_model.CurrentTarget)
                + "を推測しています…" + time
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
                AnswerCardView card = cards[i];
                card.Bind(i + 1, answer.Title, answer.Subtitle, answer.Confidence, answer.ConfidenceLabel,
                    answer.Reasoning, answer.Details, answer.Sources, SystemBrowserLinkOpener.IsWebUrl, _opener.Open);

                string imageUrl = answer.ImageUrl;
                if (!SystemBrowserLinkOpener.IsWebUrl(imageUrl)) continue; // 画像が無い・http/https以外なら枠ごと出さない

                card.ShowImageLoading(imageUrl, () => _opener.Open(imageUrl));
                _imageLoader.Load(imageUrl, texture => card.SetImage(imageUrl, texture));
            }
        }

        string ResultMessage(int count)
        {
            if (_model.CurrentTarget == GuessTarget.Person)
            {
                return count == 0
                    ? "「" + _model.CurrentClue + "」に当てはまる、キャラクターや公に活動している人物は見つかりませんでした。"
                    : "「" + _model.CurrentClue + "」という名前の人物の候補が" + count + "件見つかりました。";
            }

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
