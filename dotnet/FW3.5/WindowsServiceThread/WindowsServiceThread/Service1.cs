using System;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using System.IO;

namespace WindowsServiceThread
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        readonly object locker = new object();
        TextWriter tw;

        public Service1() 
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 60000;            
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }

        private void ExecuteThreadsTest()
        {
            tw = new StreamWriter("text.txt");

            Method1();

            Thread t = new Thread(Method2);
            t.Start();

            Method3();

            t.Join();

            tw.Close();
            timer.Interval = 60000;

        }

        private void Method1()
        {
            int temp;
            String tempDate;
            for (int i = 0; i < 100; i++)
            {
                temp = i;
                tempDate = DateTime.Now.ToString();
                lock (locker)
                {
                    tw.WriteLine(String.Format("{0} Thread1, Method1, {1}", temp, tempDate));
                }
            }
        }

        private void Method2()
        {
            int temp;
            String tempDate;
            for (int i = 0; i < 1000; i++)
            {
                temp = i;
                tempDate = DateTime.Now.ToString();
                lock (locker)
                {
                    tw.WriteLine(String.Format("{0} Thread2, Method2, {1}", temp, tempDate));
                }
            }
        }

        private void Method3()
        {
            int temp;
            String tempDate;
            for (int i = 0; i < 1500; i++)
            {
                temp = i;
                tempDate = DateTime.Now.ToString();
                lock (locker)
                {
                    tw.WriteLine(String.Format("{0} Thread3, Method3, {1}", temp, tempDate));
                }
            }
        }

        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {          
            ExecuteThreadsTest();            
        }
    }
}
