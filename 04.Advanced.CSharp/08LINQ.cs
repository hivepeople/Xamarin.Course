namespace Xamarin.Course.Advanced.CSharp
{
    namespace LINQ.Use.MethodSyntax
    {
        using System;
        using System.Linq;

        public class DiceThrower {
            private readonly Random generator = new Random();

            public int RollAndCountSixes(int numberOfDice) {
                return Enumerable.Range(1, numberOfDice)
                    // max val is exclusive
                    .Select(n => generator.Next(1, 7))
                    .Where(pips => pips == 6)
                    .Count();
            }
        }

        public static class NumberStats {

            public static void PrintEvenNumbersSorted() {
                int[] numbers = { 22, 5, 2, 1, 19, 10 };

                var evenSorted = numbers
                    .Where(n => n % 2 == 0)
                    .OrderBy(n => n);

                foreach (int n in evenSorted)
                    Console.Write(n + " ");
            }
        }
    }

    namespace LINQ.Use.QuerySyntax
    {
        using System;
        using System.Linq;

        public class DiceThrower {
            private readonly Random generator = new Random();

            public int RollAndCountSixes(int dice) {
                var q = from n in Enumerable.Range(1, dice)
                        select generator.Next(1, 7) into pips
                        where pips == 6
                        select pips;
                return q.Count();
            }
        }

        public class NumberStats {

            public static void PrintEvenNumbersSorted() {
                int[] numbers = { 22, 5, 2, 1, 19, 10 };

                var evenSorted = from n in numbers
                                 where n % 2 == 0
                                 orderby n
                                 select n;

                foreach (int n in evenSorted)
                    Console.Write(n + " ");
            }
        }
    }

    namespace LINQ.Basic.Operations
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;

        public class Example
        {
            public void BasicOperations()
            {
                var names = new string[] { "Anders", "Jens" };

                var source = from name in names
                             select name;


                var filtered = 
                    from name in names
                    where name.Length < 5 || name.StartsWith("A")
                    select name;


                var ordered =
                    from name in names
                    orderby name descending
                    select name;


                var grouped =
                    from name in names
                    group name by name[0];

                foreach (var group in grouped)
                {
                    Console.WriteLine(group.Key + ":");
                    foreach (var name in group)
                    {
                        Console.WriteLine(name);
                    }
                }
            }

            public enum PetType { Fish, Bird }

            public class Pet
            {

                public string Name { get; }
                public PetType Type { get; }

                public Pet(string name, PetType type)
                {
                    this.Name = name;
                    this.Type = type;
                }
            }

            public class Person
            {
                public string Name { get; }
                public Pet Pet { get; }

                public Person(string name)
                {
                    this.Name = name;
                    this.Pet = null;
                }

                public Person(string name, Pet pet)
                {
                    this.Name = name;
                    this.Pet = pet;
                }
            }

            public void JoinAndProjection()
            {
                var pets = new Pet[]
                {
                    new Pet("Olaf Von Hertz", PetType.Fish),
                    new Pet("Lord Nelson", PetType.Bird)
                };

                var people = new Person[]
                {
                    new Person("Olaf Von Hertz"),
                    new Person("Jens Jensen")
                };

                var joined = from person in people
                             join pet in pets
                             on person.Name equals pet.Name
                             select new
                             {
                                 PersonName = person.Name,
                                 Pet = pet.Type
                             };

                foreach (var combination in joined)
                {
                    Console.Write(combination.PersonName);
                    Console.Write(" is named after a ");
                    Console.WriteLine(combination.Pet);
                }
            }

            public void DeferredExecution()
            {
                var query = Enumerable.Range(1, 1000);
                // not generated yet...
                query = query.Where(i => i > 100);
                // still not generated...
                query = query.Where(i => i % 2 == 0);
                // not generated here either
                query = query.OrderBy(i => i);
                // also not generated here...
                var query2 = query.Select(i => new Person("" + i));
                // also no people created yet...

                foreach (var person in query2)
                {
                    // BAM! Now LINQ need to generate and create
                    Console.WriteLine(person);
                }
                    
            }
        }
    }
}
