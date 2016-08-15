using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Expression.Statements
    {
        class Example
        {
            public int Add(int x, int y)
            {
                return x + y;
            }

            public void F()
            {
                // Assignment
                int x = Add(1, 1);

                // Increment
                x++;

                // Decrement
                x--;

                // Method call
                Add(2, 3);

                // Instantiation
                new Example();

                // Error: only assignment, call, increment, decrement
                // and new object expressions can be used as statements
                //2 + 2;
            }
        }
    }
}
