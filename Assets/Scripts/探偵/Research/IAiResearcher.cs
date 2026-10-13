using System;

namespace 探偵
{
    public interface IAiResearcher
    {
        /// <summary>
        /// 推測するものと依頼文を渡すと、AIがネットを検索して候補を返す。
        /// 推測するものによって、使うエージェント（調べ方）が変わる。
        /// 時間がかかるので結果はコールバックで、メインスレッドに戻してから返す。
        /// </summary>
        void ResearchAsync(GuessTarget target, string request, Action<ResearchResult> onCompleted);

        /// <summary>調査中なら止める。止めた調査の結果は「中止しました」の失敗として返る。</summary>
        void Cancel();
    }
}
