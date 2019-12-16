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
        // for adding a new employee to the database
        public static void AddEmp(string name, string address, string city, string country, string phone, string email, string password, string zipcode )
        {
            
            int countryListID=0;


            using (var context = new ClaimyEntities())
            {
                try
                {   
                    // selecting the FK from country_List from data inputtet in textboxes when creating a new employee 
                    var clID = from cl in context.tbl_Country_List where cl.fld_Country.Equals(country) && cl.fld_City.Equals(city) && cl.fld_ZipCode.Equals(zipcode) select cl.fld_Number;
                    foreach (var item in clID)
                    {
                        countryListID = item;                        
                    }                  
                    
                    // making the new employee 
                    var newClaimyEmp = new tbl_Claimy_Employee() { fld_Email = email, fld_Name=name,fld_Adress=address,fld_Phone_No=phone,fld_Password=password,fld_Country_Number=countryListID };
                    // adding to table
                    context.tbl_Claimy_Employee.Add(newClaimyEmp);
                    // saving the changes made to the table 
                    context.SaveChanges();

                   
                 }
                catch (Exception ex)
                {
                    // message to user of the program if all fields are not selected 
                    MessageBox.Show("Pls fill all fields");
                    Console.WriteLine(ex.InnerException.Message);
                }

            }

            
        }

        // making a list of the country list that match the parameters
        public static List<tbl_Country_List> CountryLsit(string name, string email)
        {
           
            using (var context = new ClaimyEntities())
            {
                try
                {
                    int clNumber = 0;
                    // selecting the country list number which is a foreign key in the claimy employee table
                    var emps = from e in context.tbl_Claimy_Employee where e.fld_Name.Equals(name) && e.fld_Email.Equals(email) select e.fld_Country_Number;

                    List < tbl_Country_List > myCl = new List<tbl_Country_List>();
                    // setting the countrylist number to clNumber for later usage 
                    foreach (var e in emps)
                    {
                        clNumber = e.Value;
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

        public static bool SaveChangesToDB(string name, string email, string password, string address, string phone, string zipcode, string country, string city )
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
                    var emp = from e in context.tbl_Claimy_Employee where e.fld_Email.Equals(email) select e;                                        
                    foreach (var e in emp)
                    {
                        e.fld_Name = name;
                        e.fld_Adress = address;
                        e.fld_Phone_No = phone;
                        e.fld_Password = password;
                        e.fld_Country_Number = clNumber;
                        

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
        // for removing/deleting a employee from the data base 
        public static void RemoveEmployee(string name)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {
                    Console.WriteLine("What is the NAme "+name);
                    // getting the employee that matches with the name 
                    var emp = from e in context.tbl_Claimy_Employee where e.fld_Name.Equals(name) select e;
                    // removing the selected emp from the database.                   
                    Console.WriteLine(emp.Count()+" THIS IS THE LENGHT OF THE LIST");
                    foreach (var e in emp)
                    {                        
                        context.tbl_Claimy_Employee.Remove(e);
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
