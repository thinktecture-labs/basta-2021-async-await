using System;
using System.Threading.Tasks;

namespace Async
{
    public class TaskStateMachineDemo
    {
        public static async Task Run()
        {
            Console.WriteLine("Task demo");

            await Task.Yield(); // make sure we run asynchronously

            await Task.Delay(TimeSpan.FromMilliseconds(50));
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Taskwork: {0}", i);
            }

            await Task.Delay(TimeSpan.FromMilliseconds(50));

            Console.WriteLine("End Task demo");
        }
    }
}
