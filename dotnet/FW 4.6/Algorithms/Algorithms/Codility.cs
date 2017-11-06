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
    public class SolutionBestArrayDivision
    {

        public int solution(int[] A)
        {
            int? biggest = null;

            for (int i = 0; i < A.Length; i++)
            {
                for (int i2 = 1; i2 < A.Length - 1; i2++)
                {
                    int sub = 0;
                    if (A[i] > A[i2])
                        sub = A[i] - A[i2];
                    else
                        sub = A[i2] - A[i];

                    if (biggest == null)                    
                        biggest = sub;                 

                    if (sub > biggest)
                        biggest = sub;
                }

            }
            return biggest != null ? biggest.Value : 0;
        }

        public int solutionB(int[] A)
        {
            int? biggest = null;

            for (int i = 0; i < A.Length; i++)
            {
                for (int i2 = 1; i2 < A.Length - 1; i2++)
                {
                    int sub = 0;
                 
                        sub = A[i] + A[i2];                  

                    if (biggest == null)
                        biggest = sub;

                    if (sub > biggest)
                        biggest = sub;
                }

            }
            return biggest != null ? biggest.Value : 0;
        }
    }
    public class SolutionParking
    {
        public int solution(string E, string L)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            const int entranceFee = 2;
            const int firstHourToSubtract = 1;
            const int firstHourCost = 3;
            const int normalHourCost = 4;

            TimeSpan timeEntered = TimeSpan.Parse(E);
            TimeSpan timeLeft = TimeSpan.Parse(L);

            TimeSpan parkedTime = timeLeft.Subtract(timeEntered);

            int realTimeInHours = (int)parkedTime.TotalHours - firstHourToSubtract;

            if (parkedTime.TotalMinutes % 60 > 0)
            {
                realTimeInHours = realTimeInHours + 1;//Minutes will be taxes as One hour
            }

            return entranceFee + firstHourCost + (realTimeInHours * normalHourCost);



        }
    }
    /// <summary>
    /// https://codility.com/demo/
    /// </summary>
    public class SolutionSample
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

            if (A[size - 1] < 0)//check if ther is negative number after distinct
            {
                return 1;
            }
            for (int i = 0; i < size; i++)
            {
                if (A[i] != i + 1)//missing order
                {
                    return i + 1;//return real count
                }
                else if (i == size - 1)
                {
                    return i + 2;//return real count + next order
                }
            }
            return 1;
            // write your code in C# 6.0 with .NET 4.5 (Mono)

        }
    }
}
