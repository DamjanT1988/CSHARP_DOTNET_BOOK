//---SYSTEM - use packages  etc.
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
        //start/main function
        static void Main(string[] args)
        {
            //---INSTANCE - use object 
            Guestbook book = new Guestbook { };

            //initiate a variable
            string option = string.Empty;

            //call method to load the book object
            LoadFile(book);

            //title of the console application
            WriteLine("                                  '||'''|. '||   ||` '||'''|. '||   ||`    '||'''|,  '||   ||` '||'''|,  '||   ||` \r\n                                   ||   ||  ||   ||   ||   ||  ||   ||      ||   ||   ||   ||   ||   ||   ||   ||  \r\n                                   ||   ||  ||   ||   ||   ||  ||   ||      ||;;;;    ||   ||   ||;;;;    ||   ||  \r\n                                   ||   ||  ||   ||   ||   ||  ||   ||      ||   ||   ||   ||   ||   ||   ||   ||  \r\n                                  .||...|'  `|...|'  .||...|'  `|...|'     .||...|'   `|...|'  .||...|'   `|...|'  \r\n                                                                                                                   \r\n                                                                                                                   \r\n");
            WriteLine("                                                                \r\n                                           .oPYo. o    o .oPYo. .oPYo. ooooo  .oPYo. .oPYo. .oPYo.  o   o \r\n                                           8    8 8    8 8.     8        8    8   `8 8    8 8    8  8  .P \r\n                                           8      8    8 `boo   `Yooo.   8   o8YooP' 8    8 8    8 o8ob'  \r\n                                           8   oo 8    8 .P         `8   8    8   `b 8    8 8    8  8  `b \r\n                                           8    8 8    8 8           8   8    8    8 8    8 8    8  8   8 \r\n                                           `YooP8 `YooP' `YooP' `YooP'   8    8oooP' `YooP' `YooP'  8   8 \r\n                                           :....8 :.....::.....::.....:::..:::......::.....::.....::..::..\r\n                                           :::::8 ::::::::::::::::::::::::::::::::::::::::::::::::::::::::\r\n                                           :::::..::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            WriteLine("\n\n");


            //---PROGRAM
            //menu is always visible in do..while loop until speicifc input
            do
            {           
                //get list from class of the book object & its list by calling the class & method
                WriteLine(book.GetList());

                //menu text with four lines
                WriteLine("\n\nWhat do you want to do? Enter..\n\n" +
                    "-> 'C' to create a new post \n" +
                    "-> 'D' to delete a post \n" +
                    "-> 'X' to close the program\n");

                //read input then store input from user in variable, while calling mmethod to validate input
                option = CheckInput(ReadLine());

                //check input for menu option C
                if (option.ToLower() == "c")
                {
                    //call method with object
                    CreatePost(book);
                }

                //check input for menu option D
                if (option.ToLower() == "d")
                {
                    //call method with object
                    DeletePost(book);
                }

                //clear console
                Clear();

                //run the program until input X is stored; lower case the input
            } while (option.ToLower() != "x");

        }

        

        //---METHODS

        //method for creating post, passing the instance/object as a parameter
        static void CreatePost(Guestbook book)
        {
            //write text in console
            WriteLine("\nCREATE NEW POST \n\n" +
                "Who is writing:");
            //read input from user, store in variable, call method to check input
            string writer = CheckInput(ReadLine());

            //write text in console
            WriteLine("\nWrite something awesome in the guestbook:");
            //read input from user, store in variable, call method to check input
            string content = CheckInput(ReadLine());

            //adding with Add-method to the list in book object, with variables 
            book.PostItem.Add(new Guestbook { Writer = writer, Content = content });

            //clear the console
            Clear();

            //call method to save the list to JSON file
            book.SaveGuestbook();
        }


        //method for deleting post, passing the instance/object as a parameter
        static void DeletePost(Guestbook book)
        {
            //write text in console
            WriteLine("\nDELETE A POST \n\n" +
            "Write the number of the post to delete:");

            //get user input, call method to validate, convert string to integer, store in variable
            int delete = Convert.ToInt32(CheckInt(ReadLine()));
            
                //check input range of integer if it exist in the list
                if (delete <= 0 || book.PostItem.Count < delete)
                {
                    //write line if no number
                    WriteLine("No such post number!");
                } else
                {
                    //remove the item on list by remove-method
                    book.PostItem.Remove(book[delete - 1]);
                }

            //clear the console
            Clear();

            //call method to save the list to JSON file
            book.SaveGuestbook();
        }


        //method to load text from JSON, create the object/list 
        static void LoadFile(Guestbook book)
        {
            //read text from file, store in a variable as JSON-string
            string jsonString = File.ReadAllText(@"C:\kodprojekt\CSHARP_DOTNET_BOOK\Moment_3_071/guestbook.json");

            //deserialize the JSON-string
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonString);

            //loop through the objects, create new items in the list
            for (int i = 0; i < obj.Count; i++)
            {
                //add new item in list by Add-method
                book.PostItem.Add(new Guestbook { Writer = obj[i].Writer, Content = obj[i].Content, Date = obj[i].Date });
            }
        }

        //methos to validate input from user
        static string CheckInput(string input)
        {
            //check if empty input
            if (input == "")
            {
                //write text if empty
                WriteLine("Please enter a valid text:");
                //call the same method until correct input is filled
                return CheckInput(ReadLine());
            }
            //if no error, send back input
            else
            {
                return input;
            }
        }

        //methos to validate input from user
        static string CheckInt(string input)
        {
            //check if empty input
            if (!int.TryParse(input, out int result))
            {
                //write text if empty
                WriteLine("Please enter a valid number:");
                //call the same method until correct input is filled
                return CheckInt(ReadLine());
            }
            //if no error, send back input
            else
            {
                return input;
            }
        }
    }
}
