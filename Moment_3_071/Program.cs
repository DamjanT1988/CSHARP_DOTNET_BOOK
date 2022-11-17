//SYSTEM
using System;
using System.Buffers;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using static System.Console;

namespace Moment_3_071
{
    class Program
    {

        static void Main(string[] args)
        {

            //INSTANCE
            Guestbook book = new Guestbook { Owner = "Damjan", Content = "Awesome content" };

            string option = string.Empty;

            //MENU
            do
            {
                //TEXT
                WriteLine(
                        "DAMJAN'S AWESOME GUESTBOOK!\n" +
                        "**************************\n" +
                        "*******MIUN EDITION****\n" +
                        "*********HT*2022*****\n" +
                        "******************\n" +
                        "*****BUBU<3*****\n" +
                        "*************\n"
                    );

                WriteLine("\n////////////////////////////////////////////////////////////////////////\n\n" +
                    book.GetList() +
                    "\n////////////////////////////////////////////////////////////////////////");

                WriteLine("\n\nWhat do you want to do? \n\n" +
                    "-> Type 1 to make a new post \n" +
                    "-> Type 2 to select to delete a post \n\n" +
                    "Type 0 to exit the program");
                option = ReadLine();

                if (option == "1")
                {
                    CreatePost(book);
                }
            } while (option.ToLower() != "0");
        }

        static void CreatePost(Guestbook book)
        {
            WriteLine("\n\nCREATE NEW POST \n\n" +
                "Who is writing:");
            string owner = ReadLine();
            WriteLine("\nWrite something awesome in the guestbook:");
            string content = ReadLine();

            book.PostItem.Add(new Guestbook { Owner = owner, Content = content });

            Console.Clear();
        }

        static void DeletePost(Guestbook book)
        {

        }


        /*
            WriteLine("Who is writing");
            string owner = ReadLine();
            WriteLine("Write something awesome in the guestbook:");
            string content = ReadLine();
            */

        //Globals.book;

        //Globals.book.PostItem.Add(new Guestbook { Owner = owner, Content = content });

        /*
        WriteLine("Who is writing");
        owner = ReadLine();
        WriteLine("Write something awesome in the guestbook:");
        content = ReadLine();
        */


        //Globals.counter++;

        //Post[] posts = {};

        /*
        WriteLine("Who is writing");
        owner = ReadLine();
        WriteLine("Write something awesome in the guestbook:");
        content = ReadLine();
        posts.Children.Add(new Post { Owner = owner, Content = content });
        */
        /*
        CreatePost(); 
        CreatePost(); 
        CreatePost();
        CreatePost();*/
    }
}
