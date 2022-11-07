using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//198
namespace PacktLibrary
{
    public class Thing
    {
        public object Data = default(object);

        public string Process(object input)
        {
            if (Data == input)
            {
                return "Data and input are the same.";
            }
            else
            {
                return "Data and input are NOT the same.";
            }
        }
    }
}
