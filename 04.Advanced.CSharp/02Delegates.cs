namespace Xamarin.Course.Advanced.CSharp
{
    namespace Delegates.Declaration
    {
        public delegate void Logger(string text);
    }

    namespace Predefined.System
    {
        public delegate bool Predicate<in T>(T obj);
        public delegate int Comparison<in T>(T x, T y);
    }

    namespace Delegates.Invocation
    {
        using Delegates.Declaration;

        public class Worker
        {
            public void DoWork(Logger log)
            {
                log("Starting work...");  // <-- syntactic sugar...
                // Do stuff here
                log.Invoke("Finished!");  // <-- ...for calling Invoke 
            }
        }
    }

    namespace Delegates.Using
    {
        using System;
        using Delegates.Declaration;
        using Delegates.Invocation;

        public class Coordinator
        {
            public static void CoordinateWork()
            {
                var worker = new Worker();
                worker.DoWork(Console.WriteLine);
            }
        }
    }
}
