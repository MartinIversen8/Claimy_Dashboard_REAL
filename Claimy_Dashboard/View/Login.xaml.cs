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
            Console.WriteLine("------------------------------------------------------------------------------------------");
            // claus@mail.dk
            string user = LoginUsername.Text;
            // 321
            string password = LoginPassword.Text;

            //Console.WriteLine(user+" and  "+password);

            using (var context = new ClaimyEntities())
            {
                try
                {
                    
                    var userDataLinQ = from emp in context.tbl_Claimy_Employee where emp.fld_Email.Equals(user) && emp.fld_Password.Equals(password) select emp;

                    foreach (var emp in userDataLinQ)
                    {
                        if (emp.fld_Email.Equals(user) && emp.fld_Password.Equals(password))
                        {
                            // switching view to Dashborad
                            DashBoard main = new DashBoard();
                            App.Current.MainWindow = main;
                            this.Close();
                            main.Show();
                        }
                                                                    
                    }

                   
                  

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }  
            }
           

            

        }
    }
}
