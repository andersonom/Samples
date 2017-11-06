using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace StringBuilderPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string resultado = string.Empty;

            for (int i = 0; i < 20000; i++)
            {
                resultado +=  i;
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalSeconds.ToString() + resultado.Substring(0, 10));

            stopWatch.Reset();
            stopWatch.Start();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 20000; i++)
            {
                sb.Append(i);
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed.TotalSeconds.ToString() + sb.ToString().Substring(0, 10));
            Console.Read();

            
        }
    }
}
