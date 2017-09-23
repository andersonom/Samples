using System;
using System.Linq;

namespace Algorithms
{
    public static class HackerRank
    {       
        #region HackerRank
        //1 - HackerRank - Pass an array of strings containing (), {} and [], return YES or NO for each string
        public static void InputOpenCloseChars()
        {
            var input = new string[] { "{[", "{)", "()", "{}[]()" };

            var resultStrings = HackerRank.CheckOpeningAndClosingStringArray(input).ToList();

            resultStrings.ForEach(i => Console.WriteLine(i));
        }

        // 2 - Input should be like = string{ "[]{}()", "{}()[]", ...
        public static string[] CheckOpeningAndClosingStringArray(string[] values)
        {
            var result = new string[values.Length];

            for (int i = 0; i < values.Length; i++)
            {
                char[] stringToChars = values[i].ToCharArray();
                result[i] = CheckOpeningAndClosing(stringToChars, i);
            }

            return result;
        }
        //3 - Input should be like "[]{}()"
        public static string CheckOpeningAndClosing(char[] fChar, int iArr)
        {
            for (int i = 0; i <= fChar.Length; i++)
            {
                if (i < fChar.Length)
                {
                    if (fChar[i].ToString() == "{" && fChar[i + 1].ToString() != "}")
                    { return "NO"; }
                    if (fChar[i].ToString() == "(" && fChar[i + 1].ToString() != ")")
                    { return "NO"; }
                    if (fChar[i].ToString() == "[" && fChar[i + 1].ToString() != "]")
                    { return "NO"; }
                }
            }
            return "Yes";
        }
        #endregion

        public static void Get(int n) {

            int count = n;
            string space = "";
            string print = "";

            for (int i = 0; i < n; i++)
            {
                space = "";
                for (int i2 = 1; i2 < count; i2++)
                {
                    space = space + " ";
                }
                count = count - 1;

                print = print + "#";
                Console.WriteLine(space + print);

            }
        }

    }
}
