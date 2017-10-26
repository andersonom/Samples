using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LittleShino
    {//GetNumbersDivideBytwoNumbers
        public static void Shino()
        {
            /*Little Shino loves maths. Today her teacher gave her two integers. 
        Shino is now wondering how many integers can divide both the numbers. 
              She is busy with her assignments. Help her to solve the problem.*/

            string input = Console.ReadLine();// Read two integers

            #region Assign n1 and n2 variables
            char[] inputChars = input.ToCharArray();

            int spacePos = 0;

            for (int i = 0; i < inputChars.Length; i++)
            {
                if (inputChars[i].Equals(' '))
                    spacePos = i;
            }

            int n1 = int.Parse(input.Substring(0, spacePos));
            var n2 = int.Parse(input.Substring(spacePos + 1, input.Length - (spacePos + 1)));
            #endregion

            List<int> divNum1 = new List<int>();
            List<int> divNum2 = new List<int>();

            for (int i = 1; i <= n1; i++)
            {
                if (n1 % i == 0)//If can divide 
                {
                    divNum1.Add(i);//Add numbers that first number can be divide
                }
            }

            for (int i = 1; i <= n2; i++)
            {
                if (n2 % i == 0)// If can divide
                {
                    divNum2.Add(i);//Add numbers that second number can be divide
                }
            }
            List<int> result = new List<int>();



            foreach (var i1 in divNum1)
            {
                foreach (var i2 in divNum2)
                {
                    if (i2 == i1)
                        result.Add(i1);//Add number if it contains in both list
                }
            }

        }
    }
}
