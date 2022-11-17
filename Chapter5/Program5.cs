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

//-----KAPITEL 5 - TYPES OBJECT-ORIENTED PROGRAMMING

/*
This chapter is about making your own types using object-oriented programming
(OOP). You will learn about all the different categories of members that a type can
have, including fields to store data and methods to perform actions. You will use
OOP concepts such as aggregation and encapsulation. You will also learn about
language features such as tuple syntax support, out variables, inferred tuple names,
and default literals.
This chapter will cover the following topics:
• Talking about OOP
• Building class libraries
• Storing data with fields
• Writing and calling methods
• Controlling access with properties and indexers

The concepts of object-oriented programming are briefly described here:

• Encapsulation is the combination of the data and actions that are related
to an object. For example, a BankAccount type might have data, such
as Balance and AccountName, as well as actions, such as Deposit and
Withdraw. When encapsulating, you often want to control what can access
those actions and the data, for example, restricting how the internal state
of an object can be accessed or modified from the outside.

• Composition is about what an object is made of. For example, a car is
composed of different parts, such as four wheels, several seats, and an
engine.

• Aggregation is about what can be combined with an object. For example,
a person is not part of a car object, but they could sit in the driver's seat and
then becomes the car's driver. Two separate objects that are aggregated
together to form a new component.

• Inheritance is about reusing code by having a subclass derive from a base
or super class. All functionality in the base class is inherited by and becomes
available in the derived class. For example, the base or super Exception class
has some members that have the same implementation across all exceptions,
and the sub or derived SqlException class inherits those members and has
extra members only relevant to when an SQL database exception occurs like
a property for the database connection.

• Abstraction is about capturing the core idea of an object and ignoring the
details or specifics. C# has an abstract keyword which formalizes the
concept. If a class is not explicitly abstract then it can be described as being
concrete. Base or super classes are often abstract, for example, the super class
Stream is abstract and its sub classes like FileStream and MemoryStream
are concrete. Abstraction is a tricky balance. If you make a class more
abstract, more classes would be able to inherit from it, but at the same time
there will be less functionality to share.

• Polymorphism is about allowing a derived class to override an inherited
action to provide custom behavior.

//--CLASS MEMBERS
FIELDS
Fields are used to store data. There are also three specialized categories
of field, as shown in the following bullets:

°° Constant: The data never changes. The compiler literally copies the
data into any code that reads it.

°° Read-only: The data cannot change after the class is instantiated, but
the data can be calculated or loaded from an external source at the
time of instantiation.

°° Event: The data references one or more methods that you want to
execute when something happens, such as clicking on a button, or
responding to a request from other code. Events will be covered in
Chapter 6, Implementing Interfaces and Inheriting Classes.

METHODS
Methods are used to execute statements. You saw some examples when
you learned about functions in Chapter 4, Writing, Debugging, and Testing
Functions. There are also four specialized categories of method:

°° Constructor: The statements execute when you use the new keyword
to allocate memory and instantiate a class.

°° Property: The statements execute when you get or set data. The
data is commonly stored in a field, but could be stored externally, or
calculated at runtime. Properties are the preferred way to encapsulate
fields unless the memory address of the field needs to be exposed.

°° Indexer: The statements execute when you get or set data using array
syntax [].

°° Operator: The statements execute when you use an operator like +
and / on operands of your type.
*/

namespace Basics
{
    class Program5
    {
        static void Main(string[] args)
        {
            //--INSTATIATING A CLASS
            //class "Person"->its namespace as reference from program & "using"
            //new person, initialize
            var bob = new Person();

            //setting/outputting field values 150
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);

            WriteLine(
            format: "{0} was born on {1:dddd, d MMMM yyyy}",
            //from class
            arg0: bob.Name,
            arg1: bob.DateOfBirth);



            //new person
            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };

            WriteLine(
            format: "{0} was born on {1:dd MMM yy}",
            arg0: alice.Name,
            arg1: alice.DateOfBirth);



            //.. enum.. 152-153
            bob.FavoriteAncientWonder =
            WondersOfTheAncientWorld.StatueOfZeusAtOlympia;//another file/namespace (not class) from class

            WriteLine(format:
            "{0}'s favorite wonder is {1}. Its integer is {2}.",
            arg0: bob.Name,
            arg1: bob.FavoriteAncientWonder,
            arg2: (int)bob.FavoriteAncientWonder);



            //multiple values enum.. 154
            bob.BucketList =
            WondersOfTheAncientWorld.HangingGardensOfBabylon |
            WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            // bob.BucketList = (WondersOfTheAncientWorld)18;
            
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");


            
            //storing multiple values using collections
            bob.Children.Add(new Person { Name = "Alfred" });
            bob.Children.Add(new Person { Name = "Zoe" });//using class fields for name
            
            WriteLine(
            $"{bob.Name} has {bob.Children.Count} children:");
            
            for (int i = 0; i < bob.Children.Count; i++)
            {
                WriteLine($" {bob.Children[i].Name}");
            }



            //field static 156
            BankAccount.InterestRate = 0.012M; // store a shared value

            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";//values stored in object, in the memory of it
            jonesAccount.Balance = 2400;

            WriteLine(format: "{0} earned {1:C} interest.",
            arg0: jonesAccount.AccountName,
            arg1: jonesAccount.Balance * BankAccount.InterestRate);//notice maths in arg..

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;

            WriteLine(format: "{0} earned {1:C} interest.",
            arg0: gerrierAccount.AccountName,
            arg1: gerrierAccount.Balance * BankAccount.InterestRate);


            
            //field constant 158
            //To get the value of a constant field, you must write the name of the class!!
            //not the name of an instance of the class.
            WriteLine($"{bob.Name} is a {Person.Species}");//not bob.Species!!!!



            //read-only field 159
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");//instance of class, is bob.



            //initializing fields with constructors 159
            var blankPerson = new Person();

            WriteLine(format:
            "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: blankPerson.Name,//in the constructor
            arg1: blankPerson.HomePlanet,//take from class fields
            arg2: blankPerson.Instantiated);//in the constructor

            var gunny = new Person("Gunny", "Mars");

            WriteLine(format:
            "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: gunny.Name,
            arg1: gunny.HomePlanet,
            arg2: gunny.Instantiated);//DateTime object "Instantiated" initiated
                                      //in Person class as readonly field

            
            //setting fields with default literals 161


            //--WRITING & CALLING METHODS 162
            /*
            Methods can return a single value or return nothing.
            • A method that performs some actions but does not return a value indicates
            this with the VOID TYPE before the name of the method.
            • A method that performs some actions and returns a value indicates this with
            the TYPE of the return VALUE before the name of the method. 
            */


            
            //... 163
            bob.WriteToConsole(); //method in the class - writes it

            WriteLine(bob.GetOrigin());//writes the other method



            //combining multiple returned values using tuples 163-164
            (string, int) fruit = bob.GetFruit();
            
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");



            //naming the fields of a tuple 165
            var fruitNamed = bob.GetNamedFruit();
            
            WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");



            //inferring tuple names 165
            var thing1 = ("Neville", 4);
            
            WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

            var thing2 = (bob.Name, bob.Children.Count);//object saved in the memory already
            
            WriteLine($"{thing2.Name} has {thing2.Count} children.");


            //deconstructing tuples 166
            // store return value in a tuple variable with two fields
            //(string name, int age) tupleWithNamedFields = GetPerson();
            // tupleWithNamedFields.name
            // tupleWithNamedFields.age
            // deconstruct return value into two separate variables
            //(string name, int age) = GetPerson();
            // name
            // age

            (string fruitName, int fruitNumber) = bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");


            
            //defining and passing parameters to methods 166-167
            WriteLine(bob.SayHello());
            WriteLine(bob.SayHelloTo("Emily"));//även SayHello funkar


            
            //overlaoding methods 167
            //WriteLine(bob.SayHello("Emily"));


            
            //passing optional parameters and naming arguments 168
            WriteLine(bob.OptionalParameters("jump", 99.5));

            WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));

            WriteLine(bob.OptionalParameters("Poke!", active: false));


            //controlling how parameters are passed 170
            /*
             When a parameter is passed into a method, it can be passed in one of three ways:
            • By value (this is the default): Think of these as being in-only.
            • By reference as a ref parameter: Think of these as being in-and-out.
            • As an out parameter: Think of these as being out-only

            When passing a variable as a parameter by default, its current value gets
            passed, not the variable itself. Therefore, x is a copy of the a variable. The
            a variable retains its original value of 10. When passing a variable as a ref
            parameter, a reference to the variable gets passed into the method.
            
            Therefore, y is a reference to b. The b variable gets incremented when the
            y parameter gets incremented. When passing a variable as an out parameter,
            a reference to the variable gets passed into the method.
            
            Therefore, z is a reference to c. The c variable gets replaced by whatever
            code executes inside the method. We could simplify the code in the Main
            method by not assigning the value 30 to the c variable, since it will always
            be replaced anyway.
             */

            int a6 = 10;
            int b6 = 20;
            int c6 = 30;

            WriteLine($"Before: a = {a6}, b = {b6}, c = {c6}");
            
            bob.PassingParameters(a6, ref b6, out c6);
            
            WriteLine($"After: a = {a6}, b = {b6}, c = {c6}");

            int d6 = 10;
            int e6 = 20;

            WriteLine(
            $"Before: d = {d6}, e = {e6}, f doesn't exist yet!");
            // simplified C# 7.0 syntax for the out parameter
            
            bob.PassingParameters(d6, ref e6, out int f6);
            
            WriteLine($"After: d = {d6}, e = {e6}, f = {f6}");


            
            //splitting classes using partial 171 -- part class of main/base/super Person class

            //173
            var sam = new Person
            {
                Name = "Sam",
                DateOfBirth = new DateTime(1972, 1, 27)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);



            //175
            sam.FavoriteIceCream = "Chocolate Fudge";

            WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");

            sam.FavoritePrimaryColor = "Red";

            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");



            //176
            sam.Children.Add(new Person { Name = "Charlie" });
            sam.Children.Add(new Person { Name = "Ella" });

            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[1].Name}");
            WriteLine($"Sam's first child is {sam[0].Name}");//indexers [] find it in partial class
            WriteLine($"Sam's second child is {sam[1].Name}");



        }
    }
}