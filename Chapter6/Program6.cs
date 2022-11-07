using PacktLibrary;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using static System.Formats.Asn1.AsnWriter;
using System.Text;
using static System.Console;
using System.Linq.Expressions;
using Packt.Shared;

//--KAPITEL 6 - IMPLEMENTING INTERFACES AND INHERITING CLASSES 179
/*
 This chapter is about deriving new types from existing ones using object-oriented
programming (OOP). You will learn about defining operators and local functions for
performing simple actions, delegates and events for exchanging messages between
types, implementing interfaces for common functionality, generics, the difference
between reference and value types, inheriting from a base class to create a derived
class to reuse functionality, overriding a type member, using polymorphism, creating
extension methods, and casting between classes in an inheritance hierarchy.
This chapter covers the following topics:
• Setting up a class library and console application
• Simplifying methods
• Raising and handling events
• Implementing interfaces
• Making types more reusable with generics
• Managing memory with reference and value types
• Inheriting from classes
• Casting within inheritance hierarchies
• Inheriting and extending .NET types
 */

namespace Basics
{
    class Program6
    {
        static void Main(string[] args)
        {
            //---SIMPLYFYING METHODS 181

            //implementing functionality using methods 182
            var damjan = new Person { Name = "Damjan" };
            var angelina = new Person { Name = "Angelina" };
            var jill = new Person { Name = "Jill" };

            // call instance method
            var baby1 = angelina.ProcreateWith(damjan);

            // call static method
            var baby2 = Person.Procreate(damjan, jill);

            WriteLine($"{damjan.Name} has {damjan.Children.Count} children.");
            WriteLine($"{angelina.Name} has {angelina.Children.Count} children.");
            WriteLine($"{jill.Name} has {jill.Children.Count} children.");
            WriteLine(
            format: "{0}'s first child is named \"{1}\".",
            arg0: damjan.Name,
            arg1: damjan.Children[0].Name);


            //implementing functionality using operators 184
            string s1 = "Hello ";
            string s2 = "World!";
            string s3 = string.Concat(s1, s2);
            WriteLine(s3); // => Hello World!

            string s1a = "Hello ";
            string s2a = "World!";
            string s3a = s1a + s2a;
            WriteLine(s3a); // => Hello World!

            // call static method
            //var baby2 = Person.Procreate(damjan, angelina);

            // call an operator
            var baby3 = damjan * angelina;


            //implementing functionality using local functions 185
            WriteLine($"5! is {Person.Factorial(5)}");


            //--RAISING AND HANDLING EVENTS 186
            /*
            Methods are often described as actions that an object can perform, either on itself or to
            related objects. For example, List can add an item to itself or clear itself, and File can
            create or delete a file in the filesystem.
            
            Events are often described as actions that happen to an object. For example, in a
            user interface, Button has a Click event, click being something that happens to a
            button. Another way of thinking of events is that they provide a way of exchanging
            messages between two objects.

            Events are built on delegates, so let's start by having a look at how delegates work.
             */


            //calling methods using delegates 186
            /*
            The other way to call or execute a method is to use a delegate. If you have used
            languages that support function pointers, then think of a delegate as being a typesafe
            method pointer. In other words, a delegate contains the memory address of a
            method that matches the same signature as the delegate so that it can be called safely
            with the correct parameter types
             */

            // create a delegate instance that points to the method
            //var d = new DelegateWithMatchingSignature(p1m.MethodIWantToCall);
            // call the delegate, which calls the method
            //int answer2 = d("Frog");


            //defining and handling delegates 188
            /*
            predfined delegates:
            
            public delegate void EventHandler(
            object sender, EventArgs e);
            
            public delegate void EventHandler<TEventArgs>(
            object sender, TEventArgs e);
             */

            damjan.Shout = Damjan_Shout; //1- start listen

            damjan.Poke();
            damjan.Poke();
            damjan.Poke();
            damjan.Poke();

            /*
            You've now seen how delegates implement the most important functionality of
            events: the ability to define a signature for a method that can be implemented by
            a completely different piece of code, and then call that method and any others that
            are hooked up to the delegate field.
             */


            //defining and handling events 190
            //public event EventHandler Shout;


            //--IMPLEMENTING INTERFACES 191

            //comparing objects when sorting 192
            Person[] people =
            {
            new Person { Name = "Simon" },
            new Person { Name = "Jenny" },
            new Person { Name = "Adam" },
            new Person { Name = "Richard" }
            };

            WriteLine("Initial list of people:");
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            WriteLine("Use Person's IComparable implementation to sort: ");
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }


            //comparing objects using a separate class 194
            WriteLine("Use PersonComparer's IComparer implementation to sort: ");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }


            //defining interfaces with default implementations 195


            //making types safely reusable with generics 198
            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer: {t1.Process(42)}");

            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string: {t2.Process("apple")}");


            //working with generic types 199
            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer:{gt1.Process(42)}");

            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string:{gt2.Process("apple")}");

            /*
            °° When instantiating an instance of a generic type, the developer
            must pass a type parameter. In this example, we pass int as the
            type parameter for gt1 and string as the type parameter for gt2,
            so wherever T appears in the GenericThing class, it is replaced with
            int and string.
            °° When setting the Data field and passing the input parameter, the
            compiler enforces the use of an int value, such as 42, for the gt1
            variable, and a string value, such as "apples", for the gt2 variable.
             */


            //working with generics method 201
            string number1 = "4";
            WriteLine("{0} squared is {1}",
            arg0: number1,
            arg1: Squarer.Square<string>(number1));

            byte number2 = 3;
            WriteLine("{0} squared is {1}",
            arg0: number2,
            arg1: Squarer.Square(number2));


            //managing memory with reference and value types 202
            /*
            • Numbers: byte, sbyte, short, ushort, int, uint, long, ulong, float,
            double, and decimal
            • Miscellaneous: char and bool
            • System.Drawing: Color, Point, and Rectangle
             */


            //working with struct types 203
            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");


            //releasing unmanaged resources 205-animal.cs
            /*
            In the previous chapter, we saw that constructors can be used to initialize fields and
            that a type may have multiple constructors. Imagine that a constructor allocates an
            unmanaged resource; that is, anything that is not controlled by .NET, such as a file or
            mutex under the control of the operating system. The unmanaged resource must be
            manually released because .NET cannot do it for us.
             */


            //ensuring that Dispose is called 207
            using (Animal a = new Animal())
            {
                // code that uses the Animal instance
            }


            //inheriting from class 207-employee.cs
            Employee john = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.WriteToConsole();


            //expanding classes 208
            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014, 11, 23);
            WriteLine($"{john.Name} was hired on {john.HireDate:dd / MM / yy}");


            //hiding members 209--


            //overriding members 210
            WriteLine(john.ToString());


            //preventing inheritence and overriding 211-person.cs


            //understanding polymorphism 212
            /*
            You have now seen two ways to change the behavior of an inherited method. We can
            hide it using the new keyword (known as non-polymorphic inheritance), or we can
            override it (known as polymorphic inheritance).
            
            Both ways can access members of the base class by using the base keyword, so what
            is the difference?
            
            It all depends on the type of the variable holding a reference to the object.
             */

            Employee aliceInEmployee = new Employee
            { Name = "Alice", EmployeeCode = "AA123" };
            
            Person aliceInPerson = aliceInEmployee;
            
            aliceInEmployee.WriteToConsole();

            aliceInPerson.WriteToConsole();

            WriteLine(aliceInEmployee.ToString());
            
            WriteLine(aliceInPerson.ToString());


            //casting within inheritance hierarchies 213

            //explicit casting 214
            //Employee explicitAlice = (Employee)aliceInPerson;//(Employee) is added for casting


            //avoiding casting exceptions 214
            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
                Employee explicitAlice = (Employee)aliceInPerson;
                // safely do something with explicitAlice
            }

            Employee aliceAsEmployee = aliceInPerson as Employee;
            if (aliceAsEmployee != null)
            {
                WriteLine($"{nameof(aliceInPerson)} AS an Employee");
                // do something with aliceAsEmployee
            }


            //--INHERTING AND EXTENDING .NET TYPES 215
            /*
            .NET has prebuilt class libraries containing hundreds of thousands of types. Rather
            than creating your own completely new types, you can often get a head start by
            deriving from one of Microsoft's types to inherit some or all of its behavior and then
            overriding or extending it.
             */

            //inheriting exceptions 216-personexception.cs
            try
            {
                john.TimeTravel(new DateTime(1999, 12, 31));
                john.TimeTravel(new DateTime(1950, 12, 25));
            }
            catch (PersonException ex)
            {
                WriteLine(ex.Message);
            }


            //EXTENDING TYPES WHEN YOU CAN'T INHERIT 217
            /*
            Earlier, we saw how the sealed modifier can be used to prevent inheritance.
            Microsoft has applied the sealed keyword to the System.String class so that no
            one can inherit and potentially break the behavior of strings.
            Can we still add new methods to strings? Yes, if we use a language feature named
            extension methods, which was introduced with C# 3.0.
             */

            //using static methods to reuse functionality 217
            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";
            
            WriteLine(
            "{0} is a valid e-mail address: {1}",
            arg0: email1,
            arg1: StringExtensions.IsValidEmail(email1));
            
            WriteLine(
            "{0} is a valid e-mail address: {1}",
            arg0: email2,
            arg1: StringExtensions.IsValidEmail(email2));


            //using extension methods to reuse functionality 219
            WriteLine(
            "{0} is a valid e-mail address: {1}",
            arg0: email1,
            arg1: email1.IsValidEmail());

            WriteLine(
            "{0} is a valid e-mail address: {1}",
            arg0: email2,
            arg1: email2.IsValidEmail());

            /*
            Extension methods cannot replace or override existing instance methods, so you
            cannot, for example, redefine the Insert method. The extension method will appear
            as an overload in IntelliSense, but an instance method will be called in preference to
            an extension method with the same name and signature.
             */






























        }

        //188
        private static void Damjan_Shout(object sender, EventArgs e)//8-
    {
        Person p = (Person)sender;
        WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
    }
}
}