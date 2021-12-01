using _05_testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05_testing.Tests
{
    class AnagramChecker : IAnagramChecker
    {
        private readonly Regex regex = new Regex("[^a-zA-Z0-9]");
        private Dictionary<char, int> WordToDictionary(string word)
        {
            var listOfLetters = new Dictionary<char, int>();
            foreach (var item in word)
            {

                if (listOfLetters.ContainsKey(item))
                {
                    listOfLetters[item] += 1;
                }
                else
                {
                    listOfLetters.Add(item, 1);
                }


            }
            return listOfLetters;
        }
        private bool DictionaryEquals(Dictionary<char, int> d1, Dictionary<char, int> d2)
        {
            if (d1.Count != d2.Count)
            {
                return false;
            }

            foreach (var item in d1)
            {
                if (d2.ContainsKey(item.Key))
                {
                    if (!(d2[item.Key] == item.Value))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            foreach (var item in d2)
            {
                if (d1.ContainsKey(item.Key))
                {
                    if (!(d1[item.Key] == item.Value))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsAnagram(string word1, string word2)
        {
            word1 = word1.ToLower();
            word2 = word2.ToLower();
            word1 = regex.Replace(word1, String.Empty);
            word2 = regex.Replace(word2, String.Empty);
            var listOfLetters1 = WordToDictionary(word1);
            var listOfLetters2 = WordToDictionary(word2);
            if (DictionaryEquals(listOfLetters2, listOfLetters1))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}