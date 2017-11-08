using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming
{ 
    class Program
    {         static void Main(string[] args)
        {
            CreatingAndStartingNewTask();

            SettingTaskState();

            GettingTaskResult();

            CancellingTask();

            WaitingASingleTaskComplete();
            
            //AllTasks
            WaitingForTasksComplete(delegate (Task T1, Task T2) { WaitingActionForSeveralTasksComplete(T1, T2); });
            
            //AnyTask
            WaitingForTasksComplete(new Action<Task, Task>(WaitingActionForAnyTasksComplete));
            
            //AnyTask with func
            WaitingForTasksComplete((Task T1, Task T2) => { WaitingActionForAnyTasksComplete(T1, T2); });

            ExceptionHandlingInTasks();
        }

        private static void HelloConsole()
        {
            Console.WriteLine("Hello Task");
        }

        private static void HelloConsole(object message)
        {
            Console.WriteLine("Hello: {0}", message);
        }

        /// <summary>
        /// In the simplest scenarios to create and start a task,
        ///you just need to provide its body that represents the workload
        ///you want to run in parallel by passing in a System.Action delegate. 
        /// There are several ways to declare the task's body. 
        /// These are listed below and demonstrated in the first example:
        /// * Using Action delegate
        /// * Using anonymous function
        /// * Using lambda function
        /// </summary>
        private static void CreatingAndStartingNewTask()
        {
            //Action delegate  
            Task task1 = new Task(new Action(HelloConsole));

            //anonymous function  
            Task task2 = new Task(delegate
            {
                HelloConsole();
            });

            //lambda expression  
            Task task3 = new Task(() => HelloConsole());

            task1.Start();
            task2.Start();
            task3.Start();

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey(); 

            /* If you have some simple and short-living tasks, 
             * you can start them directly using the Task.Factory.StartNew() static method
             * without having to explicitly create the object. */
            Task.Factory.StartNew(() =>
            {
                HelloConsole();
            });
        }

        /// <summary>
        /// If you need to perform the same workload on a different set of data or just need to provide some parameter to the task, 
        ///you need to pass in a System.Action<object> and an object representing these data/ parameters.
        ///This process is very similar to supplying your console application with command line arguments.
        ///The following example shows this process by providing a simple string argument that will be printed to the console during the workload execution.
        /// </summary>
        private static void SettingTaskState()
        { 
            //Action delegate  
            Task task1 = new Task(new Action<object>(HelloConsole), "Task 1");

            //anonymous function  
            Task task2 = new Task(delegate (object obj)
            {
                HelloConsole(obj);
            }, "Task 2");

            //lambda expression  
            Task task3 = new Task((obj) => HelloConsole(obj), "Task 3");

            task1.Start();
            task2.Start();
            task3.Start();

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
        }

        private static void GettingTaskResult()
        {
            //creating the task  
            Task<int> task1 = new Task<int>(() =>
            {
                int result = 1;

                for (int i = 1; i < 10; i++)
                    result *= i;

                return result;
            });

            //starting the task  
            task1.Start();

            //waiting for result - printing to the console  
            Console.WriteLine("Task result: {0}", task1.Result);

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
        }

        /// <summary>
        /// *Calling the Cancel() method won't cancel the task immediately. 
        ///Therefore, in the body of a given task you need to monitor the token whether a cancellation was requested by checking the token's IsCancellationRequested property. 
        ///Once set to true, a cancellation was requested and you can cancel it either by calling "return" or throwing an OperationCanceledException.             
        /// </summary>
        private static void CancellingTask()
        { 
            //Creating the cancelation token  
            System.Threading.CancellationTokenSource cancellationTokenSource = new System.Threading.CancellationTokenSource();
            System.Threading.CancellationToken token = cancellationTokenSource.Token;

            //Creating the task  
            Task task = new Task(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cancel() called.");
                        return;
                    }

                    Console.WriteLine("Loop value {0}", i);
                }
            }, token);

            Console.WriteLine("Press any key to start task");
            Console.WriteLine("Press any key again to cancel the running task");
            Console.ReadKey();

            //Starting the task  
            task.Start();

            //Reading a console key  
            Console.ReadKey();

            //Canceling the task  
            Console.WriteLine("Canceling task");
            cancellationTokenSource.Cancel();

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
        }

        private static void WaitingASingleTaskComplete()
        {
            //Creating and starting a simple task  
            Task task = new Task(new Action(Workload));
            task.Start();

            //Waiting for the task  
            Console.WriteLine("Waiting for task to complete.");
            task.Wait();
            Console.WriteLine("Task Completed.");

            //Creating and starting another task             
            task = new Task(new Action(Workload));
            task.Start();
            Console.WriteLine("Waiting 2 secs for task to complete.");
            task.Wait(2000);
            Console.WriteLine("Wait ended - task completed.");

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
        }

        private static void Workload()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Task - iteration {0}", i);

                //Sleeping for 1 second  
                Thread.Sleep(1000);
            }
        }

        private static void WaitingActionForSeveralTasksComplete(Task task1, Task task2)
        {
            Task.WaitAll(task1, task2);
            Console.WriteLine("Tasks Completed.");
        }

        private static void WaitingActionForAnyTasksComplete(Task task1, Task task2)
        {
            int taskIndex = Task.WaitAny(task1, task2);
            Console.WriteLine("Task Completed - array index: {0}", taskIndex);
        }

        private static void WaitingForTasksComplete(Action<Task, Task> MyWaitAction)
        {
            //Creating the tasks  
            Task task1 = new Task(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Task 1 - iteration {0}", i);

                    //Sleeping for 1 second  
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Task 1 complete");
            });

            Task task2 = new Task(() =>
            {
                Console.WriteLine("Task 2 complete");
            });

            //Starting the tasks  
            task1.Start();
            task2.Start();

            //Waiting for both tasks to complete  
            Console.WriteLine("Waiting for tasks to complete.");

            MyWaitAction(task1, task2);

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
        }


        /// <summary>
        ///When an exception occurs within a task (and is not caught), it is not thrown immediately. Instead, it is squirreled away by the .Net framework and thrown 
        ///when some trigger member method is called, such as Task.Result, Task.Wait(), Task.WaitAll() or Task.WaitAny(). 
        ///In this case, an instance of System.AggregateException is thrown that acts as a wrapper around one or more exceptions that have occurred.
        ///This is important for methods that coordinate multiple tasks like Task.WaitAll() and Task.WaitAny(), so the AggregateException is able to wrap all the exceptions
        ///within the running tasks that have occurred.

        /// In the following example, we are creating and starting three tasks, two of which throw different exceptions. After starting these tasks, the main calling thread calls
        ///the WaitAll() method and catches the AggregateException. Finally, it iterates through the InnerExceptions property and prints out the details regarding the
        ///thrown exceptions. This property is the wrapper holding all the information about the aggregated exceptions. 
        /// </summary>
        private static void ExceptionHandlingInTasks()
        {
            //Creating the tasks  
            Task task1 = new Task(() =>
            {
                NullReferenceException exception = new NullReferenceException();
                exception.Source = "task1";
                throw exception;
            });

            Task task2 = new Task(() =>
            {
                throw new IndexOutOfRangeException();
            });

            Task task3 = new Task(() =>
            {
                Console.WriteLine("Task 3");
            });

            //Starting the tasks  
            task1.Start();
            task2.Start();
            task3.Start();

            //Waiting for all the tasks to complete              
            try
            {
                Task.WaitAll(task1, task2, task3);
            }
            catch (AggregateException ex)
            {
                //Enumerate the exceptions  
                foreach (Exception inner in ex.InnerExceptions)
                {
                    Console.WriteLine("Exception type {0} from {1}", inner.GetType(), inner.Source);
                }
            }

            Console.WriteLine("Main method complete. Press any key to finish.");
            Console.ReadKey();
        }

    }
}
