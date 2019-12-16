using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claimy_Dashboard.View;
using Claimy_Dashboard.EF;
using System.Windows;

namespace Claimy_Dashboard.ViewModel
{
    class EditEmployeeViewModel
    {
        public static void AddEmp(string name, string address, string city, string country, string phone, string email, string password, string zipcode )
        {
            
            int countryListID=0;


            using (var context = new ClaimyEntities())
            {
                try
                {
                    var clID = from cl in context.tbl_Country_List where cl.fld_Country.Equals(country) && cl.fld_City.Equals(city) && cl.fld_ZipCode.Equals(zipcode) select cl.fld_Number;
                    foreach (var item in clID)
                    {
                        countryListID = item;                        
                    }                  
                    
                    var newClaimyEmp = new tbl_Claimy_Employee() { fld_Email = email, fld_Name=name,fld_Adress=address,fld_Phone_No=phone,fld_Password=password,fld_Country_Number=countryListID };
                    context.tbl_Claimy_Employee.Add(newClaimyEmp);
                    context.SaveChanges();

                   
                 }
                catch (Exception ex)
                {
                    MessageBox.Show("Pls fill all fields");
                    Console.WriteLine(ex.InnerException.Message);
                }

            }

            
        }

        public static List<tbl_Country_List> CountryLsit(string name, string email)
        {
           
            using (var context = new ClaimyEntities())
            {
                try
                {
                    int clNumber = 0;
                    var emps = from e in context.tbl_Claimy_Employee where e.fld_Name.Equals(name) && e.fld_Email.Equals(email) select e.fld_Country_Number;

                    List < tbl_Country_List > myCl = new List<tbl_Country_List>();
                    foreach (var e in emps)
                    {
                        clNumber = e.Value;
                    }

                    var cList = from cl in context.tbl_Country_List where cl.fld_Number == clNumber select cl;
                    foreach (var cl in cList)
                    {
                        myCl.Add(cl);
                    }

                    return myCl;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
