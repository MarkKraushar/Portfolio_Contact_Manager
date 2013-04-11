//Name: Mark Kraushar
//Date: Dec 5, 2011
//File: ListMethods.cs
//Purpose: search and display methods for lists
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioContactManager
{
    class ListMethods
    {
        // displays entire list with a selectable index number, for modifying and deleting contacts
        public static void displayListWithIndex(List<contact> contactList)
        {
            // declare variables
            long contactNumber = 1;
            // write out list
            Console.WriteLine();// break
            foreach (contact contactEx in contactList)
            {
                Console.WriteLine("Contact #{0}", contactNumber);
                Console.WriteLine("First Name: {0}", contactEx.firstName);
                Console.WriteLine("Middle Name: {0}", contactEx.middleName);
                Console.WriteLine("Last Name: {0}", contactEx.lastName);
                Console.Write("Contact Type: "); InputOutput.contactTypeDecider(contactEx.contactType);
                Console.WriteLine("Phone Number: {0}", contactEx.phoneNumber);
                Console.WriteLine("E-mail: {0}", contactEx.emailAddress);
                Console.WriteLine("");// break
                contactNumber++;
            }
        }

        // displays entire contact list, sorted by contact type, and with a counter for how many of each contact type
        // separating the displayed groups
        public static void displayListByContactType(List<contact> contactList)
        {
            ListMethods.searchByContactType(contactList, 1);
            ListMethods.searchByContactType(contactList, 2);
            ListMethods.searchByContactType(contactList, 3);
            ListMethods.searchByContactType(contactList, 4);
        }

        // displays a single contact
        public static void displayContact(List<contact> contactList, int contactIndex)
        {
            Console.WriteLine("Contact #{0}", contactIndex + 1);
            Console.WriteLine("First Name: {0}", contactList[contactIndex].firstName);
            Console.WriteLine("Middle Name: {0}", contactList[contactIndex].middleName);
            Console.WriteLine("Last Name: {0}", contactList[contactIndex].lastName);
            Console.Write("Contact Type: "); InputOutput.contactTypeDecider(contactList[contactIndex].contactType);
            Console.WriteLine("Phone Number: {0}", contactList[contactIndex].phoneNumber);
            Console.WriteLine("E-mail: {0}", contactList[contactIndex].emailAddress);
        }

        // search for a first name, partial matches accepted, case insensitive
        public static void searchByFirstName(List<contact> contactList, string searchName)
        {
            // declare variables
            bool contactFound = false;
            Console.WriteLine("");// space
            // search list for firstName and display all matches
            for (int counter = 0; counter < contactList.Count; counter++)
                {
                    if (contactList[counter].firstName.StartsWith(searchName, StringComparison.OrdinalIgnoreCase))
                    {
                        contactFound = true;
                        ListMethods.displayContact(contactList, counter);
                        Console.WriteLine("");// break
                    }
                }
            if (!contactFound)
            {
                Console.WriteLine("No matches found.\n");
            }
        }

        // search for a last name, partial matches accepted, case insensitive
        public static void searchByLastName(List<contact> contactList, string searchName)
        {
            // declare variables
            bool contactFound = false;
            Console.WriteLine("");// space
            // search list for lastName and display all matches
            for (int counter = 0; counter < contactList.Count; counter++)
            {
                if (contactList[counter].lastName.StartsWith(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    contactFound = true;
                    ListMethods.displayContact(contactList, counter);
                    Console.WriteLine("");// break
                }
            }
            if (!contactFound)
            {
                Console.WriteLine("No matches found.\n");
            }
        }

        // search for a contact type, case insensitive
        public static void searchByContactType(List<contact> contactList, int searchContactInt)
        {
            // declare variables
            bool contactFound = false;
            int numberOfContacts = 0;
            Console.WriteLine("");// space
            // search list for contactType and display all matches
            for (int counter = 0; counter < contactList.Count; counter++)
            {
                if (contactList[counter].contactType == searchContactInt)
                {
                    contactFound = true;
                    numberOfContacts++;
                    ListMethods.displayContact(contactList, counter);
                    Console.WriteLine("");// break
                }
            }// end of for loop
            if (!contactFound)
            {
                Console.WriteLine("You have no contacts of that type.");
            }
            else if (contactFound)
            {
                Console.Write("You have {0} contacts of type ", numberOfContacts); InputOutput.contactTypeDecider(searchContactInt);
            }
        }

        // bubble sort by phone number
        public static void sortByPhoneNumber(List<contact> contactList)
        {
            // declare variables
            int index = 0, pairsToCompare = contactList.Count - 1;
            contact temp;
            bool swap = true;
            // start of loop
            while (pairsToCompare > 0 && swap)
            {
                swap = false;
                index = 0;
                while (index < pairsToCompare)
                {
                    if (contactList[index].phoneNumber > contactList[index + 1].phoneNumber)
                    {
                        temp = contactList[index];
                        contactList[index] = contactList[index + 1];
                        contactList[index + 1] = temp;
                        swap = true;
                    }
                    index++;
                }// end of inner while loop
                pairsToCompare--;
            }// end of outer while loop
        }

        // binary search by phone number
        public static void binaryPhoneNumberSearch(List<contact> contactList, long searchNumber)
        {
            // declare variables
            int first = 0, last = contactList.Count - 1, middle, foundIndex = -1;
            while (first <= last && foundIndex == -1)
            {
                middle = (first + last) / 2;
                if (contactList[middle].phoneNumber == searchNumber)
                {
                    foundIndex = middle;
                }
                else if (contactList[middle].phoneNumber < searchNumber)
                {
                    first = middle + 1;
                }
                else
                {
                    last = middle - 1;
                }
            }// end of while loop
            if (foundIndex == -1)
            {
                Console.WriteLine("\nYou have no contacts with that phone number.");
            }
            else if (foundIndex != -1)
            {
                Console.WriteLine();
                ListMethods.displayContact(contactList, foundIndex);
            }
        }

        // sort bt first name
        public static void sortByFirstName(List<contact> contactList)
        {
            contactList.Sort((x, y) => string.Compare(x.firstName, y.firstName));
        }

        // sort bt last name
        public static void sortByLastName(List<contact> contactList)
        {
            contactList.Sort((x, y) => string.Compare(x.lastName, y.lastName));
        }
    }
}
