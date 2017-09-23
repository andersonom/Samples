using System; 
using System.Text; 

namespace Algorithms
{
    public static class RDITest
    {
        /// <summary>
        /// 7 - RDI Test - 0, 1, 1, 2, 3, 5, 8, 13, 21, 34
        /// </summary>
        private static void First100FibonacciNumbers()
        {
            long num1 = 0; long num2 = 1;

            for (int i = 0; i <= 100; i = i + 2)//0 2 4
            {
                Console.Write(String.Format("{0}, ", num1));//0 1 3 8
                Console.Write(String.Format("{0}, ", num2));//1 2 5 13

                num1 += num2;
                num2 += num1;
            }
        }

        /// <summary>
        /// 8 - RDI Test
        /// </summary>
        private static string AllNumbersConcatString(int[] numbers)
        {

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (IsEven(i))
                {
                    result.Append(i);

                    if (Array.IndexOf(numbers, i) != numbers.Length - 1)
                        result.Append("|");
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// 9 - RDI Test
        /// </summary>
        private static bool IsEven(int number)
        {
            double buffer = (double)number / 2;
            //double buffer = ((double)number);
            //buffer /= 2;
            int result = 0;
            int.TryParse(buffer.ToString(), out result);
            return result != 0;
        }

        /// <summary>
        /// 10 - RDI Test
        /// </summary>
        private static int[] FirstTwoWhoseSumEqualsX(int[] array, int x)
        {
            for (int i = 0; i < array.Length; i++) //Varre o array, 1º For
            {
                for (int i2 = 0; i2 < array.Length; i2++)   // Varre o mesmo array, 2º For, com o primeiro item no ponteiro "array[i]", só que vamos continuar
                {                                           // varrendo todos os numeros no array do 2º For "array[i2, i2+1, i2 +3 ...]" até o final
                                                            // para que voltemos ao 2º item do 1º For "i+1" e ir comparando novamente com todos os numeros do 2º For
                                                            // sucessivamente até o ultimo numero do 1º For
                    if (array[i] != array[i2] && (array[i] + array[i2]) == x)
                    {
                        return new int[] { array[i], array[i2] };
                    }
                }
            }

            return null;
        }
    }
}
