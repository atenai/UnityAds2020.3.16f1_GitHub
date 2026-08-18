using System;
using System.Collections.Generic;

namespace 人物検索
{
    /// <summary>ネットに繋がずに表示を確認するための差し替え用。</summary>
    public sealed class FakePersonSearchService : IPersonSearchService
    {
        public void SearchAsync(string keyword, Action<PersonSearchResult> onCompleted)
        {
            List<PersonEntry> people = new List<PersonEntry>
            {
                new PersonEntry(1, "テスト太郎", "サンプルの人物", "オフライン確認用のダミーデータです。", ""),
                new PersonEntry(2, "テスト花子", "サンプルの人物", "検索ワード「" + keyword + "」に対する2件目のダミーです。", ""),
            };
            onCompleted(PersonSearchResult.Ok(people));
        }
    }
}
