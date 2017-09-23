using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class TechGig
    {
        private static void TechGig12()
        {
            string firstInput = Console.ReadLine();
            int qutLines = int.Parse(firstInput.Substring(0, 1));
            int qutCols = int.Parse(firstInput.Substring(2, 1));

            int[,] arr1 = GenerateArrayTC12(qutLines, qutCols);

            string secondtInput = Console.ReadLine();
            int qutLines2 = int.Parse(secondtInput.Substring(0, 1));
            int qutCols2 = int.Parse(secondtInput.Substring(2, 1));

            int[,] arr2 = GenerateArrayTC12(qutLines, qutCols);

            int lineLenght = arr2.GetLength(0);
            int colsLenght = arr2.GetLength(1);

            int[,] arr3 = new int[lineLenght, colsLenght];

            for (int il = 0; il < lineLenght; il++)
            {
                for (int ic = 0; ic < colsLenght; ic++)
                {
                    arr3[il, ic] = arr1[il, ic] + arr2[il, ic];
                    Console.Write(arr3[il, ic]);
                    if (ic < colsLenght - 1)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static int[,] GenerateArrayTC12(int qutLines, int qutCols)
        {
            String[] lines = new string[qutLines];

            for (int i = 0; i < qutLines; i++)
            {
                lines[i] = Console.ReadLine();
            }

            int[,] array = new int[qutLines, qutCols];

            for (int il = 0; il < qutLines; il++)
            {
                int[] buffer = TechGig10(qutCols, lines[il]);

                for (int ic = 0; ic < qutCols; ic++)
                {
                    array[il, ic] = buffer[ic];
                }
            }

            return array;
        }

        private static void TechGig11()
        {

            string input = Console.ReadLine();
            int countUpper = 0;
            int countLow = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                    countUpper++;

                if (char.IsLower(input[i]))
                    countLow++;
            }

            Console.WriteLine(countUpper);
            Console.WriteLine(countLow);
        }

        private static int[] TechGig10(int qutCols, string line)
        {
            int[] arrayInt = new int[qutCols];

            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ')
                    count++;
            }

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    int y = i;
                    int z = i + 1;
                    if (z <= line.Length - 1 && line[z] != ' ')
                    {
                        while (z <= line.Length - 1 && line[z] != ' ')
                        {
                            i++;
                            z++;
                        }
                    }
                    int x = 0;
                    while (arrayInt[x] != 0)
                        x++;

                    if (y == i)
                    {
                        arrayInt[x] = int.Parse(line[i].ToString());
                    }
                    else
                    {
                        string result = string.Empty;
                        for (int i2 = y; i2 <= i; i2++)
                            result += line[i2];

                        arrayInt[x] = int.Parse(result);
                    }
                }
            }
            return arrayInt;
        }
    }
}
