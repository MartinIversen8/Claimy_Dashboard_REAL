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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TryLogin(object sender, RoutedEventArgs e)
        {
            
            // the username is claus@mail.dk
            string user = LoginUsername.Text;
            //  password is 321
            string password = LoginPassword.Password;

            

            if (ViewModel.LoginViewModel.TryLogin(user, password))
            {
                DashBoard main = new DashBoard();
                main.Show();
                main.loggedInPerson.Text = ViewModel.LoginViewModel.ChangeLogInName(user, password);
                this.Close();
            }
            else 
            {
                MessageBox.Show("The username or password is incorrect \n Try again");
                LoginUsername.Text = "";
                LoginPassword.Password = "";
            }

           

        }
    }
}
