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
	/// Public class creating a window to edit stock
	/// </summary>
	public partial class EditWindow : Window
	{
		/// <summary>
		/// Private library attribute
		/// </summary>
		private Library thelib;
		/// <summary>
		/// Default constructor creating an instance of the library
		/// initializing the window
		/// sets the combo box source to show stock
		/// sets the stock to be minimal info to prevent the drop
		/// down box being overcrowded.
		/// </summary>
		public EditWindow()
		{
			thelib = Library.Instance;
			InitializeComponent();
			comboStock.ItemsSource = thelib.StockProp;
            thelib.noMoreInfo();
		}
		/// <summary>
		/// If the combo box selection is changed
		/// the details of the stock item selected are put into the
		/// relevant text boxes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboStock_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (comboStock.SelectedIndex < 0 || comboStock.SelectedIndex > thelib.stock.Count)
			{
				MessageBox.Show("Please select a valid stock item", "SVCH | Error");
			}
			else
			{
				txtTitle.Text = (thelib.SearchStockReturnTitle(comboStock.SelectedIndex + 1));
				txtCertificate.Text = (thelib.SearchStockReturnCertificate(comboStock.SelectedIndex + 1));
				txtDescription.Text = (thelib.SearchStockReturnDescription(comboStock.SelectedIndex + 1));
                if (comboStock.SelectedItem.GetType() == typeof(Film))
                {
                    txtDVD.IsReadOnly = false;
                    txtVHS.IsReadOnly = false;
                    txtDVD.Opacity = 100;
                    txtVHS.Opacity = 100;
                    txtDVD.Text = (thelib.SearchStockReturnDVDQuantity(comboStock.SelectedIndex + 1));
                    txtVHS.Text = (thelib.SearchStockReturnVHSQuantity(comboStock.SelectedIndex + 1));
                    txtGame.IsReadOnly = true;
                    txtGame.Opacity = 0;
                }
                if (comboStock.SelectedItem.GetType() == typeof(Game))
                {
                    txtGame.IsReadOnly = false;
                    txtGame.Opacity = 100;
                    txtGame.Text = (thelib.SearchStockReturnGameQuantity(comboStock.SelectedIndex + 1));
                    txtDVD.IsReadOnly = true;
                    txtVHS.IsReadOnly = true;
                    txtDVD.Opacity = 0;
                    txtVHS.Opacity = 0;
                }
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
			//this.Close();
			//mainWindow.Show();            
			this.Close();
			this.Owner.Show();
		}
		/// <summary>
		/// Saves discounted price to the library
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveInfo_Click(object sender, RoutedEventArgs e)
		{
            if (comboStock.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a valid stock item", "SVHC | Edit Window Selection Error");
            }
            else
            {
                if (ValidateQuantityBoxes() == true)
                {
                    //MainWindow mainWindow = new MainWindow();
                    this.Close();
                    this.Owner.Show();
                    //mainWindow.Show();
                    //string title = thelib.stock.Find(t => t.StockIDProp == comboEdit.SelectedIndex + 1).Title;
                    thelib.stock.Find(p => p.StockIDProp == (comboStock.SelectedIndex + 1)).Title = txtTitle.Text;
                    thelib.stock.Find(p => p.StockIDProp == comboStock.SelectedIndex + 1).CertificateProp = txtCertificate.Text;
                    thelib.stock.Find(p => p.StockIDProp == comboStock.SelectedIndex + 1).DescriptionProp = txtDescription.Text;
                    if (comboStock.SelectedItem.GetType() == typeof(Film))
                    {
                        {
                            thelib.stock.Find(p => p.StockIDProp == comboStock.SelectedIndex + 1).DVDprop = int.Parse(txtDVD.Text);
                            thelib.stock.Find(p => p.StockIDProp == comboStock.SelectedIndex + 1).VHSprop = int.Parse(txtVHS.Text);
                        }
                    }
                    if (comboStock.SelectedItem.GetType() == typeof(Game))
                    {
                        thelib.stock.Find(p => p.StockIDProp == comboStock.SelectedIndex + 1).GameQuantProp = int.Parse(txtGame.Text);
                    }
                    MessageBox.Show("New Details Saved", "SVCH | Saved Window");
                }
            }
        }
		/// <summary>
		/// Deletes the selected stock item from the library
		/// Changes the id on the surrounding stock items
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "SVCH | Delete Window",
			MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if (result != MessageBoxResult.Yes)
			{
				e.Handled = false;
			}
			else
			{
                try
                {
                    //MainWindow mainWindow = new MainWindow();
                    //this.Close();
                    //mainWindow.Show();
                    thelib.unitTestRemove2(comboStock.SelectedIndex);
                    thelib.unitTestChangeID(comboStock.SelectedIndex, (comboStock.SelectedIndex + 1), thelib.stock.Count);
                    clearTextBoxes();
                    comboStock.ItemsSource = null;
                    comboStock.ItemsSource = thelib.StockProp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message, "SVHC | Deleting Stock Error");
                }
			}
		}
		/// <summary>
		/// Clears the text boxes
		/// </summary>
		public void clearTextBoxes()
		{
			txtCertificate.Clear();
			txtDescription.Clear();
			txtTitle.Clear();
		}
		/// <summary>
		/// Returns to the main window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
        /// <summary>
        /// Method used for checkign that the user has entered a number into the quantity
        /// fields, if not present with a message to ask for numbers only
        /// </summary>
        /// <returns>true if creteria is accepted</returns>
        private bool ValidateQuantityBoxes()
        {
            int result;
            if (comboStock.SelectedItem.GetType() == typeof(Film))
            {
                if (!int.TryParse(txtDVD.Text, out result))
                {
                    MessageBox.Show("DVD Quantity must be a number", "SVHC | Validation Error");
                    return false;
                }
                if (!int.TryParse(txtVHS.Text, out result))
                {
                    MessageBox.Show("VHS Quantity must be a number", "SVHC | Validation Error");
                    return false;
                }
            }
            if (comboStock.SelectedItem.GetType() == typeof(Game))
            {
                if (!int.TryParse(txtGame.Text, out result))
                {
                    MessageBox.Show("Game Quantity must be a number", "SVHC | Validation Error");
                    return false;
                }
            }
            return true;
        }
    }// end of class
}
