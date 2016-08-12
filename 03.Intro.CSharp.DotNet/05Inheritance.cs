using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Course.Intro.CSharp.DotNet
{
    namespace Inheritance
    {
        class Example
        {
            abstract class Car {
                public abstract void Drive();
            }

            abstract class ElectricCar : Car {
                public override void Drive()
                {
                    // Send electricity to the engine
                }
            }

            sealed class Tesla : ElectricCar {
                public override void Drive()
                {
                    // Start logging road data

                    base.Drive();  // call ElectricCar.Drive
                }
            }


            // Error: cannot instantiate abstract class
            // ElectricCar car = new ElectricCar();

            // Error: cannot inherit from sealed class
            // class Copycat : Tesla { }
        }
    }
}
