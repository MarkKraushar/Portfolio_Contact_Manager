//Name: Mark Kraushar
//Date: Dec 5, 2011
//File: contact.cs
//Purpose: define the contact object
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioContactManager
{
    class contact
    {
        // fields
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private int _contactType;
        private long _phoneNumber;
        private string _emailAddress;

        // properties
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string middleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public int contactType
        {
            get { return _contactType; }
            set { _contactType = value; }
        }
        public long phoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string emailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }


        // constructors
        // default contact
        public contact()
        {
            _firstName = "default";
            _middleName = "default";
            _lastName = "default";
            _contactType = -1;
            _phoneNumber = -1;
            _emailAddress = "default";
        }
        // non-default contact
        public contact(string firstName,
                       string middleName,
                       string lastName,
                       int contactType,
                       long phoneNumber,
                       string emailAddress)
        {
            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;
            _contactType = contactType;
            _phoneNumber = phoneNumber;
            _emailAddress = emailAddress;
        }
    }
}
