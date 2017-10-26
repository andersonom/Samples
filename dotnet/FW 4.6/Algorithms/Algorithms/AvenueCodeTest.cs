using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    using System;
    using System.Collections.Generic;


    public class Worker : IDisposable
    {
        private List<string> tasks = new List<string>();

        public int Id { get; private set; }

        public IEnumerable<string> Tasks { get { return this.tasks; } }

        public Worker(int id)
        {
            this.Id = id;
        }

        public void PerformTask(string task)
        {
            if (this.tasks == null)
                throw new ObjectDisposedException(this.GetType().Name);

            this.tasks.Add(task);
        }

        public void Dispose()
        {
            this.tasks = null;
        }
    }

    public class Dispatcher
    {
        private readonly Dictionary<int, Worker> workers = new Dictionary<int, Worker>();

        public IEnumerable<Worker> Workers { get { return this.workers.Values; } }

        public Worker AcquireWorker(int id)
        {
            Worker w = null;
            if (!this.workers.TryGetValue(id, out w))
            {
                w = new Worker(id);
                this.workers.Add(id, w);
            }

            return w;
        }

        public void ReleaseWorker(int id)
        {
            Worker w = null;
            if (!this.workers.TryGetValue(id, out w))
                throw new ArgumentException();
            else
                this.workers.Remove(id);


            w.Dispose();
        }

        //public static void Main(string[] args)
        //{
        //    var d = new Dispatcher();

        //    d.AcquireWorker(1).PerformTask("Task11");
        //    d.AcquireWorker(2).PerformTask("Task21");
        //    Console.WriteLine(string.Join(", ", d.AcquireWorker(2).Tasks));
        //    d.ReleaseWorker(2);
        //    d.AcquireWorker(1).PerformTask("Task12");
        //    Console.WriteLine(string.Join(", ", d.AcquireWorker(1).Tasks));
        //    d.ReleaseWorker(1);
        //}
    }
}
