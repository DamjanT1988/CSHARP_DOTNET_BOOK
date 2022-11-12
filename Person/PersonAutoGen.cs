using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//--KAPITEL 5 - CONTROLLING ACCESS WITH PROPERTIES OCH INDEXERS 172
/*
 A property is simply a method (or a pair of methods) that acts and looks like a field
when you want to get or set a value, thereby simplifying the syntax


 */

namespace PacktLibrary
{
    public partial class Person
    {
        //defining readonly properties 172
        /*
        °° The first property will perform the same role as the GetOrigin
        method using the property syntax that works with all versions of C#
        (although, it uses the C# 6 and later string interpolation syntax).
        °° The second property will return a greeting message using the
        C# 6 and, later, the lambda expression (=>) syntax.
        °° The third property will calculate the person's age.
         */

        // a property defined using C# 1 - 5 syntax
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }
        
        // two properties defined using C# 6+ lambda expression syntax
        public string Greeting => $"{Name} says 'Hello!'";
        public int Age => System.DateTime.Today.Year - DateOfBirth.Year;



        //defining settable properties 17
        public string FavoriteIceCream { get; set; } // auto-syntax

        private string favoritePrimaryColor;
        
        public string FavoritePrimaryColor
        {
            get
            {
                return favoritePrimaryColor;//return other but private field at call
            }
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favoritePrimaryColor = value;//private class field only set locally
                        break;
                    default:
                        throw new System.ArgumentException(
                        $"{value} is not a primary color. " +
                        "Choose from: red, green, blue.");
                }
            }
        }


        //defining indexers 176
        // indexers
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }
    }
}
