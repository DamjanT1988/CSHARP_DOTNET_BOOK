//SYSTEM
using System;
using System.Text;
using System.Xml.Linq;
using static System.Console;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Intrinsics.X86;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;

namespace Moment_3_071
{
    public partial class Guestbook
    {
        //---FIELDS
        
        public string Writer { get; set; } //max 50 letters

        public string Content { get; set; } //max 150 letters

        public DateTime Date { get; set; }

        //new list för Guestbook object 
        public List<Guestbook> PostItem = new List<Guestbook>();



        //---CONSTRUCTORS
        //create a new object upon instance
        public Guestbook()
        {
            // set default values for fields
            // including read-only fields
            Writer = "Unknown";
            Content = "Unknown";
            Date = DateTime.Now;
        }



        //---METHODS
        //methods for printing the list
        public string GetList()
        {
            //use a string builder, instead of using $"..."
            var report = new StringBuilder();
            //HEADER-make the table with AppendLine;  \t is a tab in line
            report.AppendLine("#\tDate\t\tWriter\t\t  Content \n------------------------------------------------------------------------");

            //go through all transaction items
            for (int i = 0; i < PostItem.Count; i++)
            {
                //ROWS-create the content 
                report.AppendLine($"{i + 1}\t{PostItem[i].Date.ToShortDateString()}\t{PostItem[i].Writer}\t\t{PostItem[i].Content}");
            }

            //return as a string
            return report.ToString();
        }

        //save the list to a file
        public void SaveGuestbook()
        {
            //serialize the list to a variable
            string json = JsonSerializer.Serialize(PostItem);
            //write the JSON list to a file
            File.WriteAllText(@"C:\kodprojekt\CSHARP_DOTNET_BOOK\Moment_3_071\guestbook.json", json);
        }
    }
}