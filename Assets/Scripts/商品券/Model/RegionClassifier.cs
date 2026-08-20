namespace 商品券
{
    /// <summary>
    /// タイトルと媒体名から、その商品券が使える範囲を推定する。
    /// 見出しだけが手がかりなので確実ではない。判定できないものは Unknown にして残す。
    /// </summary>
    public static class RegionClassifier
    {
        // 全国で使える券種。「ギフトカード」のような一般語は誤判定が多いので銘柄で見る。
        static readonly string[] NationwideWords =
        {
            "全国", "全国共通", "全国百貨店共通商品券",
            "QUOカード", "クオカード", "Amazonギフト", "アマゾンギフト", "Amazonギフトカード",
            "JCBギフトカード", "JCBプレモ", "VJAギフトカード", "UCギフトカード", "VISAギフト",
            "図書カード", "おこめ券", "ビール券", "ジェフグルメカード", "こども商品券",
            "楽天ギフト", "iTunesカード", "Google Play", "App Store", "プリペイドカード",
        };

        static readonly string[] TokyoWords =
        {
            "東京都", "東京",
            "千代田区", "中央区", "港区", "新宿区", "文京区", "台東区", "墨田区", "江東区",
            "品川区", "目黒区", "大田区", "世田谷区", "渋谷区", "中野区", "杉並区", "豊島区",
            "北区", "荒川区", "板橋区", "練馬区", "足立区", "葛飾区", "江戸川区",
            "八王子", "立川市", "武蔵野市", "三鷹市", "青梅市", "府中市", "昭島市", "調布市",
            "町田市", "小金井市", "小平市", "日野市", "東村山市", "国分寺市", "国立市",
            "福生市", "狛江市", "東大和市", "清瀬市", "東久留米市", "武蔵村山市", "多摩市",
            "稲城市", "羽村市", "あきる野市", "西東京市",
            // 地域紙などはひらがな表記が多い（例: すみだ経済新聞）。
            // 「きた」「みなと」「なかの」のような一般語になるものは、
            // 誤判定が多いので入れていない。
            "すみだ", "しんじゅく", "いたばし", "ねりま", "せたがや", "しながわ",
            "あだち", "かつしか", "えどがわ", "ちよだ", "ぶんきょう", "としま",
            "あらかわ", "めぐろ", "しぶや", "すぎなみ", "はちおうじ", "むさしの",
        };

        // 自治体サイトのドメイン。東京は city.○○.tokyo.jp や metro.tokyo.lg.jp の形。
        static readonly string[] TokyoDomains = { ".tokyo.jp", ".tokyo.lg.jp", "metro.tokyo" };

        // 他県の自治体ドメイン。city.ota.gunma.jp のように県名が入るので、そこで拾う。
        static readonly string[] OtherPrefectureDomains =
        {
            ".hokkaido.jp", ".aomori.jp", ".iwate.jp", ".miyagi.jp", ".akita.jp", ".yamagata.jp", ".fukushima.jp",
            ".ibaraki.jp", ".tochigi.jp", ".gunma.jp", ".saitama.jp", ".chiba.jp", ".kanagawa.jp",
            ".niigata.jp", ".toyama.jp", ".ishikawa.jp", ".fukui.jp", ".yamanashi.jp", ".nagano.jp",
            ".gifu.jp", ".shizuoka.jp", ".aichi.jp", ".mie.jp", ".shiga.jp", ".kyoto.jp", ".osaka.jp",
            ".hyogo.jp", ".nara.jp", ".wakayama.jp", ".tottori.jp", ".shimane.jp", ".okayama.jp",
            ".hiroshima.jp", ".yamaguchi.jp", ".tokushima.jp", ".kagawa.jp", ".ehime.jp", ".kochi.jp",
            ".fukuoka.jp", ".saga.jp", ".nagasaki.jp", ".kumamoto.jp", ".oita.jp", ".miyazaki.jp",
            ".kagoshima.jp", ".okinawa.jp",
        };

        // 東京以外の都道府県名。市町村名まで並べるときりが無いので県名で拾う。
        static readonly string[] OtherPrefectures =
        {
            "北海道", "青森", "岩手", "宮城", "秋田", "山形", "福島",
            "茨城", "栃木", "群馬", "埼玉", "千葉", "神奈川",
            "新潟", "富山", "石川", "福井", "山梨", "長野", "岐阜", "静岡", "愛知",
            "三重", "滋賀", "京都", "大阪", "兵庫", "奈良", "和歌山",
            "鳥取", "島根", "岡山", "広島", "山口",
            "徳島", "香川", "愛媛", "高知",
            "福岡", "佐賀", "長崎", "熊本", "大分", "宮崎", "鹿児島", "沖縄",
        };

        public static Region Classify(string text)
        {
            if (string.IsNullOrEmpty(text)) return Region.Unknown;

            string lower = text.ToLowerInvariant();

            // 券種が全国共通なら、記事の発信元が地方紙でも全国扱いでよい。
            if (ContainsAny(text, NationwideWords)) return Region.Nationwide;
            if (ContainsAny(text, TokyoWords) || ContainsAny(lower, TokyoDomains)) return Region.Tokyo;
            if (ContainsAny(lower, OtherPrefectureDomains)) return Region.OtherLocal;

            // ここまでで東京と判定されていない自治体サイトは他県のものとみなす。
            // 例: city.sakai.lg.jp（堺市）はローマ字なので県名では拾えない。
            if (lower.Contains(".lg.jp")) return Region.OtherLocal;

            if (ContainsAny(text, OtherPrefectures)) return Region.OtherLocal;

            // 東京の地名が出ていないのに市区町村の話なら、他県のローカル施策とみなす。
            if (text.Contains("市") || text.Contains("町") || text.Contains("村")) return Region.OtherLocal;

            return Region.Unknown;
        }

        public static string Label(Region region)
        {
            switch (region)
            {
                case Region.Nationwide: return "全国";
                case Region.Tokyo: return "東京";
                case Region.OtherLocal: return "他県";
                default: return "不明";
            }
        }

        static bool ContainsAny(string text, string[] words)
        {
            foreach (string word in words)
            {
                if (text.Contains(word)) return true;
            }
            return false;
        }
    }
}
