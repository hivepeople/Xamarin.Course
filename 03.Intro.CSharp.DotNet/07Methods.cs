using System;
using System.Collections;
using System.Xml;
namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Methods
    {

    }

    namespace Parameters
    {
        public class Example
        {
            static int Add(int a, int b, params int[] rest)
            {
                int result = a + b;
                foreach (int i in rest)
                    result += i;
                return result;
            }

            // can take any number of extra arguments
            int ten = Add(1, 2, 3, 4);
            int four = Add(2, 2);  // ...including none

            static XmlReader Create(string uri,
                XmlReaderSettings settings = null,
                XmlParserContext context = null)
            {
                // Create has 12 overloads!
                return XmlReader.Create(
                    uri, settings, context);
            }

            XmlReader r1 = Create("http://ex.dk/xml");

            XmlReader r2 = Create("http://ex.dk/xml", new XmlReaderSettings { IgnoreWhitespace = true });

            XmlReader r3 = Create("http://ex.dk/xml", context: new XmlParserContext(null, null, null, XmlSpace.Preserve));
        }
    }
}
