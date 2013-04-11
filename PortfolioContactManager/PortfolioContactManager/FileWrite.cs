//Name: Mark Kraushar
//Date: Dec 5, 2011
//File: contact.cs
//Purpose: write contacts to a file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PortfolioContactManager
{
    class FileWrite
    {
        public static void writeContacts(string contactsFile, List<contact> contactList)
        {
            // create an instance of streamwriter
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(contactsFile, false);
                {
                    foreach (contact contactEx in contactList)
                    {
                        // write to the file
                        writer.Write(contactEx.firstName + ",");
                        writer.Write(contactEx.middleName + ",");
                        writer.Write(contactEx.lastName + ",");
                        writer.Write(contactEx.contactType + ",");
                        writer.Write(contactEx.phoneNumber + ",");
                        writer.WriteLine(contactEx.emailAddress);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error {0}", ex.Message);
            }
            finally
            {
                writer.Close();
                writer.Dispose();
            }
        }
    }
}