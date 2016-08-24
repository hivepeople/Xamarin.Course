using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Course.Advanced.CSharp
{
    namespace Enums
    {
        public enum Gender { Male, Female }

        public enum Vocation { Programmer, Tester, NotImportant }

        public class Person
        {
            private readonly string name;
            private readonly Gender gender;
            private readonly Vocation vocation;

            Person(string name, Gender gender, Vocation vocation)
            {
                this.name = name;
                this.gender = gender;
                this.vocation = vocation;
            }

            public void Greet()
            {
                Console.Write("Hello ");
                var honorific = (gender == Gender.Male) ?
                    "Mr. " : "Ms. ";
                Console.Write(honorific);
                if (vocation != Vocation.NotImportant)
                    Console.Write(vocation + " ");
                Console.WriteLine(name);
            }
        }
    }
}
