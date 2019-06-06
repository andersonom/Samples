using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class CodilityAuthorityPartners
    {
        private static int result = 0;
        //TODO Fix from 3 to 5
        public static int GetStableCycleTimesOfParticles(int[] A)
        {
            //{ -1, 1, 3, 3, 3, 2, 3, 2, 1, 0 };    
            if (A.Length < 3)
                return result;

            var seq1 = A[1] - A[0];
            var seq2 = A[2] - A[1];

            if (seq1 == seq2)
                result++;

            result = GetStableCycleTimesOfParticles(A.Skip(2).ToArray());

            if (result == 1000000000)
                return -1;

            return result;
        }
        //TODO Fix 
        public static int RepetitionPeriod(int n)
        {
            int[] d = new int[30];
            int l = 0;
            int p;
            while (n > 0)
            {
                d[l] = n % 2;
                n /= 2;
                l++;
            }
            for (p = 1; p < 1 + l; ++p)
            {
                int i;
                bool ok = true;
                for (i = 0; i < l - p; ++i)
                {
                    if (d[i] != d[i + p])
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    return p;
                }
            }
            return -1;
        }

        public static int GetMinimalWinter(int[] A)
        {   //Fix
            //new int[] { -5, -5, -5, -42, 6, 12 }
            int result = 0;

            Array.Sort(A);

            int halfLength = A.Length % 2 == 0 ? A.Length / 2 : (A.Length + 1) / 2;

            for (int i = 0; i < halfLength; i++)
            {
                if (A[i] < A[A.Length -1])
                    result++;
            }

            if (result == 1000000000)
                return -1;

            return result;
        }

    }


}
