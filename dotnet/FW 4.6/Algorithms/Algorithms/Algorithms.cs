using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class Algorithms
    {
        /// <summary>
        /// 1
        /// </summary>
        /// <param name="numbers"></param>
        public static void IsEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 > 0)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }

        static String localtion;
        static DateTime time;      
        /// <summary>
        /// 2 - One might think that, since a DateTime variable can never be null(it is automatically initialized to Jan 1, 0001), the compiler would complain when a DateTime variable is compared to null.However, due to type coercion, the compiler does allow it, which can potentially lead to headfakes and pull -out-your - hair bugs.
        ///Specifically, the == operator will cast its operands to different allowable types in order to get a common type on both sides, which it can then compare.That is why something like this will give you the result you expect(as opposed to failing or behaving unexpectedly because the operands are of different types):
        ///double x = 5.0;
        ///int y = 5;
        ///Console.WriteLine(x == y);  // outputs true            
        ///However, this can sometimes result in unexpected behavior, as is the case with the comparison of a DateTime variable and null.In such a case, both the DateTime variable and the null literal can be cast to Nullable<DateTime>.Therefore it is legal to compare the two values, even though the result will always be false.
        /// </summary>
        private static void StringOrDateTimeDefaultValue()
        {
            Console.WriteLine(localtion ?? "localtion is null");
            Console.WriteLine(time == null ? "time is null" : time.ToString());

            if (time == null)//due to type coercion, the compiler does allow it
                Console.WriteLine("nerver true");
        }

        /// <summary>
        /// 3 - Since we don’t have access to the private radius field of the object Circle, we tell the object itself to calculate the circumference, by passing it the calculation function inline.
        /// </summary>
        private static void CalculateCircunferenceLength()
        {
            ////3
            Circle cls = new Circle();
            //Best solution - Using Lambda           
            Console.WriteLine(cls.CalculateCircumferenceLength(r => 2 * Math.PI * r));

            //Worst Solution - It works, but it is expecting a formula
            var raio = cls.CalculateCircumferenceLength(i => i);//Retrieve Radius Value
            var circunferencia = 2 * Math.PI * raio; //Formula of Circumference, not using func or lambda, it's only the matematic expression
            Console.WriteLine(circunferencia);

            //Other Solution - Using a Func
            Func<double, double> funcCalcCirc = MethodCalcCirc;
            Console.WriteLine(cls.CalculateCircumferenceLength(i => funcCalcCirc(i)));
        }
        public static double MethodCalcCirc(double raio)
        {
            return 2 * Math.PI * raio;
        }
        public sealed class Circle
        {
            private double radius = 2;

            public double CalculateCircumferenceLength(Func<double, double> op)
            {
                return op(radius);
            }
        } 

        private static string resultAsyncAwaitSleep;
        /// <summary>
        /// 4 - The answer to the first part of the question (i.e., the version of the code with await Task.Delay(5);) is that the program will just output a blank line (not “Hello world!”). This is because result will still be uninitialized when Console.WriteLine is called.
        ///Most procedural and object-oriented programmers expect a function to execute from beginning to end, or to a return statement, before returning to the calling function.This is not the case with C# async functions. They only execute up until the first await statement, then return to the caller. The function called by await (in this case Task.Delay) is executed asynchronously, and the line after the await statement isn’t signaled to execute until Task.Delay completes (in 5 milliseconds). However, within that time, control has already returned to the caller, which executes the Console.WriteLine statement on a string that hasn’t yet been initialized.
        ///Calling await Task.Delay(5) lets the current thread continue what it is doing, and if it’s done(pending any awaits), returns it to the thread pool.This is the primary benefit of the async/await mechanism. It allows the CLR to service more requests with less threads in the thread pool.
        ///Asynchronous programming has become a lot more common, with the prevalence of devices which perform over-the-network service requests or database requests for many activities. C# has some excellent programming constructs which greatly ease the task of programming asynchronous methods, and a programmer who is aware of them will produce better programs.
        ///With regard to the second part of the question, if await Task.Delay(5); was replaced with Thread.Sleep(5), the program would output Hello world!. An async method without at least one await statement in it operates just like a synchronous method; that is, it will execute from beginning to end, or until it encounters a return statement.Calling Thread.Sleep() simply blocks the currently running thread, so the Thread.Sleep(5) call just adds 5 milliseconds to the execution time of the SaySomething() method.        /// </summary>
        /// <returns></returns>
        static async Task<string> AsyncAwaitSleepExercise()
        {
            await Task.Delay(5);//Executa até aqui e continua a thread
            //System.Threading.Thread.Sleep(5000);//Pausa a thread
            resultAsyncAwaitSleep = "Hello world!";
            return "Something";
        }

        private static async Task TestingAsyncAwait()
        {
            string x = await AsyncAwaitSleepExercise();
            Console.WriteLine(x);
        }

        /// <summary>
        /// 5 -This program will output the number 10 ten times.
        ///Here’s why: The delegate is added in the for loop and “reference” (or perhaps “pointer” would be a better choice of words) to i is stored, 
        ///rather than the value itself.Therefore, after we exit the loop, the variable i has been set to 10, so by the time each delegate is invoked, the value passed to all of them is 10.
        /// </summary>
        private static void DelegateInsideForNotGood()
        {
            List<Printer> printers = new List<Printer>();
            for (int i = 0; i < 10; i++)
            {
                printers.Add(delegate { Console.WriteLine(i); });
            }

            foreach (var printer in printers)
            {
                printer();
            }
        }
        delegate void Printer();// Used by 5 Exercise

        /// <summary>
        /// 6 
        /// </summary>
        private static void TestBuilderExercise()
        {
            StringBuilder TestBuilder = new StringBuilder("Hello");
            TestBuilder.Remove(2, 3); // result - "He"
            Console.WriteLine(TestBuilder);
            TestBuilder.Insert(2, "lp"); // result - "Help"
            Console.WriteLine(TestBuilder);
            TestBuilder.Replace('l', 'a'); // result - "Heap"
            Console.WriteLine(TestBuilder);
        }


        //11 - Get a Sequence of numbers, separated by comma and return the biggest number
        private static void BiggestNumber()
        {
            Console.WriteLine("Digite uma sequencia de numeros, separados por virgula: ");
            string numeros = Console.ReadLine();

            char virgula = ',';
            int numeroAtual = 0;
            string numeroBuffer = string.Empty;
            int[] arrayNumeros = new int[numeros.Trim(virgula).Length];
            int qutVirgulas = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] != virgula)
                {
                    numeroBuffer += numeros[i].ToString();
                }
                else
                {
                    qutVirgulas++;
                    if (int.TryParse(numeroBuffer, out numeroAtual))
                    {
                        arrayNumeros[i - qutVirgulas] = numeroAtual;
                        numeroBuffer = string.Empty;
                    }
                    else
                    {
                        throw new Exception("Erro!");
                    }
                }
            }

            int maiorNumero = 0;
            for (int i = 0; i < arrayNumeros.Count(); i++)
            {
                if (arrayNumeros[i] > maiorNumero)
                    maiorNumero = arrayNumeros[i];
            }

            Console.WriteLine(maiorNumero.ToString());
            Console.ReadLine();
        }

        //12 - Invert a word letter order
        private static void InvertChars()
        {
            Console.WriteLine("Digite um nome: ");
            var palavra = Console.ReadLine();

            for (int i = palavra.Length - 1; i > -1; i--)
            {
                Console.Write(palavra[i].ToString());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 13 - Stack Example
        ///The Stack class is one of the many C# data structures that resembles an List. Like an List, 
        ///    a stack has an add and get method, with a slight difference in behavior.
        ///To add to a stack data structure, you need to use the Push call, 
        ///    which is the Add equivalent of an List.Retrieving a value is slightly different. 
        ///The stack has a Pop call, which returns and removes the last object added. 
        ///If you want to check the top value in a Stack, use the Peek call.
        ///The resulting behavior is what is called LIFO, which stands for Last-In-First-Out.
        ///This particular data structure is helpful when you need to retrace your steps so to speak.

        /// There are two formats to define a Stack in C#:
        ///Stack stack = new Stack();
        ///Stack<string> stack = new Stack<string>();
        ///The different between the data structures being that the simple Stack structure will work with Objects
        /// while the Stack<> one will accept only a specified object.
        /// </summary>
        private static void StackExample()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        /// <summary>
        ///14 - Queue Example 
        ///Another one of the many C# data structures is the Queue. A Queue is very similar to the Stack data structure with one major difference.
        ///Rather than follow a LIFO behavior, a Queue data structure goes by FIFO, which stands for First-In-First-Out.Whenever you submit an article 
        /// to be approved on a website for example, the site adds your submittion to a queue.That way the first objects added are the first ones to be processed.
        ///The Add call for a queue (or the Push version) is Enqueue:
        /// </summary>
        private static void QueueExample()
        {

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }

        static bool ok;
        static readonly object bloqueador = new object();
        /// <summary>
        /// 15 - Thread Safe
        /// </summary>
        public static void ThreadSafe()
        {
            lock (bloqueador)
            {
                if (!ok)
                {
                    Console.WriteLine("Test Line");
                    ok = true;
                }
            }
        }
        /// <summary>
        /// 15.1 Thread Non Safe, to be use with Join() method
        /// </summary>
        public static void ThreadNonSafe()
        {
            if (!ok)
            {
                Console.WriteLine("Test Line");
                ok = true;
            }
        }
    }
}

public sealed class ThreadSafeList<T>
{
    private List<T> m_list = new List<T>();
    private object m_lock = new object();

    public void Add(T value)
    {
        lock (m_lock)
        {
            m_list.Add(value);
        }
    }
    public bool TryRemove(T value)
    {
        lock (m_lock)
        {
            return m_list.Remove(value);
        }
    }
    public bool TryGet(int index, out T value)
    {
        lock (m_lock)
        {
            if (index < m_list.Count)
            {
                value = m_list[index];
                return true;
            }
            value = default(T);
            return false;
        }
    }
}
 
