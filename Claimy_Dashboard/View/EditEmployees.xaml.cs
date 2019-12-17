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
    /// Interaction logic for EditEmployees.xaml
    /// </summary>
    public partial class EditEmployees : Window
    {
        // lists we use in this class
        List<string> names = new List<string>();
        List<tbl_Claimy_Employee> empList = new List<tbl_Claimy_Employee>();
        List<tbl_Country_List> country_Lists = new List<tbl_Country_List>();
        public EditEmployees()
        {
            InitializeComponent();
           
            names = ViewModel.ListsForListviews.EmployeeNameList();            
            DataContext = this;
        }
        private void AddNewEmployee(object sender, MouseButtonEventArgs e)
        {   // hide the options/choices and shows the add employee page
            ChoiceEmployee.Visibility = Visibility.Hidden;
            AddEmployeeTxtb.Visibility = Visibility.Visible;
        }

        private void EditEmployee(object sender, MouseButtonEventArgs e)
        {
            // hides the choices and makes the EditEmployeeGrid visible
            ChoiceEmployee.Visibility = Visibility.Hidden;
            EditEmployeeGrid.Visibility = Visibility.Visible;
        }

        private void RemoveEmployee(object sender, MouseButtonEventArgs e)
        {
            // hide choices and make the removeEmployeegrid visible
            ChoiceEmployee.Visibility = Visibility.Hidden;
            RemoveEmployeeGrid.Visibility = Visibility.Visible;
        }

        private void AddNewEmp(object sender, RoutedEventArgs e)
        {
            // taking the input from the textboxes and sets them to strings
            string name = EmpName.Text;
            string address = EmpAddress.Text;
            string city = EmpCity.Text;
            string country = EmpCountry.Text;
            string phone = EmpPhone.Text;
            string email = EmpEmail.Text;
            string password = EmpPassword.Text;
            string zipcode = EmpZipcode.Text;
            // calling method for adding employees
            ViewModel.EditEmployeeViewModel.AddEmp(name,address,city,country,phone,email,password,zipcode);
            // resets the textboxes after AddEmp has been done
            EmpName.Text = "";
            EmpAddress.Text = "";
            EmpCity.Text = "";
            EmpCountry.Text = "";
            EmpPhone.Text = "";
            EmpEmail.Text = "";
            EmpPassword.Text = "";
            EmpEmail.Text = "";
            EmpZipcode.Text = "";
            
        }

        private void EditAnEmployee (object sender, RoutedEventArgs e)
        {
            // // taking the context from the textboxes and sets them to strings
            string name = EmpNameEditCombo.Text;
            string address = EmpAddressEdit.Text;
            string city = EmpCityEdit.Text;
            string country = EmpCountryEdit.Text;
            string phone = EmpPhoneEdit.Text;
            string email = EmpEmailEdit.Text;
            string password = EmpPasswordEdit.Text;
            string zipcode = EmpZipcodeEdit.Text;            
           // if changes has been succesfull it resets the boxes and take you back to choices
            if (ViewModel.EditEmployeeViewModel.SaveChangesToDB(name,email,password,address,phone,zipcode,country,city))
            {
                EmpAddressEdit.Text = "";
                EmpEmailEdit.Text = "";
                EmpPhoneEdit.Text = "";
                EmpPasswordEdit.Text = "";
                EmpZipcodeEdit.Text = "";
                EmpCountryEdit.Text = "";
                EmpCityEdit.Text = "";
                EmpNameEditCombo.Text = "";
                EditEmployeeGrid.Visibility = Visibility.Hidden;
                ChoiceEmployee.Visibility = Visibility.Visible;
            }


        }

        // for having the names in the comboBox under edidtEmployee 
        private void EmpNameEdit_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = names;
        }

        // for showing all relevant data from the selected employee from the combobox
        private void EmpNameEditCombo_DropDownClosed(object sender, EventArgs e)
        {
            // getting the selected employee from the database
            empList = ViewModel.ListsForListviews.SingleEmployeeDataList(EmpNameEditCombo.Text);
            // getting the data from the method that makes a list and sets the boxes to the content of the selected employee
            foreach (var emp in empList)
            {
                EmpAddressEdit.Text = emp.fld_Adress;
                EmpEmailEdit.Text = emp.fld_Email;
                EmpPhoneEdit.Text = emp.fld_Phone_No;
                EmpPasswordEdit.Text = emp.fld_Password;
                             

            }
            // for getting the "Address" info such as city, zipcode and Country
            country_Lists = ViewModel.EditEmployeeViewModel.CountryLsit(EmpNameEditCombo.Text,EmpEmailEdit.Text);
            // setting the boxes to the data from the country_Lists  
            foreach (var cl in country_Lists)
            {
                EmpZipcodeEdit.Text = cl.fld_ZipCode;
                EmpCountryEdit.Text = cl.fld_Country;
                EmpCityEdit.Text = cl.fld_City;
            }
        }

        // for getting  names in the combobox
        private void EmpToremove_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = names;
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.EditEmployeeViewModel.RemoveEmployee(EmpToremove.Text);
            names = ViewModel.ListsForListviews.EmployeeNameList();
            var combo = sender as ComboBox;
            combo.ItemsSource = names;
        }

        // if you dont want to remove anyone it goes back to choices 
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            // hides RemoveEmployeeGrid and makes choices visible again
            RemoveEmployeeGrid.Visibility = Visibility.Hidden;
            ChoiceEmployee.Visibility = Visibility.Visible;
        }
    }
}
