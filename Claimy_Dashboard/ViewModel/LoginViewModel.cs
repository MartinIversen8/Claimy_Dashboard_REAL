using Claimy_Dashboard.EF;
using Claimy_Dashboard.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claimy_Dashboard.ViewModel
{
    public class LoginViewModel
    {
        // checking if the username (Email) and the password is in the database and in the same record. 
        public static bool TryLogin(string username, string password)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {
                    bool inDatabse = false;
                    // selecting record in database from the given parameters in the method
                    var userDataLinQ = from emp in context.tbl_Claimy_Employee where emp.fld_Email.Equals(username) && emp.fld_Password.Equals(password) select emp;

                    foreach (var emp in userDataLinQ)
                    {
                        if (emp.fld_Email.Equals(username) && emp.fld_Password.Equals(password))
                        {

                            inDatabse = true;
                            return inDatabse;
                        }

                    }


                    return inDatabse;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public static string ChangeLogInName(string username, string password)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {
                   
                    // selecting record in database from the given parameters in the method
                    var userDataLinQ = from emp in context.tbl_Claimy_Employee where emp.fld_Email.Equals(username) && emp.fld_Password.Equals(password) select emp;

                    foreach (var emp in userDataLinQ)
                    {
                        if (emp.fld_Email.Equals(username) && emp.fld_Password.Equals(password))
                        {

                          return emp.fld_Name; 
                        }

                    }


                    return userDataLinQ.ElementAt(0).fld_Name;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return "";
                }


            }



        }
    }
}