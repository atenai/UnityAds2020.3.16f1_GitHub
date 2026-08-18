using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace 人物検索
{
    /// <summary>
    /// 指定されたWikipediaを全文検索し、Wikidataで種類を絞り込んで人物を集める。
    /// Wikipedia側の検索には種類で絞る機能が無いので2段構えにしている。
    /// 1ページの取得数はAPIの制限(extractsは20件まで)に合わせ、目標件数に届くまでページを送る。
    /// </summary>
    public sealed class WikipediaPersonSearchService : IPersonSearchService
    {
        const string SparqlEndpoint = "https://query.wikidata.org/sparql";
        const string UserAgent = "UnityPersonTableSample/1.0 (Unity learning project)";
        const int PageSize = 20;     // extracts の上限
        const int MaxPages = 4;      // 候補は最大80件まで見る
        const int TargetCount = 30;  // 表に出す人数
        const int SummaryLength = 110;

        class Candidate
        {
            public int Index;
            public int PageId;
            public string Host;
            public string Title;
            public string Description;
            public string Extract;
            public string EntityId;
            public string ImageUrl;
        }

        public void SearchAsync(PersonSource source, string keyword, Action<PersonSearchResult> onCompleted)
        {
            FetchPage(source, keyword, 0, 0, new List<Candidate>(), onCompleted);
        }

        void FetchPage(PersonSource source, string keyword, int offset, int page, List<Candidate> collected,
            Action<PersonSearchResult> onCompleted)
        {
            Get(BuildWikipediaUrl(source, keyword, offset), (success, body, error) =>
            {
                if (!success)
                {
                    onCompleted(PersonSearchResult.Failure("Wikipediaへの通信に失敗しました: " + error));
                    return;
                }

                int nextOffset;
                string parseError;
                if (!TryParseWikipedia(body, source, offset, collected, out nextOffset, out parseError))
                {
                    onCompleted(PersonSearchResult.Failure(parseError));
                    return;
                }

                if (nextOffset > 0 && page + 1 < MaxPages)
                {
                    FetchPage(source, keyword, nextOffset, page + 1, collected, onCompleted);
                    return;
                }

                if (collected.Count == 0)
                {
                    onCompleted(PersonSearchResult.Ok(new List<PersonEntry>()));
                    return;
                }
                FilterByEntityType(source, collected, onCompleted);
            });
        }

        void FilterByEntityType(PersonSource source, List<Candidate> candidates, Action<PersonSearchResult> onCompleted)
        {
            Get(BuildSparqlUrl(source, candidates), (success, body, error) =>
            {
                if (!success)
                {
                    // Wikidataが応えないときは絞り込みを諦めるが、黙って混ぜずに断り書きを出す。
                    onCompleted(PersonSearchResult.Ok(ToEntries(candidates), "※種類の判定はできませんでした(Wikidataに接続できず)"));
                    return;
                }

                HashSet<string> matched = ParseMatchedIds(body);
                List<Candidate> filtered = candidates.FindAll(candidate => matched.Contains(candidate.EntityId));

                // 目標に届かなかったときは、どれだけ探した結果なのかを伝える。
                string note = filtered.Count >= TargetCount
                    ? null
                    : "候補" + candidates.Count + "件を調べて該当は" + filtered.Count + "件でした";
                onCompleted(PersonSearchResult.Ok(ToEntries(filtered), note));
            });
        }

        static string BuildWikipediaUrl(PersonSource source, string keyword, int offset)
        {
            return "https://" + source.Host + "/w/api.php"
                + "?action=query&format=json&formatversion=2&generator=search"
                + "&gsrsearch=" + UnityWebRequest.EscapeURL(keyword)
                + "&gsrlimit=" + PageSize
                + "&gsroffset=" + offset
                + "&prop=pageprops%7Cdescription%7Cextracts%7Cpageimages&ppprop=wikibase_item"
                + "&piprop=thumbnail&pithumbsize=160"
                + "&exintro=1&explaintext=1&exsentences=2&exlimit=" + PageSize
                + "&origin=*";
        }

        static string BuildSparqlUrl(PersonSource source, List<Candidate> candidates)
        {
            StringBuilder values = new StringBuilder();
            foreach (Candidate candidate in candidates)
            {
                values.Append("wd:").Append(candidate.EntityId).Append(' ');
            }

            string query = "SELECT DISTINCT ?item WHERE { VALUES ?item { " + values + "} " + source.EntityFilter + " }";
            return SparqlEndpoint + "?format=json&query=" + UnityWebRequest.EscapeURL(query);
        }

        static bool TryParseWikipedia(string json, PersonSource source, int offset, List<Candidate> collected,
            out int nextOffset, out string error)
        {
            nextOffset = 0;
            error = null;

            WikipediaResponse response = JsonUtility.FromJson<WikipediaResponse>(json);
            if (response == null)
            {
                error = "応答を解釈できませんでした";
                return false;
            }
            // JsonUtility は error を必ず生成するので、中身が入っているかで見る。
            if (response.error != null && !string.IsNullOrEmpty(response.error.code))
            {
                error = "Wikipedia: " + response.error.info;
                return false;
            }
            if (response.@continue != null) nextOffset = response.@continue.gsroffset;
            if (response.query == null || response.query.pages == null) return true;

            foreach (WikipediaPage page in response.query.pages)
            {
                if (page.pageprops == null || string.IsNullOrEmpty(page.pageprops.wikibase_item)) continue;

                collected.Add(new Candidate
                {
                    // pages の配列順は不定で、関連度は index が持っている。ページ送りのぶんを足して通し順位にする。
                    Index = offset + page.index,
                    PageId = page.pageid,
                    Host = source.Host,
                    Title = page.title,
                    Description = page.description,
                    Extract = page.extract,
                    EntityId = page.pageprops.wikibase_item,
                    ImageUrl = page.thumbnail == null ? null : page.thumbnail.source,
                });
            }
            return true;
        }

        static HashSet<string> ParseMatchedIds(string json)
        {
            HashSet<string> ids = new HashSet<string>();
            SparqlResponse response = JsonUtility.FromJson<SparqlResponse>(json);
            if (response == null || response.results == null || response.results.bindings == null) return ids;

            foreach (SparqlBinding binding in response.results.bindings)
            {
                if (binding.item == null || string.IsNullOrEmpty(binding.item.value)) continue;

                int slash = binding.item.value.LastIndexOf('/');
                ids.Add(slash < 0 ? binding.item.value : binding.item.value.Substring(slash + 1));
            }
            return ids;
        }

        static List<PersonEntry> ToEntries(List<Candidate> candidates)
        {
            candidates.Sort((left, right) => left.Index.CompareTo(right.Index)); // APIの並び順＝検索の関連度順

            List<PersonEntry> entries = new List<PersonEntry>();
            foreach (Candidate candidate in candidates)
            {
                if (entries.Count >= TargetCount) break;

                entries.Add(new PersonEntry(
                    entries.Count + 1,
                    candidate.Title,
                    string.IsNullOrEmpty(candidate.Description) ? "-" : candidate.Description,
                    Shorten(candidate.Extract),
                    "https://" + candidate.Host + "/?curid=" + candidate.PageId,
                    candidate.ImageUrl));
            }
            return entries;
        }

        static void Get(string url, Action<bool, string, string> onCompleted)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);
            request.SetRequestHeader("User-Agent", UserAgent);
            request.SetRequestHeader("Accept", "application/json");
            request.timeout = 20;

            request.SendWebRequest().completed += _ =>
            {
                bool success = request.result == UnityWebRequest.Result.Success;
                string body = success ? request.downloadHandler.text : null;
                string error = request.error;
                request.Dispose();

                onCompleted(success, body, error);
            };
        }

        static string Shorten(string extract)
        {
            if (string.IsNullOrEmpty(extract)) return "-";

            string text = extract.Replace("\n", " ").Replace("\r", " ").Trim();
            return text.Length <= SummaryLength ? text : text.Substring(0, SummaryLength) + "…";
        }
    }
}
