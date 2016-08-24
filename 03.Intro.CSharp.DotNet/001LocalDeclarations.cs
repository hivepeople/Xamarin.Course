using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Local.Declarations
    {
        class Example
        {
            public void DeclareThings()
            {
                // Constants must always have a value
                const int theAnswer = 42;
                const string yes = "Yes";

                // Error: only numbers, bools, strings and
                // null references allowed to be const
                //const Guid g = Guid.Empty;


                // Variables need not be initialized at declaration
                int index;

                // Can declare multiple variables of same type
                int hours = 8, minutes = 14;

                // References can be set to null (empty reference)
                string answer = null;

                // Invalid: cannot use variable index
                // before it has been assigned a value
                //int current = index;

                // Can assign value after declaration
                index = 1;

                // Now we can use it
                int current = index;
            }

            public int MyNum { get; }
        }
    }
}
