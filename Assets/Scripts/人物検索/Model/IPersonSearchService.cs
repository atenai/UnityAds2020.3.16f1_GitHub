using System;

namespace 人物検索
{
    public interface IPersonSearchService
    {
        void SearchAsync(string keyword, Action<PersonSearchResult> onCompleted);
    }
}
