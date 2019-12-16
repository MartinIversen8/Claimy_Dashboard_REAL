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
using Claimy_Dashboard.EF;

namespace Claimy_Dashboard.View
{
    /// <summary>
    /// Interaction logic for EditCustomerView.xaml
    /// </summary>
    public partial class EditCustomerView : Window
    {
        List<string> emails = new List<string>();
        List<tbl_Customer> customerList = new List<tbl_Customer>();
        List<tbl_Country_List> country_Lists = new List<tbl_Country_List>();
        public EditCustomerView()
        {
            InitializeComponent();
            emails = ViewModel.EditCustomerViewModel.CustomerEmailList();
        }

        private void RemoveCustomerOptionShow(object sender, MouseButtonEventArgs e)
        {
            ChoiceCustomer.Visibility = Visibility.Hidden;
            RemoveCustomerGrid.Visibility = Visibility.Visible;
        }

        private void EditCustomerOptionsShow(object sender, MouseButtonEventArgs e)
        {
            ChoiceCustomer.Visibility = Visibility.Hidden;
            EditCustomerGrid.Visibility = Visibility.Visible;
        }

        private void EditCusBtn_Click(object sender, RoutedEventArgs e)
        {
            string email = CusEmailEditCombo.Text;
            string address = CusAddressEdit.Text;
            string city = CusCityEdit.Text;
            string country = CusCountryEdit.Text;
            string phone = CusPhoneEdit.Text;
            string name = CusNameEdit.Text;
            string password = CusPasswordEdit.Text;
            string zipcode = CusZipcodeEdit.Text;
            // if changes has been succesfull it resets the boxes and take you back to choices
            if (ViewModel.EditCustomerViewModel.SaveCustomerChangesToDB(name, email, password, address, phone, zipcode, country, city))
            {
                CusAddressEdit.Text = "";
                CusNameEdit.Text = "";
                CusPhoneEdit.Text = "";
                CusPasswordEdit.Text = "";
                CusZipcodeEdit.Text = "";
                CusCountryEdit.Text = "";
                CusCityEdit.Text = "";
                CusEmailEditCombo.Text = "";
                EditCustomerGrid.Visibility = Visibility.Hidden;
                ChoiceCustomer.Visibility = Visibility.Visible;
            }
        }

        private void CustomerToremove_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = emails;
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.EditCustomerViewModel.RemoveEmployee(CustomerToremove.Text);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            // hides RemoveEmployeeGrid and makes choices visible again
            RemoveCustomerGrid.Visibility = Visibility.Hidden;
            ChoiceCustomer.Visibility = Visibility.Visible;
        }

        private void CusEmailEditCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = emails;
        }

        private void CusEmailEditCombo_DropDownClosed(object sender, EventArgs e)
        {
            // getting the selected employee from the database
            customerList = ViewModel.EditCustomerViewModel.SingleCustomerDataList(CusEmailEditCombo.Text);            
            // getting the data from the method that makes a list and sets the boxes to the content of the selected employee
            foreach (var c in customerList)
            {
                CusAddressEdit.Text = c.fld_Adress;
                CusNameEdit.Text = c.fld_Email;
                CusPhoneEdit.Text = c.fld_Phone_No;
                CusPasswordEdit.Text = c.fld_Password;

            }
            // for getting the "Address" info such as city, zipcode and Country
            country_Lists = ViewModel.EditCustomerViewModel.CountryLsit(CusEmailEditCombo.Text);
            // setting the boxes to the data from the country_Lists  
            foreach (var cl in country_Lists)
            {
                CusZipcodeEdit.Text = cl.fld_ZipCode;
                CusCountryEdit.Text = cl.fld_Country;
                CusCityEdit.Text = cl.fld_City;
            }

        }
    }
}
