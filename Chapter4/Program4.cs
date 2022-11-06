using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using static System.Formats.Asn1.AsnWriter;
using System.Text;
using static System.Console;
using System.Linq.Expressions;

//-----KAPITEL 4 - WRITING, DEBUGGING, TESTING FUNCTIONS
/*
This chapter is about writing functions to reuse code, debugging logic errors during
development, logging exceptions during runtime, and unit testing your code to
remove bugs and ensure stability and reliability.
This chapter covers the following topics:
• Writing functions
• Debugging during development
• Logging during runtime
• Unit testing
*/

namespace Basics
{
    class Program4
    {
        //--1
        static void Main(string[] args)
        {
            ////RunTimesTable();
            ////RunCalculateTax();
            ////RunCardinalToOrdinal();
            RunFactorial();
        }

        //writing functions 109
        //--3
        static void TimesTable(byte number)
        {
            WriteLine($"This is the {number} times table:");
            for (int row = 1; row <= 12; row++)
            {
                WriteLine(
                $"{row} x {number} = {row * number}");
            }
            WriteLine();
        }

        //--2
        static void RunTimesTable()
        {
            bool isNumber;
            do
            {
                Write("Enter a number between 0 and 255: ");
                isNumber = byte.TryParse(
                ReadLine(), out byte number);
                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            }
            while (isNumber);
        }

        /*
        In the preceding code, note the following:
        °° We have statically imported the Console type so that we can simplify
        calls to its methods such as WriteLine.
        °° We have written a function named TimesTable that must have
        a byte value passed to it named number.
        °° TimesTable does not return a value to the caller, so it is declared
        with the void keyword before its name.
        °° TimesTable uses a for statement to output the times table for the
        number passed to it.
        °° We have written a function named RunTimesTable that prompts the
        user to enter a number, and then calls TimesTable, passing it the
        entered number. It loops while the user enters valid numbers.
        °° We call RunTimesTable in the Main method. 
        */

        //function returns value 112

        /*
        °° The CalculateTax function has two inputs: A parameter named
        amount that will be the amount of money spent, and a parameter
        named twoLetterRegionCode that will be the region the amount is
        spent in.
        °° The CalculateTax function will perform a calculation using
        a switch statement, and then return the sales tax or VAT owed on
        the amount as a decimal value; so, before the name of the function,
        we have declared the data type of the return value.
        °° The RunCalculateTax function prompts the user to enter an amount
        and a region code, and then calls CalculateTax and outputs the
        result. 
        */

        static decimal CalculateTax(
            decimal amount, string twoLetterRegionCode)
        {
            decimal rate = 0.0M;
            switch (twoLetterRegionCode)
            {
                case "CH": // Switzerland
                    rate = 0.08M;
                    break;
                case "DK": // Denmark
                case "NO": // Norway
                    rate = 0.25M;
                    break;
                case "GB": // United Kingdom
                case "FR": // France
                    rate = 0.2M;
                    break;
                case "HU": // Hungary
                    rate = 0.27M;
                    break;
                case "OR": // Oregon
                case "AK": // Alaska
                case "MT": // Montana
                    rate = 0.0M; break;
                case "ND": // North Dakota
                case "WI": // Wisconsin
                case "ME": // Maryland
                case "VA": // Virginia
                    rate = 0.05M;
                    break;
                case "CA": // California
                    rate = 0.0825M;
                    break;
                default: // most US states
                    rate = 0.06M;
                    break;
            }
            return amount * rate;
        }
        static void RunCalculateTax()
        {
            Write("Enter an amount: ");
            string amountInText = ReadLine();

            Write("Enter a two-letter region code: ");
            string region = ReadLine();
            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine("You did not enter a valid amount!");
            }
        }



        //-----MATHEMATICAL FUNCTIONS 114

        //--3
        static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    string numberAsText = number.ToString();
                    char lastDigit = numberAsText[numberAsText.Length - 1];
                    string suffix = string.Empty;
                    switch (lastDigit)
                    {
                        case '1':
                            suffix = "st";
                            break;
                        case '2':
                            suffix = "nd";
                            break;
                        case '3':
                            suffix = "rd";
                            break;
                        default:
                            suffix = "th";
                            break;
                    }
                    return $"{number}{suffix}";
            }
        }
        //--2
        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                Write($"{CardinalToOrdinal(number)} ");
            }
            WriteLine();
        }

        /*
        The CardinalToOrdinal function has one input: a parameter of
        the int type named number, and one output: a return value of the
        string type.
        °° A switch statement is used to handle the special cases of 11, 12, and
        13.
        °° A nested switch statement then handles all other cases: if the last
        digit is 1, then use st as the suffix, if the last digit is 2, then use nd as
        the suffix, if the last digit is 3, then use rd as the suffix, and if the last
        digit is anything else, then use th as the suffix.
        °° The RunCardinalToOrdinal function uses a for statement to loop
        from 1 to 40, calling the CardinalToOrdinal function for each
        number and writing the returned string to the console, separated
        by a space character. 
        */


        //factorials with recursion 116
        //--3
        static int Factorial(int number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }
        //--2
        static void RunFactorial()
        {
            bool isNumber;
            do
            {
                Write("Enter a number: ");
                isNumber = int.TryParse(
                ReadLine(), out int number);
                if (isNumber)
                {
                    WriteLine(
                    $"{number:N0}! = {Factorial(number):N0}");
                }
                else
                {
                    WriteLine("You did not enter a valid number!");
                }
            }
            while (isNumber);
        }

        /*
         °° If the input number is zero or negative, Factorial returns 0.
        °° If the input number is 1, Factorial returns 1, and therefore stops
        calling itself. If the input number is larger than one, Factorial
        multiplies the number by the result of calling itself and passing one
        less than the number. This makes the function recursive.
        °° RunFactorial prompts the user to enter a number, calls the
        Factorial function, and then outputs the result, formatted using the
        code N0, which means number format and use thousands separators
        with zero decimal places, and repeats in a loop as long as another
        number is entered.
        °° In the Main method, comment the RunCardinalToOrdinal method
        call, and call the RunFactorial method.
        */


        //document function XML comments 118

















    }
}
