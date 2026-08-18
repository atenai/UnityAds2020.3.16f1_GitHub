using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace 人物検索
{
    /// <summary>
    /// 日本語版Wikipediaで検索し、Wikidataで「人間(P31=Q5)」のものだけに絞り込む。
    /// Wikipedia側の検索には人物で絞る機能が無いので、2段構えにしている。
    /// </summary>
    public sealed class WikipediaPersonSearchService : IPersonSearchService
    {
        const string WikipediaEndpoint = "https://ja.wikipedia.org/w/api.php";
        const string SparqlEndpoint = "https://query.wikidata.org/sparql";
        const string ArticleUrl = "https://ja.wikipedia.org/?curid=";
        const string UserAgent = "UnityPersonTableSample/1.0 (Unity learning project)";
        const int Limit = 20;
        const int SummaryLength = 110;

        class Candidate
        {
            public int Index;
            public int PageId;
            public string Title;
            public string Description;
            public string Extract;
            public string EntityId;
        }

        public void SearchAsync(string keyword, Action<PersonSearchResult> onCompleted)
        {
            Get(BuildWikipediaUrl(keyword), (success, body, error) =>
            {
                if (!success)
                {
                    onCompleted(PersonSearchResult.Failure("Wikipediaへの通信に失敗しました: " + error));
                    return;
                }

                List<Candidate> candidates;
                string parseError;
                if (!TryParseWikipedia(body, out candidates, out parseError))
                {
                    onCompleted(PersonSearchResult.Failure(parseError));
                    return;
                }
                if (candidates.Count == 0)
                {
                    onCompleted(PersonSearchResult.Ok(new List<PersonEntry>()));
                    return;
                }

                FilterToPeople(candidates, onCompleted);
            });
        }

        void FilterToPeople(List<Candidate> candidates, Action<PersonSearchResult> onCompleted)
        {
            Get(BuildSparqlUrl(candidates), (success, body, error) =>
            {
                if (!success)
                {
                    // Wikidataが応えないときは絞り込みを諦めるが、黙って混ぜずに断り書きを出す。
                    onCompleted(PersonSearchResult.Ok(ToEntries(candidates), "※人物かどうかの判定はできませんでした（Wikidataに接続できず）"));
                    return;
                }

                HashSet<string> people = ParseHumanIds(body);
                List<Candidate> filtered = candidates.FindAll(candidate => people.Contains(candidate.EntityId));
                onCompleted(PersonSearchResult.Ok(ToEntries(filtered)));
            });
        }

        static string BuildWikipediaUrl(string keyword)
        {
            return WikipediaEndpoint
                + "?action=query&format=json&formatversion=2&generator=search"
                + "&gsrsearch=" + UnityWebRequest.EscapeURL(keyword)
                + "&gsrlimit=" + Limit
                + "&prop=pageprops%7Cdescription%7Cextracts&ppprop=wikibase_item"
                + "&exintro=1&explaintext=1&exsentences=2&exlimit=" + Limit
                + "&origin=*";
        }

        static string BuildSparqlUrl(List<Candidate> candidates)
        {
            System.Text.StringBuilder values = new System.Text.StringBuilder();
            foreach (Candidate candidate in candidates)
            {
                values.Append("wd:").Append(candidate.EntityId).Append(' ');
            }

            string query = "SELECT ?item WHERE { VALUES ?item { " + values + "} ?item wdt:P31 wd:Q5 }";
            return SparqlEndpoint + "?format=json&query=" + UnityWebRequest.EscapeURL(query);
        }

        static bool TryParseWikipedia(string json, out List<Candidate> candidates, out string error)
        {
            candidates = new List<Candidate>();
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
            if (response.query == null || response.query.pages == null) return true;

            foreach (WikipediaPage page in response.query.pages)
            {
                if (page.pageprops == null || string.IsNullOrEmpty(page.pageprops.wikibase_item)) continue;

                candidates.Add(new Candidate
                {
                    Index = page.index,
                    PageId = page.pageid,
                    Title = page.title,
                    Description = page.description,
                    Extract = page.extract,
                    EntityId = page.pageprops.wikibase_item,
                });
            }
            return true;
        }

        static HashSet<string> ParseHumanIds(string json)
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
                entries.Add(new PersonEntry(
                    candidate.Index,
                    candidate.Title,
                    string.IsNullOrEmpty(candidate.Description) ? "-" : candidate.Description,
                    Shorten(candidate.Extract),
                    ArticleUrl + candidate.PageId));
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
