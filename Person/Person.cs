using Packt.Shared;
using System;
using static System.Console;
//155
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace PacktLibrary
{
    public partial class Person : Object, IComparable<Person>//192
    {
        //--STORING DATA WITHIN FIELDS 150

        //FIELDS (properties)
        public string Name;
        public DateTime DateOfBirth;

        //153
        public WondersOfTheAncientWorld FavoriteAncientWonder;

        //154
        public WondersOfTheAncientWorld BucketList;

        //155
        public List<Person> Children = new List<Person>();

        //158
        // constants
        public const string Species = "Homo Sapien";

        //159
        // read-only fields
        public readonly string HomePlanet = "Earth";

        public readonly DateTime Instantiated;
        //CONSTRUCTORS
        public Person()
        {
            // set default values for fields
            // including read-only fields
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        //163
        //METHODS
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }
        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}.";
        }

        //163-164
        //complex types
        public class TextAndNumber
        {
            public string Text;
            public int Number;
        }
        public class Processor
        {
            public TextAndNumber GetTheData()
            {
                return new TextAndNumber
                {
                    Text = "What's the meaning of life?",
                    Number = 42
                };
            }
        }

        //tuples
        public (string, int) GetFruit()
        {
            return ("Apples", 5);
        }


        //165
        public (string Name, int Number) GetNamedFruit()
        {
            return (Name: "Apples", Number: 5);
        }

        //166-167
        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHelloTo(string name)
        {
            return $"{Name} says 'Hello {name}!'";
        }

        //168
        public string OptionalParameters(
            string command = "Run!",
            double number = 0.0,
            bool active = true)
        {
            return string.Format(
            format: "command is {0}, number is {1}, active is {2}",
            arg0: command, arg1: number, arg2: active);
        }

        //170
        public void PassingParameters(int x2, ref int y2, out int z2)
        {
            // out parameters cannot have a default
            // AND must be initialized inside the method
            z2 = 99;
            // increment each parameter
            x2++;
            y2++;
            z2++;
        }



        //182
        // static method to "multiply"
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }
        // instance method to "multiply"
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        /*
        °° In the static method named Procreate, the Person objects to
        procreate are passed as parameters named p1 and p2.
        °° A new Person class named baby is created with a name made of
        a combination of the two people who have procreated.
        °° The baby object is added to the Children collection of both parents
        and then returned. Classes are reference types, meaning a reference
        to the baby object stored in memory is added, not a clone of the baby.
        °° In the instance method named ProcreateWith, the Person object
        to procreate with is passed as a parameter named partner, and it,
        along with this, is passed to the static Procreate method to reuse
        the method implementation. this is a keyword that references the
        current instance of the class.
         */


        //184
        // operator to "multiply"
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }

        //185
        // method with a local function
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException(
                $"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);

            int localFactorial(int localNumber) // local function
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }

        //187
        //delegate int DelegateWithMatchingSignature(string s);

        //188
        /*
        °° It defines an EventHandler delegate field named Shout.
        °° It defines an int field to store AngerLevel.
        °° It defines a method named Poke.
        °° Each time a person is poked, their AngerLevel increments. Once
        their AngerLevel reaches three, they raise the Shout event, but only
        if there is at least one event delegate pointing at a method defined
        somewhere else in the code; that is, it is not null.
         */

        // event delegate field
        public EventHandler Shout;//2-
        // data field
        public int AngerLevel;//4-
        // method
        public void Poke()//3-
        {
            AngerLevel++;//5-
            if (AngerLevel >= 3)
            {
                // if something is listening...
                if (Shout != null)//6-
                {
                    // ...then call the delegate
                    Shout(this, EventArgs.Empty);//7-
                }
            }
        }

        //192
        public int CompareTo(Person? other)
        {
            return Name.CompareTo(other.Name);
        }

        //210
        // overridden methods
        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }

        public class Singer
        {
            // virtual allows this method to be overridden
            public virtual void Sing()
            {
                WriteLine("Singing...");
            }
        }
        public class LadyGaga : Singer
        {
            // sealed prevents overriding the method in subclasses
            public sealed override void Sing()
            {
                WriteLine("Singing with style...");
            }
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException("If you travel back in time to a date earlier than your own birth, then the universe will explode!");
            }
            else
            {
                WriteLine($"Welcome to {when:yyyy}!");
            }
        }






























    }
}