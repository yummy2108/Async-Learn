using System;
using System.Threading;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Starting in the Main Method");

            var t1 = new Thread(new ThreadStart(DoWork));
            t1.Start();

            var t2 = new Thread(new ThreadStart(DoWork));
            t2.Start();

            var t3 = new Thread(new ThreadStart(DoWork));
            t3.Start();

            Console.WriteLine("Ending of the Main Method");
        }

        private static void DoWork()
        {
            int x = 10;
            Console.WriteLine("Managed Thread ID : {0} says {1}", Thread.CurrentThread.ManagedThreadId, x);
        }
    }
}
