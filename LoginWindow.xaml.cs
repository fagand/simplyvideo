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
	/// Interaction logic for LoginWindow.xaml
	/// Public class that creates the initial log in window
	/// That allows the user to enter the system
	/// Failure to enter valid credentials will result in the system closing.
	/// </summary>
	public partial class LoginWindow : Window
	{
		/// <summary>
		/// Private variable storing the user
		/// </summary>
		private string user;
		/// <summary>
		/// private int storing the count of login attempts
		/// </summary>
        private int count = 0;
		/// <summary>
		/// Default constructor
		/// initializing the window
		/// giving focus to the username field allowing the 
		/// user to type directly without any interaction
		/// </summary>
        public LoginWindow()
		{
			InitializeComponent();
            txtUser.Focus();
            //bypass();
        }
		/// <summary>
		/// Creates a new staff object
		/// adds staff from the staff object
		/// adds managers from the staff object
		/// If the user inputs correct credentials
		/// main window is shown
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Staff staff = new Staff();
            staff.addStaffDic();
            staff.addManagersDic();
            bool result = staff.loginUsingDic(txtUser.Text, txtPass.Password);
            user = txtUser.Text;
            if (validation() == true)
            {
                if (result == true)
                {
                    MainWindow mainwindow = new MainWindow();
                    mainwindow.Owner = this;
                    this.Hide();
                    mainwindow.Show();
                }
                else
                {
                    MessageBox.Show("Username or password incorrect\nTry again", "SVHC | Not valid", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtPass.Password = "";
                    count++;
                }
                if (count > 2)
                {
                    MessageBox.Show("You have entered your details incorrectly too many times\nThe system will now exit",
                        "SVHC | Login Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                    this.Close();
                }
            }
        }
		/// <summary>
		/// Method put in for testing purposes
		/// of bypassing the login screen
		/// </summary>
        private void bypass()
        {
            this.Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
        }
		/// <summary>
		/// Property storing the staff name
		/// </summary>
        public string StaffName
        {
            get { return user; }
        }
		/// <summary>
		/// Closes the system completely
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
		/// <summary>
		/// If the enter key is pressed
		/// while in the password textbox 
		/// the input details are submitted without any mouse clicks
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click(sender, e);
            }
        }
        private bool validation()
        {
            if (txtUser.Text.Length < 1)
            {
                MessageBox.Show("Username field is empty, please enter username and try again", "SVHC | Initial Login Window Validation Error");
                return false;
            }
            if (txtUser.Text.Length > 12)
            {
                MessageBox.Show("Username field only allows 12 characters, please enter username and try again", "SVHC | Initial Login Window Validation Error");
                return false;
            }
            if (txtPass.Password.Length < 1)
            {
                MessageBox.Show("Password field is empty, please enter password and try again", "SVHC | Initial Login Window Validation Error");
                return false;
            }
            if (txtPass.Password.Length > 20)
            {
                MessageBox.Show("Password field only allows 20 characters, please enter password and try again", "SVHC | Initial Login Window Validation Error");
                return false;
            }
            return true;
        }
    }// end of class
}
