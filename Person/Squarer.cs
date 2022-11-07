using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//201
namespace PacktLibrary
{
    public static class Squarer
    {
        public static double Square<T>(T input)
        where T : IConvertible
        {
            // convert using the current culture
            double d = input.ToDouble(
            Thread.CurrentThread.CurrentCulture);
            return d * d;
        }

        /*
        °° The Squarer class is non-generic.
        °° The Square method is generic, and its type parameter T must
        implement IConvertible, so the compiler will make sure that it has
        a ToDouble method.
        °° T is used as the type for the input parameter.
        °° ToDouble requires a parameter that implements IFormatProvider to
        understand the format of numbers for a language and region. We can
        pass the CurrentCulture property of the current thread to specify
        the language and region used by your computer. You will learn
        about cultures in Chapter 8, Working with Common .NET Types.
        °° The return value is the input parameter multiplied by itself, that is,
        squared.
         */
    }
}
