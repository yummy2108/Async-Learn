using System;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Current Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            // DoWork();

            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork));

            Console.WriteLine("Is Background Thread? {0} ", Thread.CurrentThread.IsBackground);

            mre.WaitOne();
        }

        private static ManualResetEvent mre = new ManualResetEvent(false);

        private static void DoWork(object state)
        {
            Console.WriteLine("Current Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Is Background Thread? {0} ", Thread.CurrentThread.IsBackground);

            mre.Set();
        }

    }
}
