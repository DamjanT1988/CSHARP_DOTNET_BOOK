using Packt.Shared;
using System;
using static System.Console;
//155
using System.Collections.Generic;

namespace PacktLibrary
{
    public partial class Person : Object
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
        // constructors
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
        // methods
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



























    }
}