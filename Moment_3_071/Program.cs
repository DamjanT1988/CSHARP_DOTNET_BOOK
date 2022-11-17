//SYSTEM
using System;
using System.Buffers;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text.Json;
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

            //MENU
            do
            {
                //TEXT
                WriteLine(
                        "---DUDU & BUBU GUESTBOOK---\n" +
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
                    "-> Type 2 to delete a post \n\n" +
                    "Type '0' to close the program");
                option = CheckInput(ReadLine());

                if (option == "1")
                {
                    CreatePost(book);
                }

                if (option == "2")
                {
                    DeletePost(book);
                }
            } while (option != "0");
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

            book.PostItem.Remove(book[delete-1]);

            Clear();

        }

        static string CheckInput(string input)
        {
            if (input == "") 
            {
                WriteLine("Please enter a valid number:");
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
