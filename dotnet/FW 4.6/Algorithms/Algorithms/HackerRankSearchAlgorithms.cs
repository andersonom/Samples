using System;
using System.Collections.Generic;
using System.Linq; 

namespace Algorithms
{
    public static class HackerRankSearchAlgorithms
    {
        /// <summary>
        /// https://www.hackerearth.com/practice/algorithms/searching/linear-search/practice-problems/algorithm/monk-takes-a-walk/
        /// </summary>
        public static void MonkWalks()
        {
            char[] trees = { 'A', 'E', 'I', 'O', 'U' };

            int qtdLinesT = Convert.ToInt32(Console.ReadLine().Trim());

            string[] lines = new string[qtdLinesT];
            for (int i = 0; i < qtdLinesT; i++)
            {
                lines[i] = Console.ReadLine().Trim().ToUpper();
            }

            for (int i = 0; i < qtdLinesT; i++)
            {
                int treeCount = 0;

                for (int i2 = 0; i2 < lines[i].Length; i2++)
                {
                    for (int i3 = 0; i3 < trees.Length; i3++)
                    {
                        if (lines[i][i2] == trees[i3])
                            treeCount++;
                    }
                }

                Console.WriteLine(treeCount);
            }
        }
        /// <summary>
        /// https://www.hackerearth.com/practice/algorithms/searching/ternary-search/practice-problems/algorithm/puzzled-grid-1/
        /// </summary>
        public static void PuzzledGrid()
        {
            var arrQn = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            int q = arrQn[0];
            int n = arrQn[1];

            int[,] grid = new int[q, q];

            for (int i = 0; i < q; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

                for (int i2 = 0; i2 < q; i2++)
                {
                    grid[i, i2] = arr[i2];
                }
            }

            int[,] path = new int[n, 4];
            for (int i = 0; i < n; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);//4 pos
                path[i, 0] = arr[0];
                path[i, 1] = arr[1];
                path[i, 2] = arr[2];
                path[i, 3] = arr[3];
            }

            //rounds
            for (int i = 0; i < n; i++)
            {
                int x = path[i, 0];//0
                int y = path[i, 1];//0

                int x2 = path[i, 2];//2
                int y2 = path[i, 3];//2

                bool descer = x2 - x >= 0;
                bool andarFrente = y2 - y >= 0;

                int maxValue = 0;

                if (descer)
                {
                    for (int itemY = y; itemY <= x2; itemY++)
                    {
                        if (grid[itemY, x] > maxValue)
                            maxValue = grid[itemY, x];
                    }
                }
                else
                {
                    for (int itemY = y; itemY >= x2; itemY--)
                    {
                        if (grid[itemY, x] > maxValue)
                            maxValue = grid[itemY, x];
                    }
                }

                if (andarFrente)
                {
                    for (int itemX = x; itemX <= y2; itemX++)
                    {
                        if (grid[y2, itemX] > maxValue)
                            maxValue = grid[y2, itemX];
                    }
                }
                else
                {
                    for (int itemX = x; itemX >= y2; itemX--)
                    {
                        if (grid[y2, itemX] > maxValue)
                            maxValue = grid[y2, itemX];
                    }
                }

                Console.WriteLine(maxValue);
            }
        }

        /// <summary>
        /// https://www.hackerearth.com/practice/algorithms/searching/binary-search/tutorial/
        /// </summary>     
        public static int BinarySearch(int[] a, int key)
        {
            int low = 0;
            int high = a.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;//4//7

                if (a[mid] < key)// Se Posicao 4 for MENOR que 3 = false | Se 1 MENOR que 3 = true
                {
                    low = mid + 1; // nao passou | low = 1 + 1 | low = 2 + 1
                }
                else if (a[mid] > key)// Se Posicao 4 for MAIOR que 3 = true
                {
                    high = mid - 1;// high = 4 - 1 = 3
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        /// <summary>
        /// https://www.hackerearth.com/practice/algorithms/searching/ternary-search/tutorial/
        /// </summary>   
        public static int TernarySearch(int[] ar, int l, int r, int x)
        {
            if (r >= l)
            {
                int mid1 = l + (r - l) / 3;
                int mid2 = r - (r - l) / 3;
                if (ar[mid1] == x)
                    return mid1;
                if (ar[mid2] == x)
                    return mid2;
                if (x < ar[mid1])
                    return TernarySearch(ar, l, mid1 - 1, x);
                else if (x > ar[mid2])
                    return TernarySearch(ar, mid2 + 1, r, x);
                else
                    return TernarySearch(ar, mid1 + 1, mid2 - 1, x);

            }
            return -1;
        }

        public static void ReturnSum()
        {
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            Console.WriteLine(arr.Sum());
        }

        public static void ReturnSumOld()
        {
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            Int64 result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += Convert.ToInt64(arr[i]);
            }

            Console.WriteLine(result);
        }
        /// <summary>
        /// https://www.hackerearth.com/practice/algorithms/searching/ternary-search/practice-problems/algorithm/the-exam/
        /// </summary>
        public static void TernaryMana()
        {
            int qtdLinesT = Convert.ToInt32(Console.ReadLine().Trim());
            const int qtdCols = 3;

            int[,] X = new int[qtdLinesT, qtdCols];

            for (int i = 0; i < qtdLinesT; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

                X[i, 0] = arr[0];
                X[i, 1] = arr[1];
                X[i, 2] = arr[2];
            }

            int mana = 1;
            int totalMana;
            for (int i = 0; i < X.Rank; i++)
            {
                totalMana = 0;

                for (int i2 = 0; i2 < X[i, 0]; i2++)
                {
                    if (X[i, 0] >= X[i, 2])
                        break;
                    else
                    { X[i, 2] = X[i, 2] - mana; totalMana++; }

                }
                Console.WriteLine(totalMana);
            }
        }

        public static void BreakAppCall()
        {
            var qutLines = Convert.ToInt32(Console.ReadLine());

            string[] lines = new String[qutLines];

            for (int i = 0; i < qutLines; i++)
            {
                lines[i] = Console.ReadLine();
            }

            Console.WriteLine(HackerRankSearchAlgorithms.BreakApp(qutLines, lines));
        }

		public static string BreakApp(int qutLines, string[] temp)
        {
            List<Tuple<int, int>> days = new List<Tuple<int, int>>();
            string[] lines = new string[qutLines];

            for (int i = 0; i < qutLines; i++)
            {
                lines[i] = temp[i].Substring(0, Math.Min(999, temp[i].Length));

                string daysTemp = string.Empty;
                char[] charsLine = lines[i].ToCharArray();


                for (int iChar = 0; iChar < charsLine.Length; iChar++)
                {
                    if (char.IsNumber(charsLine[iChar]) && (iChar - 1) >= 0 && !char.IsNumber(charsLine[iChar - 1]))
                    {
                        daysTemp += charsLine[iChar];
                        if ((iChar + 1) <= charsLine.Length && char.IsNumber(charsLine[iChar + 1]))
                            daysTemp += charsLine[iChar + 1];
                    }

                    if (!string.IsNullOrEmpty(daysTemp))
                    {
                        days.Add(new Tuple<int, int>(lines[i][0] == 'G' ? 2 : 1, Convert.ToInt32(daysTemp)));
                        daysTemp = string.Empty;
                    }
                }
            }

            var a = days.GroupBy(i => i.Item2).Select(p => new Tuple<int, int>(p.Key, p.Sum(p2 => p2.Item1))).ToList();

            var bigestWeighDays = a.Where(p => p.Item2 == a.Max(i => i.Item2)).Select(i => i.Item1);

            if (bigestWeighDays.Count() == 1 && (bigestWeighDays.FirstOrDefault() == 19 || bigestWeighDays.FirstOrDefault() == 20))
                return "Date";
            else
                return "No Date";

        }

        public static void BubbleSort(int[] A, int n)
        {
            int temp;
            for (int k = 0; k < n - 1; k++)
            {
                // (n-k-1) is for ignoring comparisons of elements which have already been compared in earlier iterations

                for (int i = 0; i < n - k - 1; i++)
                {
                    if (A[i] > A[i + 1])
                    {
                        // here swapping of positions is being done.
                        temp = A[i];
                        A[i] = A[i + 1];
                        A[i + 1] = temp;
                    }
                }
            }
        }
    }
}
