using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    public class TaskBasedAsynchronousPatternDemo
    {
        public static void TaskProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("TaskProc: {0}", i);
            }
        }

        public static void Run()
        {
            Console.WriteLine("TAP demo");

            var task = Task.Run(TaskProc);
            while (!task.IsCompleted)
            {
                Console.WriteLine("Waiting for Task");
                // Do something else
                Thread.SpinWait(100);
            }

            Console.WriteLine("Task completed");

            Console.WriteLine("END TAP demo");
        }
    }
}