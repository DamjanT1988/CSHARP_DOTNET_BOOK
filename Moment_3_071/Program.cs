//SYSTEM
using System;
using System.Buffers;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using static System.Console;

namespace Moment_3_071
{
    class Program
    {

        static void Main(string[] args)
        {

            //INSTANCE
            Guestbook book = new Guestbook { };

            string option = string.Empty;

            LoadFile(book);

            //TEXT
            WriteLine("                                  '||'''|. '||   ||` '||'''|. '||   ||`    '||'''|,  '||   ||` '||'''|,  '||   ||` \r\n                                   ||   ||  ||   ||   ||   ||  ||   ||      ||   ||   ||   ||   ||   ||   ||   ||  \r\n                                   ||   ||  ||   ||   ||   ||  ||   ||      ||;;;;    ||   ||   ||;;;;    ||   ||  \r\n                                   ||   ||  ||   ||   ||   ||  ||   ||      ||   ||   ||   ||   ||   ||   ||   ||  \r\n                                  .||...|'  `|...|'  .||...|'  `|...|'     .||...|'   `|...|'  .||...|'   `|...|'  \r\n                                                                                                                   \r\n                                                                                                                   \r\n");
            WriteLine("                                                                \r\n                                           .oPYo. o    o .oPYo. .oPYo. ooooo  .oPYo. .oPYo. .oPYo.  o   o \r\n                                           8    8 8    8 8.     8        8    8   `8 8    8 8    8  8  .P \r\n                                           8      8    8 `boo   `Yooo.   8   o8YooP' 8    8 8    8 o8ob'  \r\n                                           8   oo 8    8 .P         `8   8    8   `b 8    8 8    8  8  `b \r\n                                           8    8 8    8 8           8   8    8    8 8    8 8    8  8   8 \r\n                                           `YooP8 `YooP' `YooP' `YooP'   8    8oooP' `YooP' `YooP'  8   8 \r\n                                           :....8 :.....::.....::.....:::..:::......::.....::.....::..::..\r\n                                           :::::8 ::::::::::::::::::::::::::::::::::::::::::::::::::::::::\r\n                                           :::::..::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            WriteLine("\n\n");
            /*WriteLine(
                    "-- DUDU & BUBU GUESTBOOK --\n" +
                    "**************************\n" +
                    "*******MIUN EDITION****\n" +
                    "*********HT*2022*****\n" +
                    "******************\n" +
                    "*****BUBU<3*****\n" +
                    "*************\n\n"
                );*/

            //MENU
            do
            {           

                WriteLine(book.GetList());


                WriteLine("\n\nWhat do you want to do? Enter..\n\n" +
                    "-> 'C' to create a new post \n" +
                    "-> 'D' to delete a post \n" +
                    "-> 'X' to close the program\n");
                option = CheckInput(ReadLine());

                if (option.ToLower() == "c")
                {
                    CreatePost(book);
                }

                if (option.ToLower() == "d")
                {
                    DeletePost(book);
                }
            } while (option.ToLower() != "x");

        }

        static void CreatePost(Guestbook book)
        {
            WriteLine("\nCREATE NEW POST \n\n" +
                "Who is writing:");
            string writer = CheckInput(ReadLine());
            WriteLine("\nWrite something awesome in the guestbook:");
            string content = CheckInput(ReadLine());

            book.PostItem.Add(new Guestbook { Writer = writer, Content = content });

            Clear();

            book.SaveGuestbook();

        }

        static void DeletePost(Guestbook book)
        {
            WriteLine("\nDELETE A POST \n\n" +
            "Write the number of the post to delete:");
            int delete = Convert.ToInt32(CheckInput(ReadLine()));

            if (delete <= 0 || book.PostItem.Count < delete)
            {
                WriteLine("No such post number!");
            } else
            {
                book.PostItem.Remove(book[delete - 1]);
            }

            Clear();

            book.SaveGuestbook();
        }

        static void LoadFile(Guestbook book)
        {
            string jsonString = File.ReadAllText(@"C:\kodprojekt\CSHARP_DOTNET_BOOK\Moment_3_071/guestbook.json");

            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);

            for (int i = 0; i < obj.Count; i++)
            {
                book.PostItem.Add(new Guestbook { Writer = obj[i].Writer, Content = obj[i].Content, Date = obj[i].Date });
            }
        }

        static string CheckInput(string input)
        {
            if (input == "")
            {
                WriteLine("Please enter a valid text:");
                return CheckInput(ReadLine());
            }
            //if no error, send back input
            else
            {
                return input;
            }
        }
    }
}
