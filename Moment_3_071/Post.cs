//SYSTEM
using System;
using System.Text;
using System.Xml.Linq;
using static System.Console;

namespace Moment_3_071
{
    public partial class Guestbook
    {
        //FIELDS
        public string Owner { get; set; } //max 50 letters

        public string Content { get; set; } //max 15 words

        public DateTime Date { get; set;  }

        public List<Guestbook> PostItem = new List<Guestbook>();

        //public string Number { get; }

        private static int postIntialNo = 1;

        //--CONSTRUCTORS
        public Guestbook()
        {
            // set default values for fields
            // including read-only fields
            Owner = "Unknown";
            Content = "Unknown";
            Date = DateTime.Now;
            //Number = 
        }

        public string GetList()
        {
            //use a string builder, instead of using $"..."
            var report = new StringBuilder();
            //HEADER-make the table with AppendLine;  \t is a tab in line
            report.AppendLine("Date\t\tOwner\t\tContent");

            //go through all transaction items
            foreach (var item in PostItem)
            {
                //ROWS-create the content
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Owner}\t{item.Content}");
            }
            //return as a string
            return report.ToString();
        }
       
        /*
        public Post(string owner, string content, string date)
        {
            Owner = owner;
            Content = content;
            Date = date;

            this.Number = postIntialNo;
        }
        */

        /*
        public Post(string OwnerName, string ContentText)
        {
            this.Owner = OwnerName;
            this.Content = ContentText;
            this.Number = postIntialNo.ToString();
            

            postIntialNo++;
        }
        */
    }
}