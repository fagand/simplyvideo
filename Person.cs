using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoClubHire
{
    [Serializable]
    /// <summary>
    /// Person class used for storing members information
    /// Last edited 20/02 by David Fagan
    /// </summary>
    public class Person
    {
        protected static int ID = 1;
        private string firstName;
        private string lastName;
        private Address address;
        private string phoneNo;
        /// <summary>
        /// Public property storing first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        /// <summary>
        /// Public property storing last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        /// <summary>
        /// Read only accessor method for address.
        /// </summary>
        public Address Address
        {
            get { return address; }
        }
        /// <summary>
        /// public property storign the phone number of the member
        /// </summary>
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
        /// <summary>
        /// Public property storing the person ID
        /// </summary>
        public int IDProp
        {
            get { return ID; }
            set { ID = value; }
        }
        /// <summary>
        /// Setter method for address
        /// Has no protection 
        /// </summary>
        /// <param name="street">Members street</param>
        /// <param name="twn">Members town</param>
        /// <param name="pc">Members postcode</param>
        public void setAddress(string street, string twn, string pc)
        {
            address.Street = street;
            address.Town = twn;
            address.Postcode = pc;
        }
        /// <summary>
        /// Default constructor for creating a person.
        /// </summary>
        public Person()
        {
            address = new Address();
            setAddress("Unknown", "unknown", "unknown");
            firstName = "No name";
            PhoneNo = "0";
        }
        /// <summary>
        /// Constructor class taking in a first name, last name and Phone no.
        /// </summary>
        /// <param name="strfirstname">first Name.</param>
        /// <param name="strlastname">last name</param>
        /// <param name="intphoneNo">Phone no.</param>
        public Person(string strfirstname, string strlastname, string intphoneNo)
        {
            address = new Address();
            setAddress("Unknown", "unknown", "unknown");
            PhoneNo = intphoneNo;
            firstName = strfirstname;
            lastName = strlastname;
        }
        /// <summary>
        /// Constructor class taking in first name, last name, phoneno, street, town and postcode.
        /// </summary>
        /// <param name="strfirstname">First name.</param>
        /// <param name="strlastname">Last name</param>
        /// <param name="intphoneno">Phone No.</param>
        /// <param name="strstreet">Street.</param>
        /// <param name="strtown">Town.</param>
        /// <param name="strpostcode">Postcode.</param>
        /// <param name="membID">Member ID</param>
        public Person (string strfirstname, string strlastname, string intphoneno, string strstreet, string strtown, string strpostcode,int membID)
        {
            address = new Address();
            setAddress(strstreet, strtown, strpostcode);
            PhoneNo = intphoneno;
            firstName = strfirstname;
            lastName = strlastname;
        }
        /// <summary>
        /// Default ToString for displaying the person in a string
        /// </summary>
        /// <returns>Person by their first name, last name and phone number</returns>
        public override string ToString()
        {
            string strout = firstName + " " + lastName + " " + PhoneNo;
            strout = strout + address;
            return strout;
        }
    }//end of class
}
