using System;
namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Constructors
    {
        public class Example
        {
            public class Die
            {
                // No explicit constructors -> default added
                private int pips = new Random().Next(1, 7);
                public int GetRoll() { return pips; }
            }

            // Call the implicit constructor
            Die die = new Die();


            public class Shift
            {
                private DateTime start, end;

                public Shift(DateTime start, DateTime end)
                {
                    this.start = start;
                    this.end = end;
                }

                public Shift(DateTime start, TimeSpan len)
                    : this(start, start.Add(len)) { }
            }


            public abstract class Animal {
                private int numberOfLegs;

                protected Animal(int numberOfLegs) {
                    this.numberOfLegs = numberOfLegs;
                }
            }

            public class Millipede : Animal {
                public Millipede() : base(1000) { }
            }



            public class Point {
                private float x, y;

                private Point(float x, float y) {
                    this.x = x;
                    this.y = y;
                }

                public static Point At(float x, float y) {
                    return new Point(x, y);
                }
            }

            Point p = Point.At(0.0f, 0.0f);
        }
    }
}
