using System;
using System.Net;
using System.Threading;

namespace Async
{
    public class EventBasedAsynchronousPatternDemo
    {
        public static void Run()
        {
            Console.WriteLine("EAP demo");

            var wc = new WebClient();

            var completed = false;
            var result = String.Empty;

            wc.DownloadStringCompleted += (sender, args) =>
            {
                if (args.Error != null)
                {
                    Console.WriteLine(args.Error);
                    completed = true;
                    return;
                }
                result = args.Result;
                completed = true;
            };


            wc.DownloadStringAsync(new Uri("https://swapi.dev/api/people/1/"));


            while (!completed)
            {
                Console.WriteLine("Waiting for web request...");
                // Do something else
                Thread.SpinWait(100000);
            }

            Console.WriteLine(result);

            Console.WriteLine("END EAP demo");
        }
    }
}