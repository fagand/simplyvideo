using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoClubHire
{
    [Serializable]
    /// <summary>
    /// Member class ecapsulates library members
    /// extends Person class
    /// Last edited 20/02 by David Fagan
    /// </summary>
    public class Member : Person
    {
        /// <summary>
        /// private variable storing member ID
        /// </summary>
        private int memberID;
        /// <summary>
        /// Default constructor setting member ID to 0
        /// </summary>
        public Member()
        {
            memberID = 0;
        }
        /// <summary>
        /// Constructor taking in 7 variables and creating a member using them
        /// </summary>
        /// <param name="_firstname">First name</param>
        /// <param name="_lastname">Last name</param>
        /// <param name="_phoneNo">Phone number</param>
        /// <param name="_street">Street</param>
        /// <param name="_town">Town</param>
        /// <param name="_postcode">Postcode</param>
        /// <param name="_ID">Member ID</param>
        public Member(String _firstname, string _lastname, string _phoneNo, string _street, string _town, string _postcode, int _ID) : base(_firstname, _lastname, _phoneNo, _street, _town, _postcode, _ID)
        {
            //memberID = ID++;
            
            if (SimpleVideoClubHire.Library.Instance.MembersProp.Count > 0)
            {
                memberID = SimpleVideoClubHire.Library.Instance.MembersProp.Count + 1;
            }
            else
            {
                memberID = ID++;
            }

            //if (thelib.members.Count > 0)
            //{
            //    memberID = thelib.members.Count + 1;
            //}
            //else
            //{
            //    memberID = ID++;
            //}
        }
        /// <summary>
        /// Default toString for displaying the member
        /// </summary>
        /// <returns>Member ID with their First name and last name</returns>
        public override string ToString()
        {
            string strout;
            strout = ("Member ID: " + memberID + " " + FirstName + " " + LastName);
            return strout;
        }
        /// <summary>
        /// Public property storing member ID used for sorting in another class
        /// </summary>
        public int memberIDProp
        {
            get { return memberID; }
            set { memberID = value; }
        }
        public string memberLastName
        {
            get { return LastName; }
        }
        /// <summary>
        /// Public delegate used for sorting customer by their last name in the library class
        /// </summary>
        /// <param name="c1">Member 1</param>
        /// <param name="c2">Member 2</param>
        /// <returns></returns>
        public static int CompareCustomerLastName(Member m1, Member m2)
        {
            return m1.LastName.CompareTo(m2.LastName);
        }
        /// <summary>
        /// Public delegate used for sorting custoemr by their first name in a sorting method in the library class
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static int CompareCustomerFirstName(Member m1, Member m2)
        {
            return m1.FirstName.CompareTo(m2.FirstName);
        }
        /// <summary>
        /// Public delegate used for sorting customer by their ID in the library class
        /// </summary>
        /// <param name="c1">Member 1</param>
        /// <param name="c2">Member 2</param>
        /// <returns></returns>
        public static int CompareCustomerID(Member m1, Member m2)
        {
            return m1.memberIDProp.CompareTo(m2.memberIDProp);
        }
    }//end of class
}
