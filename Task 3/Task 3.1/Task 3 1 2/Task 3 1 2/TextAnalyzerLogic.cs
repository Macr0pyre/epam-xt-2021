using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3_1_2
{
    public class TextAnalyzerLogic
    {
        public string Text { get; set; }

        public TextAnalyzerLogic() => Text = string.Empty;

        public TextAnalyzerLogic(string text) => Text = text;


        /// <summary>
        /// The method counts the frequency of words in the text and returns a Dictionary.
        /// The key is a word, the value is the number of its repetitions in the text.
        /// </summary>
        public Dictionary<string, int> WordsFrequency()
        {
            string[] words = TextSplit(Text);

            Dictionary<string, int> vocabulary = new Dictionary<string, int>();
            foreach (string item in words)
            {
                string word = item.ToLower();

                if (vocabulary.ContainsKey(word))
                {
                    vocabulary[word]++;
                }
                else
                {
                    vocabulary[word] = 1;
                }
            }

            return vocabulary.OrderByDescending(item => item.Value)
                             .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private string[] TextSplit(string text)
        {
            //using HashSet collection because original separators are needed
            HashSet<char> separators = new HashSet<char>() { ' ', '"', '«', '»', '<', '>' };
            foreach (char item in text)
            {
                if (char.IsPunctuation(item) && item != '-')
                    separators.Add(item);
            }

            return text.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
