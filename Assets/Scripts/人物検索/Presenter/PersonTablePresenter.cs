using System.Collections.Generic;
using UnityEngine;

namespace 人物検索
{
    public class PersonTablePresenter
    {
        readonly PersonTableModel _model;
        readonly PersonTableView _view;
        readonly IImageLoader _imageLoader;

        public PersonTablePresenter(PersonTableModel model, PersonTableView view, IImageLoader imageLoader)
        {
            _model = model;
            _view = view;
            _imageLoader = imageLoader;

            _model.OnStateChanged += Render;

            _view.SearchButton.onClick.AddListener(() => _model.Search(_view.Keyword));
            _view.SearchField.onSubmit.AddListener(_ => _model.Search(_view.Keyword));
            _view.SourcePrevButton.onClick.AddListener(() => _model.ShiftSource(-1));
            _view.SourceNextButton.onClick.AddListener(() => _model.ShiftSource(1));
            _view.NameSortButton.onClick.AddListener(() => _model.SortBy(PersonSortKey.Name));
            _view.DescriptionSortButton.onClick.AddListener(() => _model.SortBy(PersonSortKey.Description));

            Render();
        }

        void Render()
        {
            _view.SetInteractable(!_model.IsSearching);
            _view.SetStatus(BuildStatus());
            _view.SetSourceLabel(_model.Source.DisplayName);
            _view.SetHeaderLabels("名前" + Arrow(PersonSortKey.Name), "説明" + Arrow(PersonSortKey.Description));

            IReadOnlyList<PersonRowView> rows = _view.CreateRows(_model.People.Count);
            for (int i = 0; i < _model.People.Count; i++)
            {
                PersonEntry person = _model.People[i];
                PersonRowView row = rows[i];
                string url = person.Url;
                string imageUrl = person.ImageUrl;

                row.Bind(person.Name, person.Description, person.Summary, imageUrl, i % 2 == 0,
                    !string.IsNullOrEmpty(url), () => Application.OpenURL(url));

                // 画像は後から届く。届いたときに行が別人になっていたら捨てる。
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    _imageLoader.Load(imageUrl, sprite => row.ApplyImage(imageUrl, sprite));
                }
            }
        }

        string BuildStatus()
        {
            if (_model.IsSearching) return "検索中…";
            if (!string.IsNullOrEmpty(_model.ErrorMessage)) return _model.ErrorMessage;
            if (string.IsNullOrEmpty(_model.Keyword)) return "キーワードを入れて検索してください";
            if (_model.People.Count == 0) return "「" + _model.Keyword + "」に一致する対象は見つかりませんでした";

            string status = "「" + _model.Keyword + "」の検索結果 " + _model.People.Count + "件";
            return string.IsNullOrEmpty(_model.Note) ? status : status + "\n" + _model.Note;
        }

        string Arrow(PersonSortKey key)
        {
            if (_model.SortKey != key) return "";

            return _model.Ascending ? " ▲" : " ▼";
        }
    }
}
