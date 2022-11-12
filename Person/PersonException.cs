using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//216
namespace PacktLibrary
{
    public class PersonException : Exception
    {
        
        public PersonException() : base() { }
        
        //store
        public PersonException(string message) : base(message) { }


        public PersonException(
        string message, Exception innerException)
        : base(message, innerException) { }
    }
}
