using System;
using System.Collections.Generic;

namespace 人物検索
{
    /// <summary>検索結果を表として保持する。情報源の選択と並べ替えもここが持つ。</summary>
    public class PersonTableModel
    {
        readonly IPersonSearchService _service;
        readonly List<PersonEntry> _people = new List<PersonEntry>();

        int _sourceIndex;

        public IReadOnlyList<PersonEntry> People => _people;
        public bool IsSearching { get; private set; }
        public string ErrorMessage { get; private set; }
        public string Note { get; private set; }
        public string Keyword { get; private set; }
        public PersonSortKey SortKey { get; private set; } = PersonSortKey.Relevance;
        public bool Ascending { get; private set; } = true;

        public PersonSource Source => PersonSourceCatalog.Sources[_sourceIndex];

        public event Action OnStateChanged;

        public PersonTableModel(IPersonSearchService service)
        {
            _service = service;
        }

        /// <summary>情報源を切り替える。検索済みなら同じワードで引き直す。</summary>
        public void ShiftSource(int delta)
        {
            if (IsSearching) return;

            int count = PersonSourceCatalog.Sources.Length;
            _sourceIndex = (_sourceIndex + delta % count + count) % count;

            if (string.IsNullOrEmpty(Keyword)) OnStateChanged?.Invoke();
            else Search(Keyword);
        }

        public void Search(string keyword)
        {
            if (IsSearching) return;

            string trimmed = (keyword ?? string.Empty).Trim();
            if (trimmed.Length == 0)
            {
                _people.Clear();
                ErrorMessage = "検索ワードを入力してください";
                OnStateChanged?.Invoke();
                return;
            }

            Keyword = trimmed;
            IsSearching = true;
            ErrorMessage = null;
            Note = null;
            OnStateChanged?.Invoke();

            _service.SearchAsync(Source, trimmed, result =>
            {
                IsSearching = false;
                _people.Clear();
                if (result.Success)
                {
                    _people.AddRange(result.People);
                    Note = result.Note;
                    SortKey = PersonSortKey.Relevance;
                    Ascending = true;
                }
                else
                {
                    ErrorMessage = result.ErrorMessage;
                }
                OnStateChanged?.Invoke();
            });
        }

        /// <summary>同じ列をもう一度押したら昇順・降順が入れ替わる。</summary>
        public void SortBy(PersonSortKey key)
        {
            if (SortKey == key) Ascending = !Ascending;
            else
            {
                SortKey = key;
                Ascending = true;
            }

            Sort();
            OnStateChanged?.Invoke();
        }

        void Sort()
        {
            int sign = Ascending ? 1 : -1;
            _people.Sort((left, right) =>
            {
                switch (SortKey)
                {
                    case PersonSortKey.Name:
                        return sign * string.Compare(left.Name, right.Name, StringComparison.CurrentCulture);
                    case PersonSortKey.Description:
                        return sign * string.Compare(left.Description, right.Description, StringComparison.CurrentCulture);
                    default:
                        return sign * left.Order.CompareTo(right.Order);
                }
            });
        }
    }
}
