using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace 探偵
{
    /// <summary>
    /// 一部の数字が黒丸で隠された電話番号の形（例：•••-••••-••05）。
    /// 黒丸は打ちにくいので ● ・ * ? x なども受け付け、内部では • にそろえる。
    /// AIの候補がこの形（桁数・ハイフンの位置・見えている数字）に合うかを確かめるのに使う。
    /// </summary>
    public sealed class PhoneMask
    {
        public const char Hidden = '•';

        const string HiddenChars = "•●○◯・･*＊?？xX×＿_";
        const string HyphenChars = "-－‐−ー–";
        const int MinLength = 6; // これより短い記号の並びは電話番号の形とみなさない

        static readonly Regex TokenPattern = new Regex(
            "[0-9０-９" + EscapeForCharClass(HiddenChars + HyphenChars) + "]+");

        public string Pattern { get; }

        public int HiddenCount
        {
            get
            {
                int count = 0;
                foreach (char c in Pattern)
                {
                    if (c == Hidden) count++;
                }
                return count;
            }
        }

        PhoneMask(string pattern)
        {
            Pattern = pattern;
        }

        /// <summary>手掛かりの文章から、黒丸を含む電話番号の形を探す。</summary>
        public static bool TryExtract(string text, out PhoneMask mask)
        {
            mask = null;
            if (string.IsNullOrEmpty(text)) return false;

            foreach (Match match in TokenPattern.Matches(text))
            {
                string pattern = Normalize(match.Value).Trim('-');
                if (pattern.Length < MinLength || pattern.IndexOf(Hidden) < 0) continue;

                mask = new PhoneMask(pattern);
                return true;
            }
            return false;
        }

        /// <summary>候補の番号を、全角数字やいろいろなハイフンを直したうえで、形に合うか確かめる。</summary>
        public bool Matches(string candidate)
        {
            string normalized = NormalizeCandidate(candidate);
            if (normalized.Length != Pattern.Length) return false;

            for (int i = 0; i < Pattern.Length; i++)
            {
                char expected = Pattern[i];
                char actual = normalized[i];
                if (expected == Hidden)
                {
                    if (actual < '0' || actual > '9') return false;
                }
                else if (expected != actual)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>形に合う候補だけを、表記をそろえて返す。合わなかった数を excluded に入れる。</summary>
        public List<AnswerCandidate> Filter(IReadOnlyList<AnswerCandidate> answers, out int excluded)
        {
            List<AnswerCandidate> result = new List<AnswerCandidate>();
            excluded = 0;
            foreach (AnswerCandidate answer in answers)
            {
                if (!Matches(answer.Title))
                {
                    excluded++;
                    continue;
                }
                result.Add(new AnswerCandidate(NormalizeCandidate(answer.Title), answer.Confidence, answer.Reasoning,
                    ToArray(answer.Sources)));
            }
            return result;
        }

        public static string NormalizeCandidate(string candidate)
        {
            return Normalize(candidate ?? "").Replace(" ", "").Replace("　", "");
        }

        static string Normalize(string text)
        {
            StringBuilder builder = new StringBuilder(text.Length);
            foreach (char c in text)
            {
                if (c >= '０' && c <= '９') builder.Append((char)('0' + (c - '０')));
                else if (HiddenChars.IndexOf(c) >= 0) builder.Append(Hidden);
                else if (HyphenChars.IndexOf(c) >= 0) builder.Append('-');
                else builder.Append(c);
            }
            return builder.ToString();
        }

        // [ ] の中では - が範囲指定になってしまうので、意味を持つ文字には \ を付ける
        static string EscapeForCharClass(string chars)
        {
            StringBuilder builder = new StringBuilder();
            foreach (char c in chars)
            {
                if ("\\]^-[".IndexOf(c) >= 0) builder.Append('\\');
                builder.Append(c);
            }
            return builder.ToString();
        }

        static SourceLink[] ToArray(IReadOnlyList<SourceLink> sources)
        {
            SourceLink[] array = new SourceLink[sources.Count];
            for (int i = 0; i < sources.Count; i++)
            {
                array[i] = sources[i];
            }
            return array;
        }
    }
}
