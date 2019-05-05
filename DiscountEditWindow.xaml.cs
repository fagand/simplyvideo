using SimpleVideoClubHire;
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

namespace GradedUnitWPF
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
	/// Public class creating a window for editing stock
	/// adding discount to the stock
    /// </summary>
    public partial class DiscountEditWindow : Window
    {
		/// <summary>
		/// Private library attribute
		/// </summary>
		private Library thelib;
		/// <summary>
		/// Default constructor initializing window
		/// Setting the item source of the drop down menu
		/// Setting the stock items to show basic info so that the drop down isnt oversized
		/// </summary>
        public DiscountEditWindow()
        {
			thelib = Library.Instance;
            InitializeComponent();
			comboEdit.ItemsSource = thelib.StockProp;
            thelib.noMoreInfo();
        }
		/// <summary>
		/// When update button is clicked
		/// the details from the item selected in the combo box
		/// are input into the textboxes below
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
            if (comboEdit.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a valid stock item", "SVHC | Selection Error");
            }
            else
            {
                txtCostEdit.Text = (thelib.SearchStockByID(comboEdit.SelectedIndex+1));
			}
		}
		/// <summary>
		/// Returns to the main window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			//MainWindow mainWindow = new MainWindow();
			this.Close();
            //mainWindow.Show();
            this.Owner.Show();
		}
		/// <summary>
		/// Dioscount is applied to the
		/// initial stock items cost bracket
		/// text field displays the new discounted price
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnApplyDiscount_Click(object sender, RoutedEventArgs e)
        {
            bool result2 = double.TryParse(txtDiscount.Text, out double doubler);
            if (!result2)
            {
                MessageBox.Show("Discount can only be a number, please enter a valid number and try again", "SVHC | Discount error");
            }
            if (result2 && txtDiscount.Text.Length < 1 || txtDiscount.Text.Length > 2)
            {
                MessageBox.Show("Discount can be between 1 and 99, please enter a valid discount and try again", "SVHC | Discount error");
            }
            else if (result2 && (txtCostEdit.Text.Length >= 1))
            {
                double result;
                double percentage = ((double.Parse(txtDiscount.Text) / 100));
                result = (double.Parse(txtCostEdit.Text) - (double.Parse(txtCostEdit.Text) * percentage));
                txtDiscountApplied.Text = result.ToString();
            }
        }
		/// <summary>
		/// Saves the newly updated discounted
		/// price to the library
		/// 
		/// Enclosed in a try catch in case of errors
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnSaveDiscountedPrice_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateTextBoxes() == true)
            {
                //MainWindow mainWindow = new MainWindow();
                //this.Close();
                //mainWindow.Show();
                try
                {
                    string title = thelib.stock.Find(t => t.StockIDProp == comboEdit.SelectedIndex + 1).Title;
                    thelib.stock.Find(p => p.StockIDProp == (comboEdit.SelectedIndex + 1)).StockCost = (int)double.Parse(txtDiscountApplied.Text);
                    thelib.stock.Find(p => p.StockIDProp == comboEdit.SelectedIndex + 1).Title = title + " ** Now Discounted by " + txtDiscount.Text + "%";
                    //comboEdit.ItemsSource = null;
                    MessageBox.Show("Discount " + txtDiscount.Text + "% applied\nReturning to Main Window", "SVHC | Discount Saved");
                    this.Close();
                    this.Owner.Show();
                    comboEdit.ItemsSource = thelib.StockProp;
                    clearTextBox();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error saving discount\nError message: " + er.Message, "SVHC | Saving Discount Error");
                }
            }
        }
		/// <summary>
		/// If combo box selection is changed the details
		/// in the text boxes are updated accordingly.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void comboEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboEdit.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a valid stock item", "SVHC | Selection Error");
            }
            else
            {
                txtCostEdit.Text = (thelib.SearchStockByID(comboEdit.SelectedIndex + 1));
			}
		}
		/// <summary>
		/// Method for clearing the textboxes to blank
		/// </summary>
        private void clearTextBox()
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
		/// When window is closed returns to main window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
        /// <summary>
        /// Method used for checkign that the user has entered a number into the textbox
        /// fields, if not present with a message to ask for numbers only
        /// </summary>
        /// <returns>true if creteria is accepted</returns>
        private bool ValidateTextBoxes()
        {
            int result;
            if (!int.TryParse(txtCostEdit.Text, out result))
            {
                MessageBox.Show("Orignal cost textbox must only contain a number, please try again", "SVHC | Original Cost Validation Error");
                return false;
            }
            if (!int.TryParse(txtDiscount.Text,out result))
            {
                MessageBox.Show("Discount can only be a number, please try again", "SVHC | Discount Validation Error");
                return false;
            }
            if (!int.TryParse(txtDiscountApplied.Text,out result) && !double.TryParse(txtDiscountApplied.Text,out double result2))
            {
                MessageBox.Show("Discounted cost can only be a number, please try again", "SVHC | Discounted Cost Validation Error");
                return false;
            }
            return true;
        }
    }//end of class
}
