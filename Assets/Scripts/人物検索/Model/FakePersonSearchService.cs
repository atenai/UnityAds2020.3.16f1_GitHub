using System;
using System.Collections.Generic;

namespace 人物検索
{
    /// <summary>ネットに繋がずに表示を確認するための差し替え用。</summary>
    public sealed class FakePersonSearchService : IPersonSearchService
    {
        public void SearchAsync(PersonSource source, string keyword, Action<PersonSearchResult> onCompleted)
        {
            List<PersonEntry> people = new List<PersonEntry>();
            for (int i = 1; i <= 30; i++)
            {
                people.Add(new PersonEntry(i, "テスト" + i + "号", source.DisplayName,
                    "検索ワード「" + keyword + "」に対するダミーの" + i + "件目です。", "", ""));
            }
            onCompleted(PersonSearchResult.Ok(people));
        }
    }
}
