using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class CodeBattle
    {
        /// <summary>
        /// Get the array list separated by space. At the end shows the biggest value
        /// </summary>
        private static void CodeBattle10_1()
        {
            String line = Console.ReadLine();
            int maxValue = 0;

            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ')
                {
                    count++;
                }
            }

            int[] array;
            if (line[line.Length - 1] == ' ')
                array = new int[count];

            else
                array = new int[count + 1];

            if (line.Length != 1)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ')
                    {
                        int y = i;
                        int z = i + 1;
                        if (line[z] != ' ')
                        {
                            while (z <= line.Length - 1 && line[z] != ' ')
                            {
                                i++;
                                z++;
                            }
                        }

                        int x = 0;
                        while (array[x] != 0)
                            x++;

                        if (y == i)
                        {
                            array[x] = int.Parse(line[i].ToString());
                        }
                        else
                        {
                            string result = string.Empty;
                            for (int i2 = y; i2 <= i; i2++)
                                result += line[i2];

                            array[x] = int.Parse(result);
                        }
                    }
                }
                maxValue = array.Max();
            }
            else
            {
                maxValue = int.Parse(line);
            }

            Console.WriteLine(maxValue);
        }

        /// <summary>
        /// First Line get the array size, second line get the array list separated by space. At the end shows the second biggest value
        /// </summary>
        private static void CodeBattle10()
        {
            int number = int.Parse(Console.ReadLine());
            int[] arrayInt = new int[number];

            String line = Console.ReadLine();

            int count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ')
                {
                    count++;
                }
            }

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    int y = i;
                    int z = i + 1;
                    if (z > line.Length - 1 || line[z] != ' ')
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
            Console.WriteLine(arrayInt.Where(i => i != arrayInt.Max()).Max());
        }


        private static bool CodeBattle9()
        {

            string stringValue = Console.ReadLine();
            int stringLenght = stringValue.Length;

            int count = 0;
            double totalSum = 0;
            while (count != stringLenght)
            {
                totalSum += Math.Pow(Double.Parse(stringValue[count].ToString()), Convert.ToDouble(stringLenght));
                count++;
            }

            if (totalSum == Double.Parse(stringValue))
                return true;
            else
                return false;
        }

        private static void CodeBattle8()
        {
            string number = Console.ReadLine();

            double buffer = 0;
            for (int i = 0; i < number.Length; i++)
            {
                buffer += Math.Pow(int.Parse(number[i].ToString()), 3);
            }

            if (buffer == int.Parse(number))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }

        //Primos
        private static void CodeBattle7()
        {
            int numberStart = int.Parse(Console.ReadLine());
            int numberFinal = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = numberStart; i <= numberFinal; i++)
            {
                bool isPrimo = false;

                if (i == 2) { isPrimo = true; }

                for (int i2 = 2; i2 < i; i2++)
                {
                    if (i % i2 != 0 && i2 != i) { isPrimo = true; }
                    else { isPrimo = false; break; }
                }
                if (isPrimo)
                {
                    Console.WriteLine(i);
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        //Numbers of digits of an in number
        private static void CodeBattle6()
        {
            int number = int.Parse(Console.ReadLine());

            int i = 0;
            while (number > 0)
            {
                number = number / 10;
                i++;
            }
            Console.WriteLine(i);

        }

        private static void CodeBattle5()
        {
            int number = int.Parse(Console.ReadLine());
            int result = 0;
            int i = 1;
            while (i < number)
            {
                if (result == 0)
                    result = i * (i + 1);
                else
                    result = result * (i + 1);

                i++;
            }

            Console.WriteLine(result);
        }

        private static void CodeBattle4()
        {
            int age = int.Parse(Console.ReadLine());

            if (age < 10)
                Console.WriteLine("I am happy as having no responsibilities.");
            else
            {
                if (age < 18)
                    Console.WriteLine("I am still happy but starts feeling pressure of life.");
                else
                    Console.WriteLine("I am very much happy as i handled the pressure very well.");
            }
        }


        private static void CodeBattle3()
        {
            double principal = double.Parse(Console.ReadLine());
            int interest = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToInt32((principal * interest * year) / 100));
        }

        private static void CodeBattle22()
        {
            int bufferInt = 0;
            float bufferFloat = 0;

            var buffer = Console.ReadLine();

            if (int.TryParse(buffer, out bufferInt))
            {
                Console.WriteLine("This input is of type Integer.");
            }
            else
            {
                if (float.TryParse(buffer, out bufferFloat))
                {
                    Console.WriteLine("This input is of type float.");
                }
                else
                {
                    if (!String.IsNullOrEmpty(buffer))
                        Console.WriteLine("This input is of type string.");
                    else
                        Console.WriteLine("This is something else.");

                }
            }
        }

        private static void CodeBattle21()
        {
            string buffer = Console.ReadLine();
            bool isNumber = false;
            bool isFloat = false;

            for (int i = 1; i < buffer.Length; i++)
            {
                if (char.IsLetter(buffer[i]))
                {
                    Console.WriteLine("The input is of type string");
                    return;
                }
                else
                {
                    if (char.IsNumber(buffer[i]) && !isFloat)
                    {
                        isNumber = true;
                    }
                    else
                    {
                        if (buffer[i] == '.' && !isFloat)
                        {
                            isFloat = true;
                            isNumber = false;
                        }
                        else
                        {
                            if (!isFloat && buffer[0] != '-')
                            {
                                Console.WriteLine("The is something else");
                                return;
                            }
                        }
                    }
                }
            }

            if (isNumber)
                Console.WriteLine("The input is of type Integer");

            if (isFloat)
                Console.WriteLine("The input is of type float");
        }
    }
}
