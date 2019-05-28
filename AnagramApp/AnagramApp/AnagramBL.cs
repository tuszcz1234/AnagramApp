using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramApp
{
    public class AnagramBL
    {
        public List<List<string>> FindAllAnagramLists(List<string> words, List<List<string>> result)
        {
            if(words.Count > 0)
            {
                var wordToCompare = words.FirstOrDefault();

                words.Remove(wordToCompare);

                var anagramList = FindAnagram(wordToCompare, words);

                result.Add(anagramList);

                foreach (var word in anagramList)
                {
                    words.Remove(word);
                }

                return FindAllAnagramLists(words, result);
            }
            else
            {
                return result;
            }
        }

        public List<List<string>> FindLongestWordAnagram(List<List<string>> allAnagramLists)
        {
            var result = new List<List<string>>();

            var longestAnagramSize = 0;

            foreach (var anagramList in allAnagramLists)
            {
                if (anagramList.FirstOrDefault().Length > longestAnagramSize)
                {
                    result = new List<List<string>>();

                    longestAnagramSize = anagramList.FirstOrDefault().Length;

                    result.Add(anagramList);
                }
                else if (anagramList.FirstOrDefault().Length == longestAnagramSize)
                {
                    result.Add(anagramList);
                }
            }

            return result;
        }

        public List<List<string>> FindMostWordAnagram(List<List<string>> allAnagramLists)
        {
            var result = new List<List<string>>();

            var mostWordAnagramSize = 0;

            foreach (var anagramList in allAnagramLists)
            {
                if (anagramList.Count > mostWordAnagramSize)
                {
                    result = new List<List<string>>();

                    mostWordAnagramSize = anagramList.Count;

                    result.Add(anagramList);
                }
                else if (anagramList.Count == mostWordAnagramSize)
                {
                    result.Add(anagramList);
                }
            }

            return result;
        }

        private List<string> FindAnagram(string wordToCompare, List<string> words)
        {
            var sortedWordToCompare = SortLetterInString(wordToCompare);
            var anagramList = new List<string>() { wordToCompare };

            foreach (var word in words)
            {
                var sortedWord = SortLetterInString(word);

                if (sortedWord == sortedWordToCompare)
                {
                    anagramList.Add(word);
                }
            }

            return anagramList;
        }

        private string SortLetterInString(string word)
        {
            return String.Concat(word.OrderBy(x => x));
        }
    }
}
