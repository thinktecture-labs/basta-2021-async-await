using System;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ThreadDemo.Run();
            AsynchronousProgrammingModelDemo.Run();
            EventBasedAsynchronousPatternDemo.Run();
            TaskBasedAsynchronousPatternDemo.Run();

            var task = TaskStateMachineDemo.Run();
            while (!task.IsCompleted)
            {
                System.Threading.Thread.Sleep(10);
            }

            await Task.Delay(1);

            Console.WriteLine("Finished!");
            return 0;
        }
    }
}
