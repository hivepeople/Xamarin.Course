namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Namespaces.Example
    {
        namespace Nested  // could simply have used Namespaces.Example.Nested above
        {
            public class Utilities
            {
                public static void Print(string message)
                {
                    System.Console.WriteLine(message);
                }
            }
        }
    }

    namespace Namespaces.Usage
    {
        using Namespaces.Example.Nested;

        class Greeter
        {
            static void Main()
            {
                Utilities.Print("Hi there!");
            }
        }
    }
}
