using System;
namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Properties
    {
        class Example
        {
            public class TimePeriod {
                private double seconds;

                public double Hours
                {
                    get { return seconds / 3600; }
                    set { seconds = value * 3600; }
                }
            }

            public void Use()
            {
                TimePeriod t = new TimePeriod();
                t.Hours = 24;  // 'set' accessor called

                // 'get' accessor called.
                Console.WriteLine("Hours: " + t.Hours);
            }

            public class TimePeriod2 {
                public double Seconds { get; set; }
                public double Hours
                {
                    get { return Seconds / 3600; }
                    set { Seconds = value * 3600; }
                }
            }
        }
    }
}
