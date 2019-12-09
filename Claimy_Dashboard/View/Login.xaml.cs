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
                    string userData = "";
                    string passwordData = "";

                    //var userDB = context.tbl_Claimy_Employee.SqlQuery("select fld_Email from tbl_Claimy_Employee where fld_Email= '" + user + "' and fld_Password = '" + password + "'").ToList();
                    //var passwordDB = context.tbl_Claimy_Employee.SqlQuery("select fld_Password from tbl_Claimy_Employee where fld_Email= '" + user + "' and fld_Password = '" + password + "'");

                    //foreach (tbl_Claimy_Employee employee in context.tbl_Claimy_Employee)
                    //{
                    //    Console.WriteLine("------------------------------------------------------DET HER ER USER "+user);
                    //    if (employee.fld_Email.Equals(user))
                    //    {
                    //        Console.WriteLine(employee.fld_Adress +"DET VIRKER NU ------------------------------------------------- ");
                    //    }
                    //}

                    var userDataLinQ = from emp in context.tbl_Claimy_Employee where emp.fld_Email.Equals(user) && emp.fld_Password.Equals(password) select emp;

                    foreach (var emp in userDataLinQ)
                    {
                        userData = ""+emp.fld_Email;                         
                    }

                    Console.WriteLine(userData+"VIRK NUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU");

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }  
            }
            DashBoard main = new DashBoard();

            App.Current.MainWindow = main;
            this.Close();
            main.Show();

            // switching view to Dashborad

        }
    }
}
