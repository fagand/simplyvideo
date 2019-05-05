using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SimpleVideoClubHire;

namespace GradedUnitWPF
{
    /// <summary>
    /// Interaction logic for AddMember.xaml
    /// Public class creating a window for adding a member to the library
    /// </summary>
    public partial class AddMember : Window
    {
        /// <summary>
        /// Creating Library variable
        /// </summary>
        private Library thelib;
        /// <summary>
        /// Default constructor
        /// Initializing component and creating an instance of the library.
        /// </summary>
        public AddMember()
        {
            InitializeComponent();
            thelib = Library.Instance;
            textBlockID.Text = ("New Member ID: " + (thelib.MembersProp.Count + 1).ToString());
        }
        /// <summary>
        /// When the textbox gets focus and if has "First Name" in it, it will clear the string and empty the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            textFirstName.Text = textFirstName.Text == "First Name" ? string.Empty : textFirstName.Text;
        }
        /// <summary>
        /// When the text box looses focus and if it is empty it sets the text to a string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            textFirstName.Text = textFirstName.Text == string.Empty ? "First Name" : textFirstName.Text;
        }
        /// <summary>
        /// When the textbox gets focus and if has "Last Name" in it, it will clear the string and empty the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            textLastName.Text = textLastName.Text == "Last Name" ? string.Empty : textLastName.Text;
        }
        /// <summary>
        /// When the text box looses focus and if it is empty it sets the text to a string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            textLastName.Text = textLastName.Text == string.Empty ? "Last Name" : textLastName.Text;
        }
        /// <summary>
        /// Cancel button for returning to the main menu
        /// User has a message prompt to confirm he wants to leave current screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "SVCH | Member Input",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                e.Handled = false;
            }
            else
            {
                this.Close();
                this.Owner.Show();
            }
        }
        /// <summary>
        /// When textbox gets focus it removes the current text and saves whatever is typed in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textStreet_GotFocus(object sender, RoutedEventArgs e)
        {
            textStreet.Text = textStreet.Text == "Street" ? string.Empty : textStreet.Text;
        }
        /// <summary>
        /// When the text box looses focus it sets its contents to "Street" if unless something has been input by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textStreet_LostFocus(object sender, RoutedEventArgs e)
        {
            textStreet.Text = textStreet.Text == string.Empty ? "Street" : textStreet.Text;
        }
        /// <summary>
        /// When textbox gets focus it removes the current text and saves whatever is typed in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textTown_GotFocus(object sender, RoutedEventArgs e)
        {
            textTown.Text = textTown.Text == "Town" ? string.Empty : textTown.Text;
        }
        /// <summary>
        /// When the text box looses focus it sets its contents to "Town" if unless something has been input by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textTown_LostFocus(object sender, RoutedEventArgs e)
        {
            textTown.Text = textTown.Text == string.Empty ? "Town" : textTown.Text;
        }
        /// <summary>
        /// When textbox gets focus it removes the current text and saves whatever is typed in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textPostcode_GotFocus(object sender, RoutedEventArgs e)
        {
            textPostcode.Text = textPostcode.Text == "Postcode" ? string.Empty : textPostcode.Text;
        }
        /// <summary>
        /// When the text box looses focus it sets its contents to "Postcode" if unless something has been input by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textPostcode_LostFocus(object sender, RoutedEventArgs e)
        {
            textPostcode.Text = textPostcode.Text == string.Empty ? "Postcode" : textPostcode.Text;
        }
        /// <summary>
        /// When textbox gets focus it removes the current text and saves whatever is typed in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            textPhone.Text = textPhone.Text == "Phone Number" ? string.Empty : textPhone.Text;
        }
        /// <summary>
        /// When the text box looses focus it sets its contents to "Phone number" if unless something has been input by the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            textPhone.Text = textPhone.Text == string.Empty ? "Phone Number" : textPhone.Text;
        }
        /// <summary>
        /// When the submit button is pressed
        /// User is asked to confirm adding member, if they accept
        /// A new member is added to the library via the addMember method
        /// If not they are returned to the add member window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (memberValidate() == true)
            {
                thelib.addMember(textFirstName.Text, textLastName.Text, textPhone.Text, textStreet.Text, textTown.Text, textPostcode.Text);
                MessageBoxResult result = MessageBox.Show("Member " + textFirstName.Text + " " + textLastName.Text + " added.\nReturning to main menu, press cancel to return and enter another member"
                    , "Member Added", MessageBoxButton.OKCancel);
                if (result != MessageBoxResult.OK)
                {
                    e.Handled = false;
                    textFirstName.Text = "First Name";
                    textLastName.Text = "Last Name";
                    textStreet.Text = "Street";
                    textTown.Text = "Town";
                    textPostcode.Text = "Postcode";
                    textPhone.Text = "Phone Number";
                }
                else
                {
                    this.Close();
                    this.Owner.Show();
                }
            }
        }
        /// <summary>
        /// Validation for the textboxes of add member
        /// Used to make sure the text input into the text boxes is acceptable by the addMember method
        /// Returns an error message if not valid.
        /// </summary>
        /// <returns>True bool if all validation is passed</returns>
        private bool memberValidate()
        {
            if (textFirstName.Text.Contains("First Name") || textFirstName.Text.Length < 1)
            {
                MessageBox.Show("First Name field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            if (textLastName.Text == "Last Name" || textLastName.Text.Length < 1)
            {
                MessageBox.Show("Last Name field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            if (textStreet.Text == "Street" || textStreet.Text.Length < 1)
            {
                MessageBox.Show("Street field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            if (textTown.Text == "Town" || textTown.Text.Length < 1)
            {
                MessageBox.Show("Town field cannont be empty", "SVHC | Validation Error");
                return false;
            }
            if (textPostcode.Text == "Postcode" || textPostcode.Text.Length < 6 || textPostcode.Text.Length > 7)
            {
                MessageBox.Show("Postcode field must be between 6 and 7 characters", "SVHC | Validation Error");
                return false;
            }
            if (textPhone.Text == "Phone Number" || textPhone.Text.Length < 1)
            {
                MessageBox.Show("Phone Number field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            long parsedValue;
            if (!long.TryParse(textPhone.Text, out parsedValue))
            {
                MessageBox.Show("Please enter numbers only for phone number", "SVHC | Validation Error");
                return false;
            }

            // Additional Validation > 40 characters
            if (textFirstName.Text.Length > 20)
            {
                MessageBox.Show("First Name has too many characters please try again using less characters", "SVHC | Validation Error");
                return false;
            }
            if (textLastName.Text.Length > 20)
            {
                MessageBox.Show("Last Name has too many characters please try again using less characters", "SVHC | Validation Error");
                return false;
            }
            if (textStreet.Text.Length > 30)
            {
                MessageBox.Show("Street field has too many characters please try again using less characters", "SVHC | Validation Error");
                return false;
            }
            if (textTown.Text.Length > 20)
            {
                MessageBox.Show("Town field has too many characters please try again using less characters", "SVHC | Validation Error");
                return false;
            }
            if (textPhone.Text.Length > 15)
            {
                MessageBox.Show("Phone Number has too many characters please try again using less characters", "SVHC | Validation Error");
                return false;
            }
            // End of additional validation

            return true;
        }
        /// <summary>
        /// If the enter key is pressed in the final input field 
        /// the details are submitted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnSubmit_Click(sender, e);
            }
        }
        /// <summary>
        /// When the window closes it shows the previous window (Main Window)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
    }
}// end of class
