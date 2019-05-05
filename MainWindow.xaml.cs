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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SimpleVideoClubHire;

namespace GradedUnitWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Public class creating the main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// private Library attribute pulling in methods for executing
        /// </summary>
        private Library SVHCLibrary;
        /// <summary>
        /// Private datafile attribute used for storing the library data to a datafile
        /// </summary>
        private Datafile datafile = new Datafile();
        /// <summary>
        /// private int taking in the member ID as a string and converting to
        /// an int within the method
        /// </summary>
        private int input;
        /// <summary>
        /// Default constructor initializing the main window
        /// Creating an instance of the library
        /// Loading in from the datafile if there are no members
        /// Sets the item source for the combobox
        /// Defaults the dispaly to noMoreInfo for simplified stock display
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            SVHCLibrary = Library.Instance;
			if (SVHCLibrary.members.Count <= 0)
			{
				SVHCLibrary.populate();
				try
				{
                    datafile.load();
                }
				catch (Exception e)
				{ MessageBox.Show("Unable to load file, report to administrator\nError: " + e.Message); }
			}
			comboBoxSearchBar.ItemsSource = SVHCLibrary.SearchBarSelect;
            searchBox.Text = "";
            txtSortGuide.Text = "";
            SVHCLibrary.noMoreInfo();
        }
        /// <summary>
        /// Button for navigating to the rental window
        /// Hides the main window and clears the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRental_Click(object sender, RoutedEventArgs e)
        {
            RentalWindow rentalWindow = new RentalWindow();
            rentalWindow.Owner = this;
            this.Hide();
            rentalWindow.Show();
            txtOutput.Clear();
        }
        /// <summary>
        /// Button for adding member
        /// Opens add member window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMember_Click(object sender, RoutedEventArgs e)
        {
            AddMember newMember = new AddMember();
            newMember.Owner = this;
            this.Hide();
            newMember.Show();
            txtOutput.Clear();
        }
        /// <summary>
        /// Button for adding new film
        /// Opens new window for adding stock
        /// with radio button setup for adding film
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFilm_Click(object sender, RoutedEventArgs e)
        {
            AddStock newStock = new AddStock();
            newStock.Owner = this;
            this.Hide();
            newStock.Show();
            txtOutput.Clear();
        }
        /// <summary>
        /// Button for adding game
        /// Opens new window for adding stock
        /// With radio button setup for adding game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddGame_Click(object sender, RoutedEventArgs e)
        {
            AddStock newStock = new AddStock();
            newStock.Owner = this;
            this.Hide();
            newStock.radioButtonGame.IsChecked = true;
            newStock.Title = "Add Game";
            newStock.Show();
            txtOutput.Clear();
        }
        /// <summary>
        /// Method for replacing text in the searchbox
        /// depending on what selection is chosen in the combobox
        /// If the user clicks in the textbox and it contains the defined text
        /// It will be cleared allowing the user to type into the search bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (comboBoxSearchBar.SelectedIndex == -1)
            {
                MessageBox.Show("Please select search criteria from drop down menu on the left", "SVHC | Search box not active", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                searchBox.IsReadOnly = true;
            }
            if (comboBoxSearchBar.SelectedIndex == 0)
            {
                searchBox.IsReadOnly = false;
                searchBox.Text = searchBox.Text == "Search for member by their last name" ? string.Empty : searchBox.Text;
                searchBox.FontStyle = FontStyles.Normal;
            }
            if (comboBoxSearchBar.SelectedIndex == 1)
            {
                searchBox.IsReadOnly = false;
                searchBox.Text = searchBox.Text == "Search for stock by title" ? string.Empty : searchBox.Text;
                searchBox.FontStyle = FontStyles.Normal;
            }
            //if (comboBoxSearchBar.SelectedIndex == 1)
            //{
            //    searchBox.Text = searchBox.Text == "Search for film" ? string.Empty : searchBox.Text;
            //    searchBox.FontStyle = FontStyles.Normal;
            //}
            //if (comboBoxSearchBar.SelectedIndex == 2)
            //{
            //    searchBox.Text = searchBox.Text == "Search for game" ? string.Empty : searchBox.Text;
            //    searchBox.FontStyle = FontStyles.Normal;
            //}
            //if (comboBoxSearchBar.SelectedIndex == 3)
            //{
            //    searchBox.Text = searchBox.Text == "Search all stock" ? string.Empty : searchBox.Text;
            //    searchBox.FontStyle = FontStyles.Normal;
            //}
            if (comboBoxSearchBar.SelectedIndex == 2)
            {
                searchBox.IsReadOnly = false;
                searchBox.Text = searchBox.Text == "Search for member by their ID" ? string.Empty : searchBox.Text;
                searchBox.FontStyle = FontStyles.Normal;
            }
            if (comboBoxSearchBar.SelectedIndex == 3)
            {
                searchBox.IsReadOnly = false;
                searchBox.Text = searchBox.Text == "Search for member by their first name" ? string.Empty : searchBox.Text;
                searchBox.FontStyle = FontStyles.Normal;
            }
        }
        /// <summary>
        /// Method for replacing text in the searchbox
        /// depending on what selection is chosen in the combobox
        /// If textbox is clear and the user takes the focus from the search bar
        /// The text that was removed before will be put back into the search bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (comboBoxSearchBar.SelectedIndex == 0)
            {
                searchBox.Text = searchBox.Text == string.Empty ? "Search for member by their last name" : searchBox.Text;
                searchBox.FontStyle = FontStyles.Normal;
            }
            if (comboBoxSearchBar.SelectedIndex == 1)
            {
                searchBox.Text = searchBox.Text == string.Empty ? "Search for stock by title" : searchBox.Text;
                searchBox.FontStyle = FontStyles.Normal;
            }
            //if (comboBoxSearchBar.SelectedIndex == 1)
            //{
            //    searchBox.Text = searchBox.Text == string.Empty ? "Search for film" : searchBox.Text;
            //    searchBox.FontStyle = FontStyles.Normal;
            //}
            //if (comboBoxSearchBar.SelectedIndex == 2)
            //{
            //    searchBox.Text = searchBox.Text == string.Empty ? "Search for game" : searchBox.Text;
            //    searchBox.FontStyle = FontStyles.Normal;
            //}
            //if (comboBoxSearchBar.SelectedIndex == 3)
            //{
            //    searchBox.Text = searchBox.Text == string.Empty ? "Search all stock" : searchBox.Text;
            //    searchBox.FontStyle = FontStyles.Normal;
            //}
            if (comboBoxSearchBar.SelectedIndex == 2)
            {
                searchBox.Text = searchBox.Text == string.Empty ? "Search for member by their ID" : searchBox.Text;
                searchBox.FontStyle = FontStyles.Normal;
            }
            if (comboBoxSearchBar.SelectedIndex == 3)
            {
                searchBox.Text = searchBox.Text == string.Empty ? "Search for member by their first name" : searchBox.Text;
                searchBox.FontStyle = FontStyles.Normal;
            }
            //old code
            //searchBox.Text = searchBox.Text == string.Empty ? "Search member by their last name" : searchBox.Text;
            //searchBox.FontStyle = FontStyles.Italic;
        }
        /// <summary>
        /// When the search button is clicked
        /// Depending on what combo box selection is chosen
        /// A search method will be carried out
        /// With results in the text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxSearchBar.SelectedIndex == 0)
            {
                try
                {
                    txtOutput.Text = SVHCLibrary.searchMembersByLastName(searchBox.Text);
                    searchBox.Text = "Search for member by their last name";
                }
                catch (Exception)
                {
                    if (searchBox.Text == "Search for member by their last name")
                        txtOutput.Text = "Error, search field is empty try again";
                    else
                    {
                        txtOutput.Text = (searchBox.Text + " not found, please try again using last name only.");
                        searchBox.Text = "Search for member by their last name";
                    }
                }
            }
            if (comboBoxSearchBar.SelectedIndex == 1)
            {
                try
                {
                    txtOutput.Text = SVHCLibrary.searchStock(searchBox.Text);
                    searchBox.Text = "Search for stock by title";
                }
                catch (Exception)
                {
                    if (searchBox.Text == "Search for stock by title")
                        txtOutput.Text = SVHCLibrary.getStock();
                    else
                    {
                        txtOutput.Text = (searchBox.Text + " not found, please try again");
                        searchBox.Text = "Search for stock by title";
                    }
                }
            }
            //if (comboBoxSearchBar.SelectedIndex == 2)
            //{
            //    //Was search for game.
            //}
            //if (comboBoxSearchBar.SelectedIndex == 3)
            //{
            //    searchBox.Text = "Search all stock";
            //    searchBox.FontStyle = FontStyles.Italic;
            //}
            if (comboBoxSearchBar.SelectedIndex == 2)
            {
                try
                {
                    if (!int.TryParse(searchBox.Text, out int result))
                    {
                        MessageBox.Show("Please enter valid data into the search bar, number(s) only", "SVHC | Member ID Search Error");
                    }
                    else
                    {
                        txtOutput.Text = SVHCLibrary.SearchMembersByID(int.Parse(searchBox.Text));
                        input = int.Parse(searchBox.Text);
                        searchBox.Text = "Search for member by their ID";
                    }
                }
                catch (Exception)
                {
                    txtOutput.Text = ("A member with ID: " + searchBox.Text + " not found, please try again using valid ID.\n\nNote: \tthere are a total of "+ SVHCLibrary.MembersProp.Count + " members.");
                    searchBox.Text = "Search for member by their ID";
                }
            }
            if (comboBoxSearchBar.SelectedIndex == 3)
            {
                try
                {
                    txtOutput.Text = SVHCLibrary.searchMembersByFirstName(searchBox.Text);
                    searchBox.Text = "Search for member by their first name";
                }
                catch (Exception)
                {
                    if (searchBox.Text == "Search for member by their first name")
                        txtOutput.Text = "Error, search field is empty try again";
                    else
                    {
                        txtOutput.Text = (searchBox.Text + " not found, please try again");
                        searchBox.Text = "Search for member by their first name";
                    }
                }
            }
        }
        /// <summary>
        /// When the window is closed the system is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            //this.Close();
			Environment.Exit(0);
        }
        /// <summary>
        /// Method for displaying the members in the textbox
        /// Using the list members button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListMembers_Click(object sender, RoutedEventArgs e)
        {
            SVHCLibrary.sortMembersByID();
            //txtOutput.FontSize = 12;
            txtOutput.Text = SVHCLibrary.getMembers();
        }
        /// <summary>
        /// Method for displaying films stock in the textbox
        /// Using the list films button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListFilms_Click(object sender, RoutedEventArgs e)
        {
            SVHCLibrary.sortStockByID();
            //txtOutput.FontSize = 10;
            txtOutput.Text = SVHCLibrary.getFilms();
        }
        /// <summary>
        /// Method for displaying the games stock in the text box
        /// Using the list games button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListGames_Click(object sender, RoutedEventArgs e)
        {
            SVHCLibrary.sortStockByID();
            //txtOutput.FontSize = 10;
            txtOutput.Text = SVHCLibrary.getGames();
        }
        /// <summary>
        /// As the window is closing data is stored to the datafile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
			//{ SVHCLibrary.createDataFile(); SVHCLibrary.printStock(); }
			{
                SVHCLibrary.printStock();
                datafile.save();
            }
            catch (Exception ex)
            { MessageBox.Show("Unable to save to file, please contact administrator\nError: " + ex.Message); }
        }
        /// <summary>
        /// If the combo box selection is changed the search bar
        /// text is updated to mirror the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSearchBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtOutput.Clear();
            if (comboBoxSearchBar.SelectedIndex == 0)
            {
                searchBox.Text = "Search for member by their last name";
                searchBox.FontStyle = FontStyles.Italic;
                txtSortGuide.Foreground = Brushes.Red;
                txtSortGuide.Text = "Click To Sort By Last Name";
                sortButton.BorderBrush = Brushes.Red;
            }
            //if (comboBoxSearchBar.SelectedIndex == 1)
            //{
            //    searchBox.Text = "Search for film";
            //    searchBox.FontStyle = FontStyles.Italic;
            //}
            if (comboBoxSearchBar.SelectedIndex == 1)
            {
                searchBox.Text = "Search for stock by title";
                searchBox.FontStyle = FontStyles.Italic;
                txtSortGuide.Foreground = Brushes.Red;
                txtSortGuide.Text = "Click To Sort By Title";
                sortButton.BorderBrush = Brushes.Red;

            }

            //if (comboBoxSearchBar.SelectedIndex == 2)
            //{
            //    searchBox.Text = "Search for game";
            //    searchBox.FontStyle = FontStyles.Italic;
            //}
            //if (comboBoxSearchBar.SelectedIndex == 3)
            //{
            //    searchBox.Text = "Search all stock";
            //    searchBox.FontStyle = FontStyles.Italic;
            //}
            if (comboBoxSearchBar.SelectedIndex == 2)
            {
                searchBox.Text = "Search for member by their ID";
                searchBox.FontStyle = FontStyles.Italic;
                txtSortGuide.Foreground = Brushes.Red;
                txtSortGuide.Text = "Click To Sort By Member ID";
                sortButton.BorderBrush = Brushes.Red;
            }
            if (comboBoxSearchBar.SelectedIndex == 3)
            {
                searchBox.Text = "Search for member by their first name";
                searchBox.FontStyle = FontStyles.Italic;
                txtSortGuide.Foreground = Brushes.Red;
                txtSortGuide.Text = "Click To Sort By First Name";
                sortButton.BorderBrush = Brushes.Red;
            }
        }
        /// <summary>
        /// Opens the login window to enter the edit stock
        /// Only accessible to management
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editStockButton_Click(object sender, RoutedEventArgs e)
        {
			LoginWindow3 login3 = new LoginWindow3();
			login3.Owner = this;
			this.Hide();
			login3.Show();
		}
        /// <summary>
        /// Sorts the stock or members depending on
        /// what selection has been chosing in the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxSearchBar.SelectedIndex == 0)
            {
                MessageBoxResult result = MessageBox.Show("By clicking ok you will clear the content box and display members sorted by their last name\n\nClick Ok to continue and display the results", "SVHC | Sort members by last name",
                MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result != MessageBoxResult.OK)
                {
                    e.Handled = false;
                    txtOutput.Clear();
                }
                else
                {
                    txtOutput.Text = "Members sorted by their last name: \n" + SVHCLibrary.sortMembersByName();
                }
            }
            if (comboBoxSearchBar.SelectedIndex ==1)
            {
                MessageBoxResult result = MessageBox.Show("By clicking ok you will clear the content box and display stock sorted its title\n\nClick Ok to continue and display the results", "SVHC | Sort stock by its title",
                MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result != MessageBoxResult.OK)
                {
                    e.Handled = false;
                    txtOutput.Clear();
                }
                else
                {
                    txtOutput.Text = "Stock sorted by its title: \n" + SVHCLibrary.sortStock();
                }
            }
            if (comboBoxSearchBar.SelectedIndex == 2)
            {
                MessageBoxResult result = MessageBox.Show("By clicking ok you will clear the content box and display members sorted by their ID Number\n\nClick Ok to continue and display the results", "SVHC | Sort members by their ID number",
                MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result != MessageBoxResult.OK)
                {
                    e.Handled = false;
                    txtOutput.Clear();
                }
                else
                {
                    txtOutput.Text = "Members sorted by their ID Number: \n" + SVHCLibrary.sortMembersByID();
                }
            }
            if (comboBoxSearchBar.SelectedIndex == 3)
            {
                MessageBoxResult result = MessageBox.Show("By clicking ok you will clear the content box and display members sorted by their first name\n\nClick Ok to continue and display the results", "SVHC | Sort members by their first name",
                MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result != MessageBoxResult.OK)
                {
                    e.Handled = false;
                    txtOutput.Clear();
                }
                else
                {
                    txtOutput.Text = "Members sorted by their first name: \n" + SVHCLibrary.sortMembersByNameFirst();
                }
            }
        }
        /// <summary>
        /// Opens the login window to access the discounts menu
        /// Only accessible to management 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setDiscountButton_Click(object sender, RoutedEventArgs e)
        {
			LoginWindow2 login2 = new LoginWindow2();
			login2.Owner = this;
			this.Hide();
			login2.Show();
		}
        /// <summary>
        /// Late returns search button
        /// TBC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void lateReturnsButton_Click(object sender, RoutedEventArgs e)
		{
            MessageBox.Show("Not availalbe in this version", "SVHC | Not Available", MessageBoxButton.OK,MessageBoxImage.Exclamation);
		}
        /// <summary>
        /// Method for showing more information on the stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoreInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtOutput.Text = SVHCLibrary.moreInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Error in displaying more info","SVHC | More Info Error");
            }
        }
        /// <summary>
        /// Method for simplifying the information displayed on the stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLessInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                txtOutput.Text = SVHCLibrary.noMoreInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Error in hiding info", "SVHC | Less Info Error");
            }
        }
        /// <summary>
        /// If the return key is pressed in the search box 
        /// A search is performed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                searchButton_Click(sender, e);
            }
        }
    }
}
