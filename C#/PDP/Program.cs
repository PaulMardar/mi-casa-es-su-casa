using System.Collections.Generic;
namespace Lab4_ppd1
{
    public static class Program
    {
        private static readonly List<string> links = new List<string> {
            "https://www.google.com/",
            "https://cryptozombies.io/en/lesson/1/chapter/13"
        };

        public static void Main(string[] args)
        {
            //DirectCallbacks.run(links);
            TaskMechanism.run(links);
            //AsyncTaskMechanism.run(links);
        }
    }
}
