using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace BoxindandUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            boxingAndUnboxingTest();
            stopWatch.Stop();
            TimeSpan timeBoxing = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeBoxing.Hours, timeBoxing.Minutes, timeBoxing.Seconds,
                timeBoxing.Milliseconds / 10);
            Console.WriteLine("RunTime Boxing/Unboxing " + elapsedTime);

            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            genericsTest();
            stopWatch2.Stop();
            TimeSpan timeSpanGenerics = stopWatch2.Elapsed;

            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                timeSpanGenerics.Hours, timeSpanGenerics.Minutes, timeSpanGenerics.Seconds,
                timeSpanGenerics.Milliseconds / 10);

            Console.WriteLine("RunTime Generics " + elapsedTime2);
        }
        static void boxingAndUnboxingTest()
        {
            const int MaxRange = 300000000;
            var list = new ArrayList(); //List<object>();

            for (int i = 0; i < MaxRange; ++i)
            {
                list.Add(i);
                var result = (int)list[i]; // object
            }
        }

        static void genericsTest()
        {
            const int MaxRange = 300000000;
            var list = new List<int>();

            for (int i = 0; i < MaxRange; ++i)
            {
                list.Add(i);
                var result = list[i]; // Int32
            }
        }
    }
}
