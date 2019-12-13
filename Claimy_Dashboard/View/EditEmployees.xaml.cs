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
        {
            ChoiceEmployee.Visibility = Visibility.Hidden;
            AddEmployeeTxtb.Visibility = Visibility.Visible;
        }

        private void EditEmployee(object sender, MouseButtonEventArgs e)
        {
            ChoiceEmployee.Visibility = Visibility.Hidden;
        }

        private void RemoveEmployee(object sender, MouseButtonEventArgs e)
        {
            ChoiceEmployee.Visibility = Visibility.Hidden;
        }

        private void AddNewEmp(object sender, RoutedEventArgs e)
        {
            string name = EmpName.Text;
            string address = EmpAddress.Text;
            string city = EmpCity.Text;
            string country = EmpCountry.Text;
            string phone = EmpPhone.Text;
            string email = EmpEmail.Text;
            string password = EmpPassword.Text;
            string zipcode = EmpZipcode.Text;
            ViewModel.EditEmployeeViewModel.AddEmp(name,address,city,country,phone,email,password,zipcode);
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
           
        }

        private void EmpNameEdit_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = names;
        }

        private void EmpNameEditCombo_DropDownClosed(object sender, EventArgs e)
        {
            empList = ViewModel.ListsForListviews.SingleEmployeeDataList(EmpNameEditCombo.Text);
            foreach (var emp in empList)
            {
                EmpAddressEdit.Text = emp.fld_Adress;
                EmpEmailEdit.Text = emp.fld_Email;
                EmpPhoneEdit.Text = emp.fld_Phone_No;
                EmpPasswordEdit.Text = emp.fld_Password;

            }
        }
    }
}
