using System;
using System.Timers;

namespace timer
{
    class Program
    {
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
        }
        static void Main(string[] args)
        {
            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            myTimer.Interval = 500;
            myTimer.Enabled = true;

            Console.WriteLine("Press \'e\' to escape the sample.");
            while (Console.Read() != 'e') ;
        }
    }
}