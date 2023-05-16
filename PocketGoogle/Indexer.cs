using System;
using System.Collections.Generic;

namespace PocketGoogle
{
    public class Indexer : IIndexer
    {
        private Dictionary<string, Dictionary<int, List<int>>> documents
            = new Dictionary<string, Dictionary<int, List<int>>>();

        private string[] GetSplitedText(string documentText)
        {
            var separators = new char[]
            {
                ' ', '.', ',', '!', '?',
                ':', '-', '\r', '\n', '–'
            };

            return documentText
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        private List<T> GetList<T>(T value) => new List<T>() { value };

        public void Add(int id, string documentText)
        {
            var startIndex = 0;
            var text = GetSplitedText(documentText);

            foreach (var word in text)
            {
                if (documents.ContainsKey(word))
                    if (documents[word].ContainsKey(id))
                        documents[word][id].Add(documentText.IndexOf(word, startIndex));
                    else
                        documents[word].Add(id,
                             GetList(documentText.IndexOf(word, startIndex)));
                else
                {
                    documents.Add(word,
                        new Dictionary<int, List<int>>());
                    var listPosition = new List<int> {
                                    documentText.IndexOf(word, startIndex) };

                    documents[word].Add(id, listPosition);
                }

                startIndex += word.Length;
            }
        }

        public List<int> GetIds(string word)
        {
            var res = new List<int>();
            if (documents.ContainsKey(word))
                foreach (var item in documents[word].Keys)
                    res.Add(item);

            return res;

            //var res2 = documents.Where(d => d.Key == word).Select(d=> d.Value.Keys.ToList());
        }

        public List<int> GetPositions(int id, string word)
        {
            if (documents.ContainsKey(word))
                if (documents[word].ContainsKey(id))
                    return documents[word][id];
                else
                    return new List<int>();
            else
                return new List<int>();
        }

        public void Remove(int id)
        {
            foreach (var word in documents.Keys)
                if (documents[word].ContainsKey(id))
                    documents[word].Remove(id);
        }
    }
}
