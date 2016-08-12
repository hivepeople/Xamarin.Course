namespace Xamarin.Course.Advanced.CSharp
{
    namespace LINQ.Use.MethodSyntax
    {
        using System;
        using System.Linq;

        public class DiceThrower
        {
            private readonly Random generator = new Random();

            public int RollAndCountSixes(int numberOfDice)
            {
                return Enumerable.Range(1, numberOfDice)
                    .Select(n => generator.Next(1, 7))  // <-- max val is exclusive
                    .Where(pips => pips == 6)
                    .Count();
            }
        }
    }

    namespace LINQ.Use.QuerySyntax
    {
        using System;
        using System.Linq;

        public class NumberStats
        {

            public static void PrintEvenNumbersSorted()
            {
                int[] numbers = { 22, 5, 2, 1, 19, 10 };

                var evenSorted = from n in numbers
                                 where n % 2 == 0
                                 orderby n
                                 select n;

                foreach (int n in evenSorted)
                {
                    Console.Write(n + " ");
                }
            }
        }
    }
}
