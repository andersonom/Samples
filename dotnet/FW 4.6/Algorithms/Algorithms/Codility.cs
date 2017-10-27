using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Codility
    {
        public void Sample()
        {


        }
    }
    /// <summary>
    /// https://codility.com/demo/
    /// </summary>
    public class Solution
    {
        public int solution(int[] A)
        {
            Array.Sort(A);

            A = A.Distinct().ToArray();
            if (A.Last() < 0)
            {
                return 1;
            }
            for (int i = 1; i <= A.Count(); i++)
            {
                if (A[i - 1] != i)
                {
                    return i++;
                }
                else if (i == A.Count())
                {
                    return i + 1;
                }
            }
            return 1;
            // write your code in C# 6.0 with .NET 4.5 (Mono)
        }
        public int solution2(int[] A)
        {
            
            A = A.Distinct().ToArray();//todo use only algorit

            int size = A.Length;

            HackerRankSearchAlgorithms.BubbleSort(ref A, size);

            if (A[size-1] < 0)//check if ther is negative number after distinct
            {
                return 1;
            }
            for (int i = 0; i < size; i++)
            {
                if (A[i] != i+1)//missing order
                {
                    return i+1;//return real count
                }
                else if (i == size-1)
                {
                    return i+2;//return real count + next order
                }
            }
            return 1;
            // write your code in C# 6.0 with .NET 4.5 (Mono)

        }
    }
}
