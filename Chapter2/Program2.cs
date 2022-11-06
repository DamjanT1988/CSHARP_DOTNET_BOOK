using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using static System.Formats.Asn1.AsnWriter;
using System.Text;
using static System.Console;


namespace Basics
{
    class Program2
    {
        static void Main(string[] args)
        {
            // declare some unused variables using types
            // in additional assemblies
            System.Data.DataSet ds;
            System.Net.Http.HttpClient client;

            Console.WriteLine("OK");

            // loop through the assemblies that this app references
            foreach (var r in Assembly.GetEntryAssembly()
            .GetReferencedAssemblies())
            {
                // load the assembly so we can read its details
                ////var a = Assembly.Load(new AssemblyName(r.FullName));
                // declare a variable to count the number of methods
                ////int methodCount = 0;
                // loop through all the types in the assembly
                ////foreach (var t in a.DefinedTypes)
                {
                    // add up the counts of methods
                    ////methodCount += t.GetMethods().Count();
                }
                // output the count of types and their methods
                ///Console.WriteLine(
                ///"{0:N0} types with {1:N0} methods in {2} assembly.",
                ////arg0: a.DefinedTypes.Count(),
                ////arg1: methodCount,
                ////arg2: r.Name);
            }


            //NAMING & ASSIGNING

            // let the heightInMetres variable become equal to the value 1.88
            double heightInMetres = 1.88;
            Console.WriteLine($"The variable {nameof(heightInMetres)} has the value {heightInMetres}.");


            //STORING TEXT

            char letter = 'A'; // assigning literal characters
            char digit = '1';
            char symbol = '$';
            ////char userChoice = GetKeystroke(); // assigning from a function

            string firstName = "Bob"; // assigning literal strings
            string lastName = "Smith";
            string phoneNumber = "(215) 555-4256";
            // assigning a string returned from a function call
            ////string address = GetAddressFromDatabase(id: 563);


            //VERBATIM STRINGS 40

            string fullNameWithTabSeparator = "Bob\tSmith";

            ////string filePath = "C:\televisions\sony\bravia.txt";

            string filePath = @"C:\televisions\sony\bravia.txt";

            /*
            To summarize:
            • Literal string: Characters enclosed in double-quote characters.They can use
            escape characters like \t for tab.
            • Verbatim string: A literal string prefixed with @ to disable escape characters
            so that a backslash is a backslash.
            • Interpolated string: A literal string prefixed with $ to enable embedded
            formatted variables.You will learn more about this later in this chapter.
            */


            //STORING NUMBERS 41

            // unsigned integer means positive whole number
            // including 0
            uint naturalNumber = 23;
            // integer means negative or positive whole number
            // including 0
            int integerNumber = -23;
            // float means single-precision floating point
            // F suffix makes it a float literal
            float realNumber = 2.3F;
            // double means double-precision floating point
            double anotherRealNumber = 2.3; // double literal


            //WHOLE NUMBERS 42

            // three variables that store the number 2 million
            int decimalNotation = 2_000_000;
            int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
            int hexadecimalNotation = 0x_001E_8480;

            // check the three variables have the same value
            // both statements output true
            Console.WriteLine($"{decimalNotation == binaryNotation}");
            Console.WriteLine($"{decimalNotation == hexadecimalNotation}");


            //REAL NUMBERS 43

            //NUMBER SIZES 44
            Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.");
            Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}.");
            Console.WriteLine($"decimal uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");


            //DOUBLE, DECIMAL TYPES 45
            Console.WriteLine("Using doubles:");
            double a = 0.1;
            double b = 0.2;
            if (a + b == 0.3)
            {
                Console.WriteLine($"{a} + {b} equals 0.3");
            }
            else
            {
                Console.WriteLine($"{a} + {b} does NOT equal 0.3");
            }


            Console.WriteLine("Using decimals:");
            decimal c = 0.1M; // M suffix means a decimal literal value
            decimal d = 0.2M;
            if (c + d == 0.3M)
            {
                Console.WriteLine($"{c} + {d} equals 0.3");
            }
            else
            {
                Console.WriteLine($"{c} + {d} does NOT equal 0.3");
            }


            //BOOLEANS 47

            //STORING ANY TYPE OBJECTS 48
            object height = 1.88; // storing a double in an object
            object name = "Amir"; // storing a string in an object
            Console.WriteLine($"{name} is {height} metres tall.");
            ////int length1 = name.Length; // gives compile error!
            int length2 = ((string)name).Length; // tell compiler it is a string 
            Console.WriteLine($"{name} has {length2} characters.");


            //DYNAMIC TTYPES 49
            // storing a string in a dynamic object
            dynamic anotherName = "Ahmed";

            // this compiles but would throw an exception at run-time
            // if you later store a data type that does not have a
            // property named Length
            int length = anotherName.Length;


            //DECLARING LOCAL VBARIABLES 50
            int population = 66_000_000; // 66 million in UK
            double weight = 1.88; // in kilograms
            decimal price = 4.99M; // in pounds sterling
            string fruit = "Apples"; // strings use double-quotes
            char letter2 = 'Z'; // chars use single-quotes
            bool happy = true; // Booleans have value of true or false

            // good use of var because it avoids the repeated type
            // as shown in the more verbose second statement
            ////var xml1 = new XmlDocument();
            ////XmlDocument xml2 = new XmlDocument();

            // bad use of var because we cannot tell the type, so we
            // should use a specific type declaration as shown in
            // the second statement
            ////var file1 = File.CreateText(@"C:\something.txt");
            ////StreamWriter file2 = File.CreateText(@"C:\something.txt");


            //DEFAULT VALUES 51
            Console.WriteLine($"default(int) = {default(int)}");
            Console.WriteLine($"default(bool) = {default(bool)}");
            Console.WriteLine($"default(DateTime) = {default(DateTime)}");
            Console.WriteLine($"default(string) = {default(string)}");


            //MULTIPLE VALUES 52
            string[] names; // can reference any array of strings
                            // allocating memory for four strings in an array
            names = new string[4];
            // storing items at index positions
            names[0] = "Kate";
            names[1] = "Jack";
            names[2] = "Rebecca";
            names[3] = "Tom";
            // looping through the names
            for (int i = 0; i < names.Length; i++)
            {
                // output the item at index position i
                Console.WriteLine(names[i]);
            }


            //NULL VALUES 53
            int thisCannotBeNull = 4;
            ////thisCannotBeNull = null; // compile error!
            int? thisCouldBeNull = null;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());
            thisCouldBeNull = 7;
            Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());


            //REFERENCE TYPES 54

            //CHECKING FOR NULL 57
            // check that the variable is not null before using it
            if (thisCouldBeNull != null)
            {
                // access a member of thisCouldBeNull
                ////int length = thisCouldBeNull.Length; // could throw exception
            }

            string authorName = null;
            // the following throws a NullReferenceException
            ////int x = authorName.Length;
            // instead of throwing an exception, null is assigned to y
            ////int? y = authorName?.Length;


            //DISPLAYING OUTPUT 59
            int numberOfApples = 12;
            decimal pricePerApple = 0.35M;

            Console.WriteLine(
            format: "{0} apples costs {1:C}",
            arg0: numberOfApples,
            arg1: pricePerApple * numberOfApples);

            string formatted = string.Format(
            format: "{0} apples costs {1:C}",
            arg0: numberOfApples,
            arg1: pricePerApple * numberOfApples);

            //WriteToFile(formatted); // writes the string into a file


            //...59
            Console.WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples:C}");


            //...60
            //{ index [, alignment ] [ : formatString ] }
            string applesText = "Apples";
            int applesCount = 1234;
            string bananasText = "Bananas";
            int bananasCount = 56789;

            Console.WriteLine(
            format: "{0,7} {1,-9:N0}",
            arg1: "Name",
            arg0: "Count");

            Console.WriteLine(
            format: "{0,7} {1,-9:N0}",
            arg1: applesText,
            arg0: applesCount);

            Console.WriteLine(
            format: "{0,7} {1,-9:N0}",
            arg1: bananasText,
            arg0: bananasCount);


            //...61
            Console.Write("Type your first name and press ENTER: ");
            ////string firstName1 = Console.ReadLine();
            Console.Write("Type your age and press ENTER: ");
            //// string age = Console.ReadLine();
            ////Console.WriteLine(
            ////$"Hello {firstName1}, you look good for {age}.");


            //...63
            Console.Write("Press any key combination: ");
            ////ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            ////Console.WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
            ////arg0: key.Key,
            ////arg1: key.KeyChar,
            ////arg2: key.Modifiers);


            //...63

            WriteLine($"There are {args.Length} arguments.");


            //...65
            if (args.Length < 4)
            {
                WriteLine("You must specify two colors and dimensions, e.g.");
                WriteLine("dotnet run red yellow 80 40");
                return; // stop running
            }

            ForegroundColor = (ConsoleColor)Enum.Parse(
            enumType: typeof(ConsoleColor), value: args[0],
            ignoreCase: true);
            
            BackgroundColor = (ConsoleColor)Enum.Parse(
            enumType: typeof(ConsoleColor),
            value: args[1],
            ignoreCase: true);
            
            WindowWidth = int.Parse(args[2]);
            WindowHeight = int.Parse(args[3]);
















        }
    }
}