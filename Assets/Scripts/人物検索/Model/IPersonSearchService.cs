using System;

namespace 人物検索
{
    public interface IPersonSearchService
    {
        void SearchAsync(PersonSource source, string keyword, Action<PersonSearchResult> onCompleted);
    }
}
