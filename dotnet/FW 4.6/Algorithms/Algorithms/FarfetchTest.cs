using System;
using System.Collections.Generic;
using System.Linq; 

namespace Algorithms
{
   public static class FarfetchTest
    {
        #region Farfetch
        //1 - Farfetch Find Words in a Text
        public static void InputFindWordsInText()
        {
            string text = "I am using  HackerRank to improve programming am HackerRank to improve";
            string words = "I using programming";
            List<String> ListWordsFound = FindWordsInText(words, text).ToList();
            ListWordsFound.ForEach(i => Console.WriteLine(i));
        }

        //2 - Farfetch Find Words in a Text
        public static string[] FindWordsInText(string words, string text)
        {
            var ListText = WordsToList(text);
            var ListWordsToCheckInText = WordsToList(words);

            List<string> ListResult = new List<string>();

            foreach (var item in ListWordsToCheckInText)
            {
                if (ListText.Contains(item))
                {
                    ListResult.Add(item);
                }
            }

            return ListResult.ToArray();
        }
        //3 - Farfetch Find Words in a Text
        private static List<string> WordsToList(string text)
        {
            List<string> ListWords = new List<string>();
            int lastPos = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].ToString() == " ")
                {
                    ListWords.Add(text.Substring(lastPos, i - lastPos));
                    lastPos = i + 1;
                }
                else
                {
                    if (i == text.Length - 1)
                        ListWords.Add(text.Substring(lastPos));
                }
            }

            return ListWords;
        }
        #endregion
    }
}
