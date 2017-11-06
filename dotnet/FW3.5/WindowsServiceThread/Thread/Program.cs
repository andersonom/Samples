using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace ThreadProgram
{
    class Program
    {
        //static bool done = false;
        //static readonly object locker = new object();

        static System.Timers.Timer timer = new System.Timers.Timer();

        static void Main(string[] args)
        {
            #region Commented Code
            ///****************************************************************
            // *  Thread Constructor accepts 2 type of contructors:
            // *  public delegate void ThreadStart();
            // *  public delegate void ParameterizedThreadStart (object obj);
            //****************************************************************/            
            //new Thread(Go).Start(" We pass a string to the object type parameter's method, but we need to convert it to String Inside the message");
            ///****************************************************************
            // *  Passing parameters when executing a thread
            //****************************************************************/ 
            //Thread t2 = new Thread(() => Go2("We use lambda to pass a parameter inside this delegate, this way it can accept any object type")); 
            //t2.Start();
            ///****************************************************************
            // *  Passing any code when executing a thread using lambda
            //****************************************************************/ 
            //new Thread(() =>
            //{
            //    Console.WriteLine("I'm running on another thread!");
            //    Console.WriteLine("This is so easy!");
            //}).Start();

            ///****************************************************************
            // *  Using timer from System.Thread
            //****************************************************************/ 
            //// First interval = 5000ms; subsequent intervals = 1000ms

            //Timer tmr = new Timer(Tick, "tick...", 5000, 1000);
            //Console.ReadLine();
            //tmr.Dispose();         // This both stops the timer and cleans up.

            ///****************************************************************
            // *  Using timer from System.Timer
            //****************************************************************/ 
            //System.Timers.Timer timer = new System.Timers.Timer();

            //timer.Interval = 500;

            //timer.Elapsed += new ElapsedEventHandler(TimerTest);
            //timer.Enabled = true;
            //Console.ReadLine(); 
            #endregion

           


        }

       

        #region Other Metods
        // Note that Go is now an instance method
        //static void Go(object test)
        //{
        //    lock (locker)
        //    {
        //        Console.WriteLine("Done" + test.ToString()); done = true;
        //    }
        //}
        //static void Go2(string test)
        //{
        //    lock (locker)
        //    {
        //        Console.WriteLine("Done" + test.ToString()); done = true;
        //    }
        //}

        //static void Tick(object data)
        //{
        //    // This runs on a pooled thread
        //    Console.WriteLine(data);          // Writes "tick..."
        //}

        //static void TimerTest(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Timer");
        //} 
        #endregion

    }

}
