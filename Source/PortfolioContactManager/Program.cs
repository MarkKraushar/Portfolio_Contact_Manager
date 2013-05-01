//Name: Mark Kraushar
//Date: Nov. 30, 2011
//File: Program.cs
//Purpose: To read, write, and manage contacts from a file.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PortfolioContactManager
{
    class Program
    {
        // declare file path variable
        private const string STR_RESOURCE_PATH = "Resources\\";
        private const string STR_FILE_NAME = "contact_list.txt";
        private const string STR_NEWFILE_NAME = "contact_list.txt";
        private const string STR_CONTACT_FILE = STR_RESOURCE_PATH + STR_FILE_NAME;
        private const string STR_NEWCONTACT_FILE = STR_RESOURCE_PATH + STR_NEWFILE_NAME;

        static void Main(string[] args)
        {
            // declare variables
            long phoneNumberMin = 1000000000, phoneNumberMax = 9999999999, newPhoneNumber, searchPhoneNumber;
            int mainMenuChoice, searchMenuChoice, doAgainChoice, searchMenuMin = 1, searchMenuMax = 4, mainMenuMin = 1, mainMenuMax = 7,
                doAgainMax = 2, doAgainMin = 1, searchContactType, searchContactMin = 1, searchContactMax = 4, newContactType, contactMin = 0,
                whoToDelete, displayTypeChoice, whoToModify, whatToModify, modifyMin = 1, modifyMax = 7, deleteIndex, modifyIndex, sortTypeChoice, sortTypeMin = 1,
                sortTypeMax = 2, deleteConfirm, deleteConfirmMin = 1, deleteConfirmMax = 2, displayTypeMin = 1, displayTypeMax = 2;
            string searchFirstName, searchLastName, newFirstName, newMiddleName, newLastName, newEmail;
            // message strings
            string mainMenuMessage = "Please select a task: ";
            string searchMenuMessage = "Please select a search type: ";
            string searchByFirstNameMessage = "\nPlease enter a full or partial first name to search for: ";
            string searchByLastNameMessage = "\nPlease enter a full or partial last name to search for: ";
            string searchByContactTypeMessage = "\nSelect a contact type to search for: \n1 - Friends \n2 - Family \n3 - Professional \n4 - School \nPlease make your selection: ";
            string searchAgainMessage = "\nWould you like to search again? \n1 - Yes \n2 - No \nPlease make a selection: ";
            string getFirstNameMessage = "\nPlease enter the contact's first name: ";
            string getMiddleNameMessage = "\nPlease enter the contact's middle name: ";
            string getLastNameMessage = "\nPlease enter the contact's last name: ";
            string getContactTypeMessage = "\nWhat is this contact's type: \n1 - Friends \n2 - Family \n3 - Professional \n4 - School \nPlease make your selection: ";
            string getPhoneNumberMessage = "\nPlease enter the contact's phone number: ";
            string getEmailMessage = "\nPlease enter the contact's E-Mail address: ";
            string addAgainMessage = "\nWould you like to add another contact? \n1 - Yes \n2 - No \nPlease make a selection: ";
            string deleteAgainMessage = "\nWould you like to delete another contact? \n1 - Yes \n2 - No \nPlease make a selection: ";
            string deleteMessage = "Please enter the contact number you would like to delete \n(Enter 0 to delete nothing): ";
            string displayTypeMessage = "\nWhat would you like to view by? \n1 - Current List Order \n2 - Grouped by Contact Type \nPlease make a selection: ";
            string modifyMessage = "Please enter the contact number you would like to modify \n(Enter 0 to modify nothing): ";
            string modifyAgainMessage = "\nWould you like to modify another contact? \n1 - Yes \n2 - No \nPlease make a selection: ";
            string whatToModifymessage = "What would you like to modify? \n1 - First Name \n2 - Middle Name \n3 - Last Name \n4 - Contact Type \n5 - Phone Number \n6 - E-Mail address \n7 - Do not modify \nPlease make a selection: ";
            string phoneNumberSearchMessage = "\nPlease enter the 10-digit phone number you would like to search for: ";
            string sortTypeMessage = "\nWhat would you like to sort by? \n1 - First Name. \n2 - Last Name. \nPlease make a selection: ";
            string deleteConfirmMessage = "\nAre you sure you want to delete this contact? \n1 - Yes \n2 - No \nPlease make a selection: ";
            string saveAndQuitMessage = "Your contact list has been saved successfully.  Have a nice day!";
            string modifyNothingMessage = "\nYour contact has not been modified.";

            // create a list of contacts
            List<contact> contactList = new List<contact>();
            List<contact> newContactList = new List<contact>();
            // populate the contact list from file
            FileRead.readContacts(STR_CONTACT_FILE, contactList);
            // welcome message
            Console.WriteLine("Welcome to your Contact Manager!");
            // begin post-test loop for main program loop
            do
            {
                // display initial menu and get user choice
                InputOutput.mainMenu();
                mainMenuChoice = InputOutput.getValidInteger(mainMenuMessage, mainMenuMin, mainMenuMax);
                switch (mainMenuChoice)
                {
                    case 1:
                        displayTypeChoice = InputOutput.getValidInteger(displayTypeMessage, displayTypeMin, displayTypeMax );
                        // view all contacts
                        Console.WriteLine("");// break
                        if (displayTypeChoice == 1)
                        {
                            ListMethods.displayListWithIndex(contactList);
                        }
                        else
                        {
                            ListMethods.displayListByContactType(contactList);
                        }
                        break;
                    case 2:
                        // sort contacts
                        sortTypeChoice = InputOutput.getValidInteger(sortTypeMessage, sortTypeMin, sortTypeMax);
                        if (sortTypeChoice == 1)
                        {
                            // sort bt first name
                            ListMethods.sortByFirstName(contactList);
                            ListMethods.displayListWithIndex(contactList);
                        }
                        else
                        {
                            // sort by last name
                            ListMethods.sortByLastName(contactList);
                            ListMethods.displayListWithIndex(contactList);
                        }
                        break;
                    case 3:
                        do
                        {
                            // search for a contact
                            InputOutput.searchTypeMenu();
                            searchMenuChoice = InputOutput.getValidInteger(searchMenuMessage, searchMenuMin, searchMenuMax);

                            // if statement to perform selected search type
                            if (searchMenuChoice == 1)
                            {
                                // search by first name
                                searchFirstName = InputOutput.getString(searchByFirstNameMessage, "First Name");
                                ListMethods.searchByFirstName(contactList, searchFirstName);
                            }
                            else if (searchMenuChoice == 2)
                            {
                                // search by last name
                                searchLastName = InputOutput.getString(searchByLastNameMessage, "Last Name");
                                ListMethods.searchByLastName(contactList, searchLastName);
                            }
                            else if (searchMenuChoice == 3)
                            {
                                // search by contact type
                                searchContactType = InputOutput.getValidInteger(searchByContactTypeMessage, searchContactMin, searchContactMax);
                                ListMethods.searchByContactType(contactList, searchContactType);
                            }
                            else
                            {
                                // search by phone number
                                searchPhoneNumber = InputOutput.getValidLong(phoneNumberSearchMessage, phoneNumberMin, phoneNumberMax);
                                // bubble sort by phone number
                                ListMethods.sortByPhoneNumber(contactList);
                                // binary search on sorted list
                                ListMethods.binaryPhoneNumberSearch(contactList, searchPhoneNumber);
                            }
                            // ask the user if they would like to perform another search
                            doAgainChoice = InputOutput.getValidInteger(searchAgainMessage, doAgainMin, doAgainMax);
                        } while (doAgainChoice == 1);
                        break;
                    case 4:
                        do
                        {
                            // add a new contact
                            newFirstName = InputOutput.getString(getFirstNameMessage, "First Name");
                            newMiddleName = InputOutput.getString(getMiddleNameMessage, "Middle Name");
                            newLastName = InputOutput.getString(getLastNameMessage, "Last Name");
                            newContactType = InputOutput.getValidInteger(getContactTypeMessage, searchContactMin, searchContactMax);
                            newPhoneNumber = InputOutput.getValidLong(getPhoneNumberMessage, phoneNumberMin, phoneNumberMax);
                            newEmail = InputOutput.getString(getEmailMessage, "E-Mail");
                            contactList.Add(new contact(newFirstName, newMiddleName, newLastName, newContactType,
                                                        newPhoneNumber, newEmail));
                            // ask the user if they would like to add another contact
                            doAgainChoice = InputOutput.getValidInteger(addAgainMessage, doAgainMin, doAgainMax);
                        } while (doAgainChoice == 1);
                        break;
                    case 5:
                        do
                        {
                            // delete a contact
                            ListMethods.displayListWithIndex(contactList);
                            whoToDelete = InputOutput.getValidInteger(deleteMessage, contactMin, contactList.Count);
                            if (whoToDelete != 0)
                            {
                                // convert response to index number
                                deleteIndex = whoToDelete - 1;
                                // display selected contact for confirmation
                                Console.WriteLine();// break
                                ListMethods.displayContact(contactList, deleteIndex);
                                deleteConfirm = InputOutput.getValidInteger(deleteConfirmMessage, deleteConfirmMin, deleteConfirmMax);
                                if (deleteConfirm == 1)
                                {
                                    contactList.RemoveAt(deleteIndex);
                                    Console.WriteLine("\nContact was deleted.");
                                }
                                else
                                {
                                    Console.WriteLine("\nContact was not deleted.");
                                }
                            }
                            // ask the user if they would like to delete another contact
                            doAgainChoice = InputOutput.getValidInteger(deleteAgainMessage, doAgainMin, doAgainMax);
                        } while (doAgainChoice == 1);
                        break;
                    case 6:
                        do
                        {
                            // modify a contact
                            ListMethods.displayListWithIndex(contactList);
                            whoToModify = InputOutput.getValidInteger(modifyMessage, contactMin, contactList.Count);
                            if (whoToModify != 0)
                            {
                                // convert responsoe to index number
                                modifyIndex = whoToModify - 1;
                                Console.WriteLine();// break
                                // displays the selected contact so the user can confirm their selection before moving on
                                ListMethods.displayContact(contactList, modifyIndex);
                                Console.WriteLine();// break
                                // ask the user what property they would like to modify
                                whatToModify = InputOutput.getValidInteger(whatToModifymessage, modifyMin, modifyMax);
                                // modify the chosen property
                                switch (whatToModify)
                                {
                                    case 1:
                                        // modify first name
                                        newFirstName = InputOutput.getString(getFirstNameMessage, "First Name");
                                        contactList[modifyIndex].firstName = newFirstName;
                                        break;
                                    case 2:
                                        // modify middle name
                                        newMiddleName = InputOutput.getString(getMiddleNameMessage, "Middle Name");
                                        contactList[modifyIndex].middleName = newMiddleName;
                                        break;
                                    case 3:
                                        // modify last name
                                        newLastName = InputOutput.getString(getLastNameMessage, "Last Name");
                                        contactList[modifyIndex].lastName = newLastName;
                                        break;
                                    case 4:
                                        // modify contact type
                                        newContactType = InputOutput.getValidInteger(getContactTypeMessage, searchContactMin, searchContactMax);
                                        contactList[modifyIndex].contactType = newContactType;
                                        break;
                                    case 5:
                                        // modify phone number
                                        newPhoneNumber = InputOutput.getValidLong(getPhoneNumberMessage, phoneNumberMin, phoneNumberMax);
                                        contactList[modifyIndex].phoneNumber = newPhoneNumber;
                                        break;
                                    case 6:
                                        // modify e-mail
                                        newEmail = InputOutput.getString(getEmailMessage, "E-Mail address");
                                        contactList[modifyIndex].emailAddress = newEmail;
                                        break;
                                    default:
                                        // modify nothing
                                        Console.WriteLine(modifyNothingMessage);
                                        break;
                                }
                            }
                            // ask the user if they would like to modify another contact
                            doAgainChoice = InputOutput.getValidInteger(modifyAgainMessage, doAgainMin, doAgainMax);
                        } while (doAgainChoice == 1);
                        break;
                    default:
                        // write current list to file
                        FileWrite.writeContacts(STR_NEWCONTACT_FILE, contactList);
                        Console.WriteLine(saveAndQuitMessage);
                        break;
                }
            } while (mainMenuChoice != 7); // end of post-test loop
            // keep console window open
            Console.ReadLine();
        }
    }
}
