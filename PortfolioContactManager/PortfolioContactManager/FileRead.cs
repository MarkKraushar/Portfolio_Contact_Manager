//Name: Mark Kraushar
//Date: Nov. 30, 2011
//File: FileRead.cs
//Purpose: Read existing contacts from .txt file.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PortfolioContactManager
{
    class FileRead
    {
        public static void readContacts(string contactsFile, List<contact> contactList)
        {
            // declare variables
            string firstName;
            string middleName;
            string lastName;
            int contactType;
            long phoneNumber;
            string emailAddress;
            int index = 0;

            // read file into array
            string lineOfText;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(contactsFile);
                while ((lineOfText = reader.ReadLine()) != null)
                {
                    string[] arrayOfLineParts = lineOfText.Split(',');
                    firstName = arrayOfLineParts[0];
                    middleName = arrayOfLineParts[1];
                    lastName = arrayOfLineParts[2];
                    contactType = int.Parse(arrayOfLineParts[3]);
                    phoneNumber = long.Parse(arrayOfLineParts[4]);
                    emailAddress = arrayOfLineParts[5];
                    //populate the List with arrayOfLineParts "new" student
                    contactList.Add(new contact(firstName, middleName, lastName,
                                                contactType, phoneNumber, emailAddress));
                    index++;
                }// end of while loop
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file {0} could not be read", contactsFile);
                Console.WriteLine("The error was {0}", ex.Message);
            }
            finally
            {
                // closes file properly
                reader.Close();
                // disposes of reader
                reader.Dispose();
            }
        }
    }
}
