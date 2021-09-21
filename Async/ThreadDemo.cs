using System;
using System.Threading;

namespace Async
{
    public static class ThreadDemo
    {
        public static void ThreadProc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
            }
        }

        public static void Run()
        {
            Console.WriteLine("Classic thread demo");

            var t = new Thread(new ThreadStart(ThreadProc));
            t.Start(); // this does NOT give the thread CPU time right away,
                       // for that the main thread needs to to be preempted or yield
                       
            Thread.Sleep(1); // make sure we discard our quantum

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("MainProc: {0}", i);
            }

            t.Join(); // wait until threadproc ends
            Console.WriteLine("END Classic thread demo");
        }
    }
}
