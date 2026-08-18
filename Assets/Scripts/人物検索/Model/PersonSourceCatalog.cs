namespace 人物検索
{
    /// <summary>選べる情報源の一覧。</summary>
    public static class PersonSourceCatalog
    {
        // P31=Q5 は「人間」。P31/P279* Q95074 は「架空のキャラクター」で、ゲームのキャラもここに入る。
        public static readonly PersonSource[] Sources =
        {
            new PersonSource("ja_person", "日本語Wikipedia ／ 実在の人物", "ja.wikipedia.org", "?item wdt:P31 wd:Q5"),
            new PersonSource("ja_character", "日本語Wikipedia ／ 架空のキャラクター", "ja.wikipedia.org", "?item wdt:P31/wdt:P279* wd:Q95074"),
            new PersonSource("en_person", "English Wikipedia ／ 実在の人物", "en.wikipedia.org", "?item wdt:P31 wd:Q5"),
            new PersonSource("en_character", "English Wikipedia ／ 架空のキャラクター", "en.wikipedia.org", "?item wdt:P31/wdt:P279* wd:Q95074"),
        };

        public static PersonSource Default => Sources[0];
    }
}
