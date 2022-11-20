using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moment_3_071
{
    public partial class Guestbook
    {
        //--FIELD
        //use indexer to index the list
        public Guestbook this[int index]
        {
            get
            {
                return PostItem[index];
            }
            set
            {
                PostItem[index] = value;
            }
        }
    }
}
