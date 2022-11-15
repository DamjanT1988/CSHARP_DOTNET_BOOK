using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using static System.Formats.Asn1.AsnWriter;
using System.Text;
using static System.Console;
using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace KnowYourBirthDay
{
    class Program
    {
        static void Main(string[] args)
        {
            //title
            Write(
                "********************************************************************************************\n" +
                "'NAME THE DAY' CALCULATOR - FIND YOU BIRTHDAY WEEKDAY NAME & WHAT OLD SWEDISH FOLKLORE SAYS\n" +
                "********************************************************************************************\n\n");

            //text
            Write("Old Swedish folklore saying:\n\n" + 
                "'Söndagsbarn, barn födda under söndagsdygnet, ansågs enligt folktro besitta egenskaper \n" +
                "som skulle ge dem framgång i livet. \n\n" +
                "De hade i en del fall också förmåga att bota sjukdomar, och de var synska, vilket\n" +
                "innebar att de kunde se sådant (övernaturligt) som var fördolt för andra människor.\n\n" +
                "Torsdagsbarn blev liksom söndagsbarn synska och kanske trollkunniga. Denna sistnämnda\n" +
                "föreställning sammanhängde sannolikt med att torsdagen, och då särskilt kvällen och \n" +
                "den följande natten, var en tid lämpad för trollkonster och magiska åtgärder.'\n\n\n"
                );

            //get day input
            Write("Enter the day number of your birth (1-31):");
            //check the day, store
            int day = CheckDay(Convert.ToInt32(CheckInput(ReadLine())));

            //get month input
            Write("Enter the month number of your birth (1-12):");
            //check the month, store
            int month = CheckMonth(Convert.ToInt32(CheckInput(ReadLine())));

            //get year input
            Write("Enter the year number of your birth (xxxx):");
            //check the year, store
            int year = CheckYear(Convert.ToInt32(CheckInput(ReadLine())));

            //adjust the months
            if (month < 3)
            {
                month += 12;
                year -= 1;
            }

            //get century
            double century = Math.Floor(year / 100D);

            //modulus of year
            year %= 100;

            //algorithm
            double dayOfWeekGregorian = Math.Floor((day + (13 * (month + 1) / 5) + year + (year / 4) + (century / 4) - 2 * century) % 7);

            //write the result
            Write($"\n\n**********************************************************\n You are born on a " +
                CalcDay(dayOfWeekGregorian) + "\n**********************************************************\n\n");
        }

        //function to assign day to Zeller's number
        static string CalcDay(double dayNumber)
        {
            //initialize empty string
            string nameOfDay = string.Empty;

            //check which number from algorithm, assign day as string
            switch (dayNumber)
            {
                case 0:
                    nameOfDay = "Saturday - you have 'Mödorna trycka'";
                    break;
                case 1:
                    nameOfDay = "Sunday - you have 'Leva & njuta rikt'";
                    break;
                case 2:
                    nameOfDay = "Monday - you have 'Fagert skinn'";
                    break;
                case 3:
                    nameOfDay = "Tuesday - you have 'Älskligt sinn'";
                    break;
                case 4:
                    nameOfDay = "Wednesday - you have 'Fött till ve'";
                    break;
                case 5:
                    nameOfDay = "Thursday - you have 'Får mycket se'";
                    break;
                case 6:
                    nameOfDay = "Friday - you have 'Kärlek & lycka'";
                    break;

            }
            //send back string
            return nameOfDay;
        }

        //check valid input
        static string CheckInput(string input)
        {
            //check result of input
            int i;
            bool result = int.TryParse(input, out i);
            
            //if no parse, false then read again, repeat until valid input
            if (!result)
            {
                WriteLine("Please enter a valid number:");
                return CheckInput(ReadLine());
            }
            //if no error, send back input
            else
            {
                return input;
            }
        }

        //control correct day input
        static int CheckDay(int inputDay)
        {
            //check day range
            if (inputDay < 1 || inputDay > 31)
            {
                //if wrong day, then read again
                do
                {
                    Write("Please enter a number between 1 to 31:");
                    string inputDayNew = ReadLine();
                    int.TryParse(inputDayNew, out inputDay);
                }
                //repeat until correct day number is read
                while (inputDay < 1 || inputDay > 31);
                //send back correct number
                return inputDay;
            }
            //if correct range, send back 
            else
            {
                return inputDay;
            }
        }

        //control correct month input
        static int CheckMonth(int inputMonth)
        {
            //check month range
            if (inputMonth < 1 || inputMonth > 12)
            {
                //if wrong month, then read again
                do
                {
                    Write("Please enter a number between 1 to 12:");
                    string inputDayNew = ReadLine();
                    int.TryParse(inputDayNew, out inputMonth);
                }
                //repeat until correct month number is read
                while (inputMonth < 1 || inputMonth > 12);
                //send back correct number
                return inputMonth;
            }
            //if correct range, send back
            else
            {
                return inputMonth;
            }
        }

        //control correct year input
        static int CheckYear(int inputYear)
        {
            //check year range
            if (inputYear < 1 || inputYear > DateTime.Now.Year)
            {
                //if wrong year, then read again
                do
                {
                    Write($"Please enter a number between 1 to {DateTime.Now.Year}:");
                    string inputDayNew = ReadLine();
                    int.TryParse(inputDayNew, out inputYear);
                }
                //repeat until correct year number is read
                while (inputYear < 1 || inputYear > DateTime.Now.Year);
                //send back correct number
                return inputYear;
            }
            //if correct range, send back
            else
            {
                return inputYear;
            }
        }
    }
}