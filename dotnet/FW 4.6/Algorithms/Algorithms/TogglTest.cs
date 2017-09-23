using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class TogglTest
    {
        private static void ToggleInterview()
        {
            var ar = new[] { 1, 2 };
            var ar2 = ar.Select(x =>
            {
                Console.WriteLine("{0} * 2", x);
                return x * 2;
            });

            Console.WriteLine("Select finished");
            Console.WriteLine("Total: {0}", ar2.Sum());
        }
    }
}
