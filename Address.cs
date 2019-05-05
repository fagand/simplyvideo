using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoClubHire
{
    /// <summary>
    /// Address class storing variables used to create an address
    /// </summary>
    [Serializable]
    public class Address
    {
        /// <summary>
        /// private variable storing street for the member.
        /// </summary>
        private string street;
        /// <summary>
        /// private variable storing town for member.
        /// </summary>
        private string town;
        /// <summary>
        /// private variable storing postcode for member.
        /// </summary>
        private string postcode;
        /// <summary>
        /// public property storing Street for the members address.
        /// read/write property for street
        /// set method has no protection
        /// </summary>
        public string Street
        {
            get { return street; }
            set { street = value; }
        }
        /// <summary>
        /// Public property storing Town for the members address.
        /// read/write property for town
        /// set method has no protection
        /// </summary>
        public string Town
        {
            get { return town; }
            set { town = value; }
        }
        /// <summary>
        /// public property storing Postcode for the members address.
        /// read/write property for postcode
        /// set method has no protection
        /// </summary>
        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        /// <summary>
        /// Overridden ToString method.
        /// </summary>
        /// <returns>String representation of Address</returns>
        public override string ToString()
        {
            string strout;
            strout = Street + "\n" + Town + "\n" + Postcode;
            return strout;
        }
    }//end of class
}
