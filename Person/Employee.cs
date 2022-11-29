using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//207
namespace PacktLibrary
{
    public class Employee : Person//inherits from person
    {
        //PROPERTIES
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        //209
        public void WriteToConsole()
        {
            WriteLine(format:
            "{0} was born on {1:dd/MM/yy} and hired on {2:dd/MM/yy}",
            arg0: Name,
            arg1: DateOfBirth,
            arg2: HireDate);
        }

        //212
        public override string ToString()
        {
            return $"{Name}'s code is {EmployeeCode}";
        }




















    }
}
