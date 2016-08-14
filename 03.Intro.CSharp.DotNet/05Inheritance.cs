using System;
using NUnit.Framework;

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

    namespace Polymorphism
    {
        class Example
        {
            class Car {
                public virtual string Fuel {
                    get { return "gasoline"; }
                }
            }

            class ElectricCar : Car {
                public sealed override string Fuel {
                    get { return "electricity"; }
                }
            }

            class Tesla : ElectricCar {
                // Error: cannot override sealed method
                //public override string Fuel { get { return "Musk"; } }

                // ... but we can explicitly shadow it
                public new string Fuel {
                    get { return "Musk"; }
                }
            }

            public void Use() {
                Tesla tesla = new Tesla();
                Console.WriteLine(tesla.Fuel);  // Musk
                ElectricCar car = tesla;
                Console.WriteLine(car.Fuel);  // electricity 
            }
        }
    }
}
