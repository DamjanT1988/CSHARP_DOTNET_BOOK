using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//217
/*
°° The class imports a namespace for handling regular expressions.
°° The IsValidEmail static method uses the Regex type to check for
matches against a simple email pattern that looks for valid characters
before and after the @ symbol.
 */
namespace PacktLibrary
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            // use simple regular expression to check
            // that the input string is a valid email
            return Regex.IsMatch(input,
            @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }
    }
}
