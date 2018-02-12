namespace _03_WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            string words = @"..\00_Resources\words.txt";
            string text = @"..\00_Resources\text.txt";
            string outputPath = @"..\00_OutputFiles\WordCount.txt";

            CountWords(wordCount, words, text);
            WriteCountedWords(wordCount, outputPath);
        }

        private static void WriteCountedWords(Dictionary<string, int> wordCount, string outputPath)
        {
            var orderedWordCount = wordCount.OrderByDescending(w => w.Value);
            using(var streamWriter = new StreamWriter(outputPath))
            {
                foreach (var word in orderedWordCount)
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }

        private static void CountWords(Dictionary<string, int> wordCount, string words, string text)
        {
            using (var wordsReader = new StreamReader(words))
            {
                string word;
                while ((word = wordsReader.ReadLine()) != null)
                {
                    wordCount.Add(word.ToLower(), 0);
                }
            }

            using (var textReader = new StreamReader(text))
            {
                string textLine;
                while ((textLine = textReader.ReadLine()) != null)
                {
                    string[] splittedLine = textLine
                        .Split(" ,-.?!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in splittedLine)
                    {
                        if (wordCount.ContainsKey(word.ToLower()))
                        {
                            wordCount[word.ToLower()]++;
                        }
                    }
                }
            }            
        }
    }
}
