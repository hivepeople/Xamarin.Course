using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Course.Advanced.CSharp
{
    namespace Interfaces
    {
        class Example
        {
            // Following interfaces taken from the BCL:

            //public interface IEnumerator
            //{
            //    bool MoveNext();
            //    Object Current { get; }
            //    void Reset();
            //}

            //public interface IEnumerable
            //{
            //    IEnumerator GetEnumerator();
            //}

            //public interface ICloneable
            //{
            //    Object Clone();
            //}

            public abstract class Expression
                : IEnumerable, ICloneable
            {
                public abstract double Evaluate();

                public abstract IEnumerator GetEnumerator();
                public abstract object Clone();
            }
        }
    }
}
