using System;

namespace Xamarin.Course.Intro.CSharp.DotNet.InheritanceExercise
{
    public class Program
    {
        public static void Main()
        {
            // Create your expression here
            //Expression expr = ...;
            // Example:
            Expression expr = new PlusExpression(
                4.0.ToExpression(),
                new PlusExpression(
                    new ConstantExpression(1),
                    new ConstantExpression(2)));

            // We print the textual representation
            Console.Write(expr.ToString());

            Console.Write(" = ");

            // ... and then the result of evaluating
            Console.WriteLine(expr.Evaluate());

            Console.ReadKey();
        }
    }
}
