namespace 商品券
{
    /// <summary>その商品券がどこで使えるか。</summary>
    public enum Region
    {
        /// <summary>判定できなかった。除外はしない。</summary>
        Unknown,

        /// <summary>全国で使えるもの（QUOカード、全国百貨店共通商品券など）。</summary>
        Nationwide,

        /// <summary>東京都およびその区市町村のもの。</summary>
        Tokyo,

        /// <summary>他県限定のもの。東京在住では使えない。</summary>
        OtherLocal,
    }
}
