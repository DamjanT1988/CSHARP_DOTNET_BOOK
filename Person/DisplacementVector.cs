using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//203
namespace PacktLibrary
{
    public struct DisplacementVector
    {
        public int X;
        public int Y;
        public DisplacementVector(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
        }
        public static DisplacementVector operator +(
        DisplacementVector vector1,
        DisplacementVector vector2)
        {
            return new DisplacementVector(
            vector1.X + vector2.X,
            vector1.Y + vector2.Y);
        }

        /*
        °° The type is declared using struct instead of class.
        °° It has two int fields, named X and Y.
        °° It has a constructor for setting initial values for X and Y.
        °° It has an operator for adding two instances together that returns a
        new instance of the type with X added to X, and Y added to Y.
         */
    }
}
