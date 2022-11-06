using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using static System.Formats.Asn1.AsnWriter;
using System.Text;
using static System.Console;
using System.Linq.Expressions;
using System.IO;
using static System.Convert;

//-----KAPITEL 3 - CONTROLLING FLOW AND CONVERTING TYPES
/*
This chapter covers the following topics:
• Operating on variables
• Understanding selection statements
• Understanding iteration statements
• Casting and converting between types
• Handling exceptions
• Checking for overflow
*/

namespace Basics
{
    class Program3
    {
        static void Main(string[] args)
        {

            //-----OPERATORS

            //operation variables 71
            int x = 5;
            int incrementedByOne = x++;
            int incrementedByOneAgain = ++x;
            Type theTypeOfAnInteger = typeof(int);
            int howManyBytesInAnInteger = sizeof(int);

            WriteLine("-------------------------------------------------------------------------------------------------");

            //unary operators 72
            int a1 = 3;
            int b1 = a1++;
            WriteLine($"a is {a1}, b is {b1}");

            int c = 3;
            int d = ++c; // increment c before assigning it
            WriteLine($"c is {c}, d is {d}");

            WriteLine("-------------------------------------------------------------------------------------------------");

            //binary arithmetic operators 73
            int e = 11;
            int f = 3;
            WriteLine($"e is {e}, f is {f}");
            WriteLine($"e + f = {e + f}");
            WriteLine($"e - f = {e - f}");
            WriteLine($"e * f = {e * f}");
            WriteLine($"e / f = {e / f}");
            WriteLine($"e % f = {e % f}");

            double g = 11.0;
            WriteLine($"g is {g:N1}, f is {f}");
            WriteLine($"g / f = {g / f}"); //return floating because double

            WriteLine("-------------------------------------------------------------------------------------------------");

            //assignment operators 74
            int p = 6;
            p += 3; // equivalent to p = p + 3;
            p -= 3; // equivalent to p = p - 3;
            p *= 3; // equivalent to p = p * 3;
            p /= 3; // equivalent to p = p / 3;

            WriteLine("-------------------------------------------------------------------------------------------------");

            //logical operators - boolean
            bool a = true;
            bool b = false;
            WriteLine($"AND | a | b ");
            WriteLine($"a | {a & a,-5} | {a & b,-5} ");
            WriteLine($"b | {b & a,-5} | {b & b,-5} ");
            WriteLine();
            WriteLine($"OR | a | b ");
            WriteLine($"a | {a | a,-5} | {a | b,-5} ");
            WriteLine($"b | {b | a,-5} | {b | b,-5} ");
            WriteLine();
            WriteLine($"XOR | a | b ");
            WriteLine($"a | {a ^ a,-5} | {a ^ b,-5} ");
            WriteLine($"b | {b ^ a,-5} | {b ^ b,-5} ");

            WriteLine("-------------------------------------------------------------------------------------------------");

            //2conditional logical operators 76
            WriteLine($"a & DoStuff() = {a & DoStuff()}");
            WriteLine($"b & DoStuff() = {b & DoStuff()}");

            WriteLine($"a && DoStuff() = {a && DoStuff()}");
            WriteLine($"b && DoStuff() = {b && DoStuff()}");//does not call function

            WriteLine("-------------------------------------------------------------------------------------------------");

            //bitwise and binary shift operators 77
            int a3 = 10; // 0000 1010
            int b3 = 6; // 0000 0110
            WriteLine($"a = {a3}");
            WriteLine($"b = {b3}");
            WriteLine($"a & b = {a3 & b3}"); // 2-bit column only
            WriteLine($"a | b = {a3 | b3}"); // 8, 4, and 2-bit columns
            WriteLine($"a ^ b = {a3 ^ b3}"); // 8 and 4-bit columns

            // 0101 0000 left-shift a by three bit columns
            WriteLine($"a << 3 = {a3 << 3}");
            // multiply a by 8
            WriteLine($"a * 8 = {a3 * 8}");
            // 0000 0011 right-shift b by one bit column
            WriteLine($"b >> 1 = {b3 >> 1}");

            WriteLine("-------------------------------------------------------------------------------------------------");

            //misc operators 79
            int age = 47;
            // How many operators in the following statement?
            string firstDigit = age.ToString();

            Console.WriteLine(firstDigit);
            // There are four operators:
            // = is the assignment operator
            // . is the member access operator
            // () is the invocation operator
            // [] is the indexer access operator

            WriteLine("-------------------------------------------------------------------------------------------------");

            //-----SELECTION STATEMENTS

            var expression1 = false;
            var expression2 = false;
            var expression3 = false;

            //if statement 79
            if (expression1)
            {
                // runs if expression1 is true
            }
            else if (expression2)
            {
                // runs if expression1 is false and expression2 if true
            }
            else if (expression3)
            {
                // runs if expression1 and expression2 are false
                // and expression3 is true
            }
            else
            {
                // runs if all expressions are false
                Console.WriteLine("Cool");
            }



            if (args.Length == 0)
            {
                WriteLine("There are no arguments.");
            }
            else
            {
                WriteLine("There is at least one argument.");
            }

            WriteLine("-------------------------------------------------------------------------------------------------");

            //pattern...81
            // add and remove the "" to change the behavior
            object o = 3;//""
            int j = 4;
            if (o is int i)
            {
                WriteLine($"{i} x {j} = {i * j}");
            }
            else
            {
                WriteLine("o is not an int so it cannot multiply!");
            }


            WriteLine("-------------------------------------------------------------------------------------------------");

        //switch... 82
        /*
         • The break keyword (like case 1 in the following code),
        • Or the goto case keywords (like case 2 in the following code),
        • Or they should have no statements (like case 3 in the following code).
        */

        A_label:
            var number = (new Random()).Next(1, 7);
            WriteLine($"My random number is {number}");

            switch (number)
            {
                case 1:
                    WriteLine("One");
                    break; // jumps to end of switch statement
                case 2:
                    WriteLine("Two");
                    goto case 1;
                case 3:
                case 4:
                    WriteLine("Three or four");
                    goto case 1;
                case 5:
                    // go to sleep for half a second
                    System.Threading.Thread.Sleep(500);
                    goto A_label;
                default:
                    WriteLine("Default");
                    break;
            } // end of switch statement

            WriteLine("-------------------------------------------------------------------------------------------------");

            //pattern match switch 84
            // string path = "/Users/markjprice/Code/Chapter03";
            string path = @"C:\kodprojekt\CSHARP_DOTNET_BOOK";
            Stream s = File.Open(
            Path.Combine(path, "file.txt"), FileMode.OpenOrCreate);
            string message = string.Empty;
            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    message = "The stream is a file that I can write to.";
                    break;
                case FileStream readOnlyFile:
                    message = "The stream is a read-only file.";
                    break;
                case MemoryStream ms:
                    message = "The stream is a memory address.";
                    break;
                default: // always evaluated last despite its current position
                    message = "The stream is some other type.";
                    break;
                case null:
                    message = "The stream is null.";
                    break;
            }
            WriteLine(message);

            WriteLine("-------------------------------------------------------------------------------------------------");

            //switch expressions 85
            message = s switch
            {
                FileStream writeableFile when s.CanWrite
                => "The stream is a file that I can write to.",
                FileStream readOnlyFile
                => "The stream is a read-only file.",
                MemoryStream ms
                => "The stream is a memory address.",
                null
                => "The stream is null.",
                _
                => "The stream is some other type."
            };
            WriteLine(message);

            WriteLine("-------------------------------------------------------------------------------------------------");

            //-----ITERATION STATEMENTS 86
            int x1 = 0;
            while (x1 < 10)
            {
                WriteLine(x1);
                x1++;
            }

            WriteLine("-------------------------------------------------------------------------------------------------");

            //while
            /*
            string password = string.Empty;
            var ok = 0;
            do
            {
                Write("Enter your password (three tries): ");
                password = ReadLine();
                ok++;
            }
            while (password != "Pa$$w0rd" && ok != 3);
            if (ok != 3)
            {
                WriteLine("Correct!");
            }
            else
            {
                WriteLine("Låst");
            }
            */

            //for
            /*
             • An initializer expression, which executes once at the start of the loop.
            • A conditional expression, which that executes on every iteration at the start
            of the loop to check whether the looping should continue.
            • An iterator expression, which that executes on every loop at the bottom of
            the statement.
            */

            for (int y = 1; y <= 10; y++)
            {
                WriteLine(y);
            }

            WriteLine("-------------------------------------------------------------------------------------------------");

            //foreach
            string[] names = { "Adam", "Barry", "Charlie" };
            foreach (string name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }

            /*
            1. The type must have a method named GetEnumerator that returns an object.
            2. The returned object must have a property named Current and a method
            named MoveNext.
            3. The MoveNext method must return true if there are more items to enumerate
            through or false if there are no more items.
            */

            WriteLine("-------------------------------------------------------------------------------------------------");

            //-----CASTING AND CONVERTING 89
            int a4 = 10;
            double b4 = a4; // an int can be safely cast into a double
            WriteLine(b4);

            double c4 = 9.8;
            int d4 = (int)c4; ////int added // compiler gives an error for this line
            WriteLine(d4);


            long e4 = 10;
            int f4 = (int)e4;
            WriteLine($"e is {e4:N0} and f is {f4:N0}");
            e4 = long.MaxValue;
            f4 = (int)e4;
            WriteLine($"e is {e4:N0} and f is {f4:N0}");

            WriteLine("-------------------------------------------------------------------------------------------------");

            //system.convert 92
            double g4 = 9.8;
            int h4 = ToInt32(g4);
            WriteLine($"g is {g4} and h is {h4}");

            WriteLine("-------------------------------------------------------------------------------------------------");

            //rounding numbers 92
            double[] doubles = new[]
            { 9.49, 9.5, 9.51, 10.49, 10.5, 10.51 };
            foreach (double n in doubles)
            {
                WriteLine($"ToInt({n}) is {ToInt32(n)}");
            }

            /*
            • It always rounds down if the decimal part is less than the midpoint .5.
            • It always rounds up if the decimal part is more than the midpoint .5.
            • It will round up if the decimal part is the midpoint .5 and the non-decimal
            part is odd, but it will round down if the non-decimal part is even.
            */

            foreach (double n in doubles)
            {
                WriteLine(format:
                "Math.Round({0}, 0, MidpointRounding.AwayFromZero) is {1}",
                arg0: n,
                arg1: Math.Round(value: n,
                digits: 0,
                mode: MidpointRounding.AwayFromZero));
            }

            WriteLine("-------------------------------------------------------------------------------------------------");

            //converting to string 94
            int number2 = 12;
            WriteLine(number2.ToString());
            bool boolean = true;
            WriteLine(boolean.ToString());
            DateTime now = DateTime.Now;
            WriteLine(now.ToString());
            object me = new object();
            WriteLine(me.ToString());

            WriteLine("-------------------------------------------------------------------------------------------------");

            //binary to string 95
            // allocate array of 128 bytes
            byte[] binaryObject = new byte[128];
            // populate array with random bytes
            (new Random()).NextBytes(binaryObject);
            WriteLine("Binary Object as bytes:");
            for (int index = 0; index < binaryObject.Length; index++)
            {
                Write($"{binaryObject[index]:X} ");
            }
            WriteLine();
            // convert to Base64 string and output as text
            string encoded = Convert.ToBase64String(binaryObject);
            WriteLine($"Binary Object as Base64: {encoded}");

            WriteLine("-------------------------------------------------------------------------------------------------");

            //------PARSE TRINGS TO NUMBERS OR DATES AND TIMES 96
            int age4 = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 July 1980");
            WriteLine($"I was born {age} years ago.");
            WriteLine($"My birthday is {birthday}.");
            WriteLine($"My birthday is {birthday:D}.");

            WriteLine("-------------------------------------------------------------------------------------------------");

            //avoid exception TryParse method
            /*
            Write("How many eggs are there? ");
            int count;
            string input = Console.ReadLine();
            if (int.TryParse(input, out count))
            {
                WriteLine($"There are {count} eggs.");
            }
            else
            {
                WriteLine("I could not parse the input.");
            }
            */

            WriteLine("-------------------------------------------------------------------------------------------------");

            //-----EXCEPTIONS CONVERTING TYPES 98
            /*
            WriteLine("Before parsing");
            Write("What is your age? ");
            string input5 = Console.ReadLine();
            try
            {
                int age5 = int.Parse(input5);
                WriteLine($"You are {age5} years old.");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            WriteLine("After parsing");
            */

            WriteLine("-------------------------------------------------------------------------------------------------");

            //catching all exceptions 100
            /*
             catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            */

            WriteLine("-------------------------------------------------------------------------------------------------");

            //catching specific exception 100
            /*
            catch (FormatException)
            {
                WriteLine("The age you entered is not a valid number format.");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            */
            /*
            catch (OverflowException)
            {
                WriteLine("Your age is a valid number format but it is either too big or small.");
            }
            catch (FormatException)
            {
                WriteLine("The age you entered is not a valid number format.");
            }
            */

            WriteLine("-------------------------------------------------------------------------------------------------");

            //------CHECKING OVERFLOW 102
            /*
            int x5 = int.MaxValue - 1;
            WriteLine($"Initial value: {x5}");
            x5++;
            WriteLine($"After incrementing: {x5}");
            x5++;
            WriteLine($"After incrementing: {x5}");
            x5++;
            WriteLine($"After incrementing: {x5}");
            */
            try
            {
                checked
                {
                    int x5 = int.MaxValue - 1;
                    WriteLine($"Initial value: {x5}");
                    x5++;
                    WriteLine($"After incrementing: {x5}");
                    x5++;
                    WriteLine($"After incrementing: {x5}");
                    x5++;
                    WriteLine($"After incrementing: {x5}");
                }
            }
            catch (OverflowException)
            {
                WriteLine("The code overflowed but I caught the exception.");
            }














        }

        //1conditional logical operators 76
        private static bool DoStuff()
        {
            WriteLine("I am doing some stuff.");
            return true;
        }
    }
}