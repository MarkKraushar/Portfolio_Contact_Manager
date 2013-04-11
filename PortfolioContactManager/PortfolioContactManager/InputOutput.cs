//Name: Mark Kraushar
//Date: Dec 5, 2011
//File: InputOutput.cs
//Purpose: generic input/output methods
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioContactManager
{
    class InputOutput
    {
        // return a valid integer within a given range
        public static int getValidInteger(string menuMessage, int lowestValidInt, int highestValidInt)
        {
            // declare variables
            int validInteger;
            bool inputIsValid = false;
            // do-until loop for validation
            do
            {
                Console.Write(menuMessage, lowestValidInt, highestValidInt);
                // while loop to test for integer data type
                while (!int.TryParse(Console.ReadLine(), out validInteger))
                {
                    Console.WriteLine();// break
                    Console.WriteLine("You may only enter integers.");
                    Console.WriteLine();// break
                    Console.Write(menuMessage, lowestValidInt, highestValidInt);
                }
                // if to test if integer is in valid range
                if (validInteger >= lowestValidInt && validInteger <= highestValidInt)
                {
                    inputIsValid = true;
                }
                else
                {
                    Console.WriteLine();// break
                    Console.WriteLine("You may only enter integers from {0} to {1}.", lowestValidInt, highestValidInt);
                    Console.WriteLine();// break
                }
            } while (!inputIsValid);
            return validInteger;
        }

        // return a valid long within a given range
        public static long getValidLong(string menuMessage, long lowestValidLong, long highestValidLong)
        {
            // declare variables
            long validLong;
            bool inputIsValid = false;
            // do-until loop for validation
            do
            {
                Console.Write(menuMessage, lowestValidLong, highestValidLong);
                // while loop to test for long data type
                while (!long.TryParse(Console.ReadLine(), out validLong))
                {
                    Console.WriteLine();// break
                    Console.WriteLine("You may only enter integers.");
                    Console.WriteLine();// break
                    Console.Write(menuMessage, lowestValidLong, highestValidLong);
                }
                // if statement to test if long is in valid range
                if (validLong >= lowestValidLong && validLong <= highestValidLong)
                {
                    inputIsValid = true;
                }
                else
                {
                    Console.WriteLine();// break
                    Console.WriteLine("You may only enter 10-digit phone numbers from {0} to {1}.", lowestValidLong, highestValidLong);
                    Console.WriteLine();// break
                }
            } while (!inputIsValid);
            return validLong;
        }

        // check for empty string when string input is needed
        public static string getString(string message, string fieldName)
        {
            string userInput;
            Console.Write(message);
            userInput = Console.ReadLine().Trim();  // trims any leading or trailing spaces
            while (string.IsNullOrEmpty(userInput)) // checks for an empty or null input string
            {
                Console.WriteLine("\nYou forgot to enter the {0}.",fieldName);
                Console.Write(message);
                userInput = Console.ReadLine().Trim();
            }
            return userInput;
        }

        // dislpays the programs main menu
        public static void mainMenu()
        {
            Console.WriteLine("\n1 - View all contacts.");
            Console.WriteLine("2 - Sort contacts.");
            Console.WriteLine("3 - Search for a contact.");
            Console.WriteLine("4 - Add a new contact.");
            Console.WriteLine("5 - Delete a contact.");
            Console.WriteLine("6 - Modify a contact.");
            Console.WriteLine("7 - Save and Quit.");

        }

        // asks the user what type of search they wish to perform
        public static void searchTypeMenu()
        {
            Console.WriteLine("\nSelect your desired search type.");
            Console.WriteLine("1 - By first name.");
            Console.WriteLine("2 - By last name.");
            Console.WriteLine("3 - By contact type.");
            Console.WriteLine("4 - By phone number.");
        }

        // take in the contact type integer and display the corresponding string from the contact type array
        public static void contactTypeDecider(int contactType)
        {
            // declare contact type array
            string[] contactTypeArray = new string[4];
            // declare contact types
            contactTypeArray[0] = "Friends";
            contactTypeArray[1] = "Family";
            contactTypeArray[2] = "Professional";
            contactTypeArray[3] = "School";

            switch (contactType)
            {
                case 1:
                    Console.WriteLine(contactTypeArray[0]);
                    break;
                case 2:
                    Console.WriteLine(contactTypeArray[1]);
                    break;
                case 3:
                    Console.WriteLine(contactTypeArray[2]);
                    break;
                case 4:
                    Console.WriteLine(contactTypeArray[3]);
                    break;
                default:
                    Console.WriteLine("{0} is not a defined contact type.");
                    break;
            }
        }
    }
}
