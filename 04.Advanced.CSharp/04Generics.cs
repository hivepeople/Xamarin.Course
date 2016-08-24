using System;
using System.Collections.Generic;

namespace Xamarin.Course.Advanced.CSharp
{
    namespace Generics
    {
        class Example
        {
            private string RenderHtml() { return ""; }

            public void Use()
            {
                List<int> l = new List<int>();

                l.Add(4);  // ok: 4 is an int
                //l.Add("hej");  // error: "hej" is not an int
                int i = l[0];  // ok: all list items are ints

                Nullable<bool> v = true;  // ok: v holds a bool
                bool b = v.Value;  // ok: v holds a bool
                //v = 5;  // error: v can only hold bools and null

                Lazy<string> html = new Lazy<string>(RenderHtml);
                
                // Can access strongly-typed result of lazy init
                string result = html.Value;
            }
        }
    }
}
