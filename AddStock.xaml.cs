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
    /// Interaction logic for AddWindow.xaml
    /// Public class creating window for adding stock to the library    
    ///  Uses DateTime library https://msdn.microsoft.com/en-us/library/system.datetime(v=vs.110).aspx 
    /// </summary>
    public partial class AddStock : Window
    {
        /// <summary>
        /// Private Library attribute
        /// </summary>
        private Library thelib;
        /// <summary>
        /// Default constructor
        /// Initializing the window and creating and instance of the library
        /// Default input is add film via radio button.
        /// </summary>
        public AddStock()
        {
            InitializeComponent();
            buttonClear.Opacity = 0;
            radioButtonFilm.IsChecked = true;
            thelib = Library.Instance;
            textStockID.Text = "Stock ID: " + (thelib.StockProp.Count + 1).ToString();
        }
        /// <summary>
        /// If a any of the text boxes gets focus and its text is set to either of the below
        /// It clears the textbox to empty allowing the user to enter their film/game details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (sender == null)
            {
                return;
            }
            textBox.SelectAll();
			setLabels();
			textBox.Text = textBox.Text == "Stock ID"
				|| textBox.Text == "Film Title"
				|| textBox.Text == "Certificate"
				|| textBox.Text == "Distributor"
				|| textBox.Text == "Date of Release"
				|| textBox.Text == "Cost Bracket"
				|| textBox.Text == "Platform"
				|| textBox.Text == "DVD Quantity"
				|| textBox.Text == "VHS Quantity"
				|| textBox.Text == "Description"
				|| textBox.Text == "Game Quantity"
				|| textBox.Text == "Platform"
				|| textBox.Text == "Game Title"
				|| textBox.Text == "Category"
				? string.Empty : textBox.Text;
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textStockID_LostFocus(object sender, RoutedEventArgs e)
        {
            textStockID.Text = textStockID.Text == string.Empty ? "Stock ID" : textStockID.Text;
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxTitle_LostFocus(object sender, RoutedEventArgs e)
        {
            if (radioButtonFilm.IsChecked == true)
            {
                textBoxTitle.Text = textBoxTitle.Text == string.Empty ? "Film Title" : textBoxTitle.Text;
			}
			if (radioButtonGame.IsChecked == true)
            {
                textBoxTitle.Text = textBoxTitle.Text == string.Empty ? "Game Title" : textBoxTitle.Text;
			}
		}
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCertificate_LostFocus(object sender, RoutedEventArgs e)
        {
            textBoxCertificate.Text = textBoxCertificate.Text == string.Empty ? "Certificate" : textBoxCertificate.Text;
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDistributor_LostFocus(object sender, RoutedEventArgs e)
        {
            textBoxDistributor.Text = textBoxDistributor.Text == string.Empty ? "Distributor" : textBoxDistributor.Text;
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDateOfRelease_LostFocus(object sender, RoutedEventArgs e)
        {
            textBoxDateOfRelease.Text = textBoxDateOfRelease.Text == string.Empty ? "Date of Release" : textBoxDateOfRelease.Text;
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCost_LostFocus(object sender, RoutedEventArgs e)
        {
            textBoxCost.Text = textBoxCost.Text == string.Empty ? "Cost Bracket" : textBoxCost.Text;
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPlatCat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (radioButtonFilm.IsChecked == true)
            { textBoxPlatCat.Text = textBoxPlatCat.Text == string.Empty ? "Category" : textBoxPlatCat.Text; }
            if (radioButtonGame.IsChecked == true)
            { textBoxPlatCat.Text = textBoxPlatCat.Text == string.Empty ? "Platform" : textBoxPlatCat.Text; }
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxQuantity1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (radioButtonFilm.IsChecked == true)
            { textBoxQuantity1.Text = textBoxQuantity1.Text == string.Empty ? "DVD Quantity" : textBoxQuantity1.Text; }
            if (radioButtonGame.IsChecked == true)
            { textBoxQuantity1.Text = textBoxQuantity1.Text == string.Empty ? "Game Quantity" : textBoxQuantity1.Text; }
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxQuantity2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (radioButtonFilm.IsChecked == true)
            { textBoxQuantity2.Text = textBoxQuantity2.Text == string.Empty ? "VHS Quantity" : textBoxQuantity2.Text; }
            if (radioButtonGame.IsChecked == true)
            { textBoxQuantity2.IsEnabled = false; }
        }
        /// <summary>
        /// If the text box looses focus it either returns it to the previous GotFocus text or keeps the user input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDescr_LostFocus(object sender, RoutedEventArgs e)
        {
            textBoxDescr.Text = textBoxDescr.Text == string.Empty ? "Description" : textBoxDescr.Text;
        }
        /// <summary>
        /// If the game radio button is checked
        /// The textbox contents are changed to advise the user
        /// Of what details are required for inputting a game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonGame_Checked(object sender, RoutedEventArgs e)
        {
            this.Title = "SVHC | Add Game";
            textBoxTitle.Text = "Game Title";
            textBoxPlatCat.Text = "Platform";
            textBoxQuantity1.Text = "Game Quantity";

            textBoxTitle.ToolTip = "Game Title";
            textBoxPlatCat.ToolTip = "Platform";
            textBoxQuantity1.ToolTip = "Game Quantity";
            textBoxQuantity2.IsEnabled = false;
            //textBoxQuantity2.Text = "Disabled";
            textBoxQuantity2.Opacity = 0;
        }
        /// <summary>
        /// If the game radio button is unchecked
        /// the text boxes are returned to the default 
        /// of accepting details for inputting a film
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonGame_Unchecked(object sender, RoutedEventArgs e)
        {
            this.Title = "SVHC | Add Film";
            textBoxTitle.Text = "Film Title";
            textBoxPlatCat.Text = "Category";
            textBoxQuantity1.Text = "DVD Quantity";

            textBoxTitle.ToolTip = "Film Title";
            textBoxPlatCat.ToolTip = "Category";
            textBoxQuantity1.ToolTip = "DVD Quantity";
            textBoxQuantity2.Opacity = 100;
            textBoxQuantity2.IsEnabled = true;
            //textBoxQuantity2.Text = "VHS Quantity";
        }
        /// <summary>
        /// If the cancel button is clicked the user is prompted with
        /// a message box asking them to confirm they'd like to leave
        /// the current window and return to the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "SVCH | Stock Input", 
                MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                e.Handled = false;
            }
            else
            {
                Window_Closed(sender,e);
                //this.Close();
                //this.Owner.Show();
            }
        }
        /// <summary>
        /// Depending on what radio button is checked when the submit button is
        /// pressed, the window will send a message to library with either 
        /// addfilm or addgame.
        /// The user is asked to confirm they want to add a film/game to 
        /// remind them of what type of stock they are about to add.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (radioButtonFilm.IsChecked == true)
            {
                if (stockValidation() == true)
                {
                    MessageBoxResult result = MessageBox.Show("You are about to input a film\nPlease confirm?", "SVCH | Film Input",
        MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result != MessageBoxResult.Yes)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        addFilmMethod();
                        textBoxDefaultValues();
                    }
                }
            }
            if (radioButtonGame.IsChecked == true)
            {
                if (stockValidation() == true)
                {
                    MessageBoxResult result = MessageBox.Show("You are about to input a game in stock\nPlease confirm?", "SVCH | Game Input",
                        MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result != MessageBoxResult.Yes)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        //validate
                        addGameMethod();
                        textBoxDefaultValues();
                    }
                }
            }
        }
        /// <summary>
        /// Method for setting the textboxes to their default state
        /// Depending on what radio button is active.
        /// </summary>
        public void textBoxDefaultValues()
        {
            if (radioButtonGame.IsChecked == true)
            {
                textBoxCertificate.Text = "Certificate";
                textBoxDistributor.Text = "Distributor";
                textBoxDateOfRelease.Text = "Date of Release";
                releaseDatePicker.SelectedDate = DateTime.Now;
                textBoxCost.Text = "Cost Bracket";
                textBoxDescr.Text = "Description";

                textBoxTitle.Text = "Game Title";
                textBoxPlatCat.Text = "Platform";
                textBoxQuantity1.Text = "Game Quantity";

                textBoxTitle.ToolTip = "Game Title";
                textBoxPlatCat.ToolTip = "Platform";
                textBoxQuantity1.ToolTip = "Game Quantity";
                textBoxQuantity2.IsEnabled = false;
                //textBoxQuantity2.Text = "Disabled";
                textBoxQuantity2.Opacity = 0;
            }
            if (radioButtonFilm.IsChecked == true)
            {
                textBoxCertificate.Text = "Certificate";
                textBoxDistributor.Text = "Distributor";
                textBoxDateOfRelease.Text = "Date of Release";
                releaseDatePicker.SelectedDate = DateTime.Now;
                textBoxCost.Text = "Cost Bracket";
                textBoxDescr.Text = "Description";

                textBoxTitle.Text = "Film Title";
                textBoxPlatCat.Text = "Category";
                textBoxQuantity1.Text = "DVD Quantity";
                textBoxQuantity2.Text = "VHS Quantity";
                textBoxTitle.ToolTip = "Film Title";
                textBoxPlatCat.ToolTip = "Category";
                textBoxQuantity1.ToolTip = "DVD Quantity";
                textBoxQuantity2.Opacity = 100;
                textBoxQuantity2.IsEnabled = true;
            }
        }
        /// <summary>
        /// Method for clearing all text boxes to blank.
        /// </summary>
        public void clearAllTextBoxes()
        {
            foreach (UIElement element in myGrid.Children)
            {
                TextBox textbox = element as TextBox;
                if (textbox != null)
                {
                    textbox.Text = String.Empty;
                }
            }
        }
		/// <summary>
		/// Method for adding a film to the library
		/// encased in a try catch for error handling.
		/// </summary>
        public void addFilmMethod()
        {
            DateTime releaseDate = releaseDatePicker.SelectedDate.Value;
            string strReleaseDateFilm = releaseDate.ToShortDateString();
			try
			{
				thelib.addFilm(textBoxTitle.Text, textBoxPlatCat.Text, int.Parse(textBoxQuantity1.Text),
					int.Parse(textBoxQuantity2.Text), textBoxCertificate.Text,
					int.Parse(textBoxCost.Text), textBoxDistributor.Text,
					/*textBoxDateOfRelease.Text*/ strReleaseDateFilm, textBoxDescr.Text);
				MessageBox.Show("Film " + textBoxTitle.Text + " added, fields will now be cleared", "Added", MessageBoxButton.OK, MessageBoxImage.None);
				textStockID.Text = "Stock ID: " + (thelib.StockProp.Count() + 1).ToString();
			}
			catch (Exception e)
			{
				throw new Exception("Error adding film\n" + e);
			}
        }
		/// <summary>
		/// Method for adding game to the library
		/// encased in a try catch for error handling.
		/// </summary>
        public void addGameMethod()
        {
            DateTime releaseDate = releaseDatePicker.SelectedDate.Value;
            string strReleaseDateGame = releaseDate.ToShortDateString();
			try
			{
				thelib.addGame(textBoxTitle.Text, int.Parse(textBoxQuantity1.Text), textBoxPlatCat.Text,
					textBoxCertificate.Text, int.Parse(textBoxCost.Text), textBoxDistributor.Text, strReleaseDateGame,
					/*textBoxDateOfRelease.Text,*/ textBoxDescr.Text);
				MessageBox.Show("Game " + textBoxTitle.Text + " added, fields will now be cleared", "Added", MessageBoxButton.OK, MessageBoxImage.None);
				textStockID.Text = "Stock ID: " + (thelib.StockProp.Count() + 1).ToString();
			}
			catch (Exception e)
			{
				throw new Exception("Error adding game\n" + e);
			}
        }
		/// <summary>
		/// Method used for validating stock input fields
		/// Used to make sure the fields aren't empty and that they meet
		/// the requirements for creating a stock item.
		/// </summary>
		/// <returns>Bool true if validation is passed, false if not</returns>
        private bool stockValidation()
        {
            int result;

            if (textBoxTitle.Text.Contains("Title") || textBoxTitle.Text.Length < 1)
            {
                MessageBox.Show("Title field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            if (textBoxCertificate.Text == "Certificate" || textBoxCertificate.Text.Length < 1)
            {
                MessageBox.Show("Certificate field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            else if (textBoxCertificate.Text.Length > 2)
            {
                MessageBox.Show("Certificate field must be a maximum of 2 characters\nE.G. \"PG\"", "SVHC | Validation Error");
                return false;
            }
            /*
            if (textPostcode.Text.Length < 6 || textPostcode.Text.Length > 8)
            {
                MessageBox.Show("Postcode field must be between 6 and 8 characters");
                return false;
            }
            */
            if (textBoxDistributor.Text == "Distributor" || textBoxDistributor.Text.Length < 1)
            {
                MessageBox.Show("Distributor field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            /*if (textBoxDateOfRelease.Text == "Date of Release" || textBoxDateOfRelease.Text.Length < 1)
            {
                MessageBox.Show("Date of Release field cannot be empty");
                return false;
            }
            else if (textBoxDateOfRelease.Text.Any(char.IsDigit).Equals(false))
            {
                MessageBox.Show("Please enter date of release in one of the following formats:\n\n\"2004\"\n\"01/01/2004\"");
                return false;
            }
            else if (textBoxDateOfRelease.Text.Length < 4 || textBoxDateOfRelease.Text.Length > 10)
            {
                MessageBox.Show("Please enter date of release in one of the following formats:\n\n\"2004\"\n\"01/01/2004\"");
                return false;
            }*/
            if (releaseDatePicker.SelectedDate >= DateTime.Today || releaseDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please select a release date before today", "SVHC | Validation Error");
                return false;
            }
            if (textBoxCost.Text =="Cost Bracket" || textBoxCost.Text.Length < 1)
            {
                MessageBox.Show("Cost Bracket field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            else if (!int.TryParse(textBoxCost.Text, out result))
            {
                MessageBox.Show("Cost field must be a number", "SVHC | Validation Error");
                return false;
            }
            else if (int.Parse(textBoxCost.Text)<1 || (int.Parse(textBoxCost.Text)>100))
            {
                MessageBox.Show("Cost Bracket must be between 0 and 100", "SVHC | Validation Error");
                return false;
            }
            if ((textBoxPlatCat.Text == "Category" || textBoxPlatCat.Text.Length < 1) && (radioButtonFilm.IsChecked)== true)
            {
                MessageBox.Show("Category field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            if ((textBoxPlatCat.Text == "Platform" || textBoxPlatCat.Text.Length < 1) && (radioButtonGame.IsChecked) == true)
            {
                MessageBox.Show("Platform field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            if (radioButtonFilm.IsChecked == true)
            {
                if ((textBoxQuantity1.Text == "DVD Quantity" || textBoxQuantity1.Text.Length < 1) && (radioButtonFilm.IsChecked) == true)
                {
                    MessageBox.Show("DVD Quantity field cannot be empty", "SVHC | Validation Error");
                    return false;
                }
                else if (!int.TryParse(textBoxQuantity1.Text, out result))
                {
                    MessageBox.Show("DVD Quantity field must be a number", "SVHC | Validation Error");
                    return false;
                }
                else if (int.Parse(textBoxQuantity1.Text) < 0 || (int.Parse(textBoxQuantity1.Text) > 100))
                {
                    MessageBox.Show("DVD Quantity must be between 0 and 100", "SVHC | Validation Error");
                    return false;
                }
                if ((textBoxQuantity2.Text == "VHS Quantity" || textBoxQuantity2.Text.Length < 1) && (radioButtonFilm.IsChecked) == true)
                {
                    MessageBox.Show("VHS Quantity field cannot be empty", "SVHC | Validation Error");
                    return false;
                }
                else if (!int.TryParse(textBoxQuantity2.Text, out result))
                {
                    MessageBox.Show("VHS Quantity field must be a number", "SVHC | Validation Error");
                    return false;
                }
                else if (int.Parse(textBoxQuantity2.Text) < 0 || (int.Parse(textBoxQuantity2.Text) > 100))
                {
                    MessageBox.Show("VHS Quantity must be between 0 and 100", "SVHC | Validation Error");
                    return false;
                }
            }
            if ((textBoxQuantity1.Text == "Game Quantity" || textBoxQuantity1.Text.Length < 1) && (radioButtonGame.IsChecked) == true)
            {
                MessageBox.Show("Game Quantity field cannot be empty", "SVHC | Validation Error");
                return false;
            }
            else if (!int.TryParse(textBoxQuantity1.Text, out result))
            {
                MessageBox.Show("Game Quantity field must be a number", "SVHC | Validation Error");
                return false;
            }
            else if (int.Parse(textBoxQuantity1.Text) < 0 || (int.Parse(textBoxQuantity1.Text) > 100))
            {
                MessageBox.Show("Game Quantity must be between 0 and 100", "SVHC | Validation Error");
                return false;
            }
            if (textBoxDescr.Text == "Description" || textBoxDescr.Text.Length < 1)
            {
                MessageBox.Show("Description field cannot be empty", "SVHC | Validation Error");
                return false;
            }

            // Additional validation

            if (textBoxTitle.Text.Length > 20)
            {
                MessageBox.Show("Title field has too many characters, please try again with less characters", "SVHC | Validation Error");
                return false;
            }
            if (textBoxCertificate.Text.Length > 20)
            {
                MessageBox.Show("Certificate field has too many characters, please try again with less characters", "SVHC | Validation Error");
                return false;
            }
            if (textBoxDistributor.Text.Length > 20)
            {
                MessageBox.Show("Distributor field has too many characters, please try again with less characters", "SVHC | Validation Error");
                return false;
            }
            if (textBoxCost.Text == "Cost Bracket" || textBoxCost.Text.Length > 20)
            {
                MessageBox.Show("Cost Bracket field has too many characters, please try again with less characters", "SVHC | Validation Error");
                return false;
            }
            if ((textBoxPlatCat.Text.Length > 20) && (radioButtonFilm.IsChecked) == true)
            {
                MessageBox.Show("Category field has too many characters, please try again with less characters", "SVHC | Validation Error");
                return false;
            }
            if ((textBoxPlatCat.Text.Length > 20) && (radioButtonGame.IsChecked) == true)
            {
                MessageBox.Show("Platform field has too many characters, please try again with less characters", "SVHC | Validation Error");
                return false;
            }
            if (radioButtonFilm.IsChecked == true)
            {
                if ((textBoxQuantity1.Text.Length > 20) && (radioButtonFilm.IsChecked) == true)
                {
                    MessageBox.Show("DVD Quantity field has too many characters, please try again with less characters", "SVHC | Validation Error");
                    return false;
                }
                else if (!int.TryParse(textBoxQuantity1.Text, out result))
                {
                    MessageBox.Show("DVD Quantity field must be a number", "SVHC | Validation Error");
                    return false;
                }
                else if (int.Parse(textBoxQuantity1.Text) < 0 || (int.Parse(textBoxQuantity1.Text) > 100))
                {
                    MessageBox.Show("DVD Quantity must be between 0 and 100", "SVHC | Validation Error");
                    return false;
                }
                if ((textBoxQuantity2.Text.Length > 20) && (radioButtonFilm.IsChecked) == true)
                {
                    MessageBox.Show("VHS Quantity field has too many characters, please try again with less characters", "SVHC | Validation Error");
                    return false;
                }
                else if (!int.TryParse(textBoxQuantity2.Text, out result))
                {
                    MessageBox.Show("VHS Quantity field must be a number", "SVHC | Validation Error");
                    return false;
                }
                else if (int.Parse(textBoxQuantity2.Text) < 0 || (int.Parse(textBoxQuantity2.Text) > 100))
                {
                    MessageBox.Show("VHS Quantity must be between 0 and 100", "SVHC | Validation Error");
                    return false;
                }
            }
            if ((textBoxQuantity1.Text.Length > 20) && (radioButtonGame.IsChecked) == true)
            {
                MessageBox.Show("Game Quantity field has too many characters, please try again with less characters", "SVHC | Validation Error");
                return false;
            }
            else if (!int.TryParse(textBoxQuantity1.Text, out result))
            {
                MessageBox.Show("Game Quantity field must be a number", "SVHC | Validation Error");
                return false;
            }
            else if (int.Parse(textBoxQuantity1.Text) < 0 || (int.Parse(textBoxQuantity1.Text) > 100))
            {
                MessageBox.Show("Game Quantity must be between 0 and 100", "SVHC | Validation Error");
                return false;
            }
            if (textBoxDescr.Text.Length > 20)
            {
                MessageBox.Show("Description field has too many characters, please try again with less characters", "SVHC | Validation Error");
                return false;
            }
            // End of additional validation

            // if all validation is passed return true
            buttonClear.IsEnabled = true;
            buttonClear.Opacity = 100;
            return true;
        }
		/// <summary>
		/// Button for clearing textboxes to default values
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxDefaultValues();
			clearLabels();
        }
		/// <summary>
		/// When closed program will return to main window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
		/// <summary>
		/// Method for displaying help labels
		/// Sets their opacity to 30% to aid the user determine
		/// what field theyre in
		/// </summary>
        private void setLabels()
		{
			if (radioButtonGame.IsChecked == true)
			{
				labelTitle.Opacity = .30;
				labelTitle.Text = "Game Title";
				labelCateg.Opacity = .3;
				labelCateg.Text = "Platform";
				labelCertif.Opacity = .3;
				labelCertif.Text = "Certificate";
				labelCost.Opacity = .3;
				labelCost.Text = "Cost Bracket";
				labelDate.Opacity = .3;
				labelDate.Text = "Date of Release";
				labelDescri.Opacity = .3;
				labelDescri.Text = "Description";
				labelDistro.Opacity = .3;
				labelDistro.Text = "Distributor";
				labelDVD.Opacity = .3;
				labelDVD.Text = "Game Quantity";
				labelVHS.Opacity = 0;
				labelVHS.Text = "VHS Quantity";
			}
			if (radioButtonFilm.IsChecked == true)
			{
				labelTitle.Opacity = .3;
				labelTitle.Text = "Title";
				labelCateg.Opacity = .3;
				labelCateg.Text = "Category";
				labelCertif.Opacity = .3;
				labelCertif.Text = "Certificate";
				labelCost.Opacity = .3;
				labelCost.Text = "Cost Bracket";
				labelDate.Opacity = .3;
				labelDate.Text = "Date of Release";
				labelDescri.Opacity = .3;
				labelDescri.Text = "Description";
				labelDistro.Opacity = .3;
				labelDistro.Text = "Distributor";
				labelDVD.Opacity = .3;
				labelDVD.Text = "DVD Quantity";
				labelVHS.Opacity = .3;
				labelVHS.Text = "VHS Quantity";
			}
        }
		/// <summary>
		/// Method for setting the help label text 
		/// and opacity to hidden
		/// </summary>
		private void clearLabels()
		{
			labelTitle.Opacity = 0;
			labelTitle.Text = "Title";
			labelCateg.Opacity = 0;
			labelCateg.Text = "Category";
			labelCertif.Opacity = 0;
			labelCertif.Text = "Certificate";
			labelCost.Opacity = 0;
			labelCost.Text = "Cost Bracket";
			labelDate.Opacity = 0;
			labelDate.Text = "Date of Release";
			labelDescri.Opacity = 0;
			labelDescri.Text = "Description";
			labelDistro.Opacity = 0;
			labelDistro.Text = "Distrobutor";
			labelDVD.Opacity = 0;
			labelDVD.Text = "DVD Quantity";
			labelVHS.Opacity = 0;
			labelVHS.Text = "VHS Quantity";
		}
	}
}// end of class
