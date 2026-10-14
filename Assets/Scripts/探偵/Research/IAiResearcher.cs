using System;

namespace 探偵
{
    public interface IAiResearcher
    {
        /// <summary>
        /// 調べてほしい内容を渡すと、AIがネットを検索して推測と証拠を返す。
        /// 時間がかかるので結果はコールバックで、メインスレッドに戻してから返す。
        /// </summary>
        void ResearchAsync(string request, Action<ResearchResult> onCompleted);

        /// <summary>調査中なら止める。止めた調査の結果は「中止しました」の失敗として返る。</summary>
        void Cancel();
    }
}
