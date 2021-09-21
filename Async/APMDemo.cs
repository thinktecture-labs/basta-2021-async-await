using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Async
{
    public class AsynchronousProgrammingModelDemo
    {
        public static void Run()
        {
            Console.WriteLine("APM demo");

            using (var fs = new FileStream("test.txt", FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None, 1024, true))
            {
                var data = Encoding.UTF8.GetBytes("Hello World!");

                var asyncResult = fs.BeginWrite(data, 0, data.Length, null, null);
                while (!asyncResult.IsCompleted)
                {
                    Console.WriteLine("APM waiting... ");
                    // Do something else
                    Thread.SpinWait(10000);
                }

                fs.EndWrite(asyncResult);

                Console.WriteLine("END APM demo");
            }
        }
    }
}