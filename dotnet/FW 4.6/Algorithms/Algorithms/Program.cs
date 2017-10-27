using System; 
using System.Threading;
 
namespace Algorithms
{
    class Program
    {
        static int number;
        public delegate void testeDelegate(int a);
        public event testeDelegate MeuEvento;

        static void Main(string[] args)
        {
            //1
            //Algorithms.IsEven(new int[] { 5, 10, 20, 33, 47, 54, 69, 73, 84, 96, 113 });

            ////9
            //Console.WriteLine(AllNumbersConcatString(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));

            ////10
            //var result = FirstTwoWhoseSumEqualsX(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 20);
            //if (result != null) { Console.WriteLine(result[0]); Console.WriteLine(result[1]); }

            //15
            //new Thread(Algorithms.ThreadSafe).Start();
            //OR
            //var thread = new Thread(ThreadNonSafe);
            //thread.Start();
            //thread.Join();

            //HackerRank.MonkWalks();

            //int[] a = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //int[] b = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };

            //int[] c = { 2, 3, 5, 6, 8, 9, 12, 13, 14 };

            //Console.WriteLine(BinarySearch(a, 3));

            //var ter = TernarySearch(c, 0, c.Length - 1, 13);
            //Console.WriteLine(ter);

            //var A = new int[] { 7, 4, 5, 2 };
            //HackerRankSearchAlgorithms.BubbleSort(ref A, A.Length);

            var solution = new Solution();
            var test = solution.solution2(new int[] { 1, 2, 3});
           var test2=  solution.solution2(new int[] { 1, 3, 6, 4, 1, 2 });
            Console.ReadKey();
        }

    }
}

