using System.Collections.Generic;

namespace 人物検索
{
    public class PersonSearchResult
    {
        public bool Success { get; }
        public string ErrorMessage { get; }

        /// <summary>結果は返せたが、断り書きが要るときのメッセージ。</summary>
        public string Note { get; }

        public IReadOnlyList<PersonEntry> People { get; }

        PersonSearchResult(bool success, string errorMessage, string note, IReadOnlyList<PersonEntry> people)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Note = note;
            People = people;
        }

        public static PersonSearchResult Ok(IReadOnlyList<PersonEntry> people, string note = null)
        {
            return new PersonSearchResult(true, null, note, people);
        }

        public static PersonSearchResult Failure(string message)
        {
            return new PersonSearchResult(false, message, null, new List<PersonEntry>());
        }
    }
}
