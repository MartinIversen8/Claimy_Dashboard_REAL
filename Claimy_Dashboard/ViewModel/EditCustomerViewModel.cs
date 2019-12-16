using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claimy_Dashboard.EF;

namespace Claimy_Dashboard.ViewModel
{
    class EditCustomerViewModel
    {
        public static List<string> CustomerEmailList()
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // getting all the names from the database 
                    var cus = from c in context.tbl_Customer select c.fld_Email;
                    List<string> myCus = new List<string>();
                    // adding to a list
                    foreach (var c in cus)
                    {
                        myCus.Add(c);
                    }
                    // reutrning líst
                    return myCus;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public static List<tbl_Customer> SingleCustomerDataList(string email)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // getting the customer where email matches the email parameter
                    var cus = from c in context.tbl_Customer where c.fld_Email.Equals(email) select c;
                    List<tbl_Customer> myCus = new List<tbl_Customer>();
                    // addin the customer to a list
                    foreach (var c in cus)
                    {
                        myCus.Add(c);
                    }

                    return myCus;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public static List<tbl_Country_List> CountryLsit(string email)
        {

            using (var context = new ClaimyEntities())
            {
                try
                {
                    int clNumber = 0;
                    // selecting the country list number which is a foreign key in the claimy employee table
                    var cus = from c in context.tbl_Customer where c.fld_Email.Equals(email) select c.fld_Country_Number;

                    List<tbl_Country_List> myCl = new List<tbl_Country_List>();
                    // setting the countrylist number to clNumber for later usage 
                    foreach (var c in cus)
                    {
                        clNumber = c.Value;
                    }

                    // selecting info from tbl_country:list where the clNumber is PK
                    var cList = from cl in context.tbl_Country_List where cl.fld_Number == clNumber select cl;
                    foreach (var cl in cList)
                    {
                        myCl.Add(cl);
                    }
                    // returning the list with the countrylist info
                    return myCl;



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public static bool SaveCustomerChangesToDB(string name, string email, string password, string address, string phone, string zipcode, string country, string city)
        {
            int clNumber = 0;
            using (var context = new ClaimyEntities())
            {
                try
                {
                    // getting the FK to employee from country list 
                    var countries = from cl in context.tbl_Country_List where cl.fld_City.Equals(city) && cl.fld_Country.Equals(country) && cl.fld_ZipCode.Equals(zipcode) select cl.fld_Number;
                    foreach (var c in countries)
                    {
                        clNumber = c;


                    }
                    // inserting the changes 
                    var cus = from c in context.tbl_Customer where c.fld_Email.Equals(email) select c;
                    foreach (var c in cus)
                    {
                        c.fld_Name = name;
                        c.fld_Adress = address;
                        c.fld_Phone_No = phone;
                        c.fld_Password = password;
                        c.fld_Country_Number = clNumber;

                    }
                    // saving the changes made to emplooyee
                    context.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return false;

                }


            }
        }

        public static void RemoveEmployee(string email)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {                   
                    // getting the customer that matches with the name 
                    var cus = from c in context.tbl_Customer where c.fld_Email.Equals(email) select c;
                    // removing the selected emp from the database.                   
                   
                    foreach (var c in cus)
                    {
                        context.tbl_Customer.Remove(c);
                        
                    }
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                               
            }
        }
    }
}
