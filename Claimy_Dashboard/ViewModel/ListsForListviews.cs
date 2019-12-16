using Claimy_Dashboard.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claimy_Dashboard.ViewModel
{
    public class ListsForListviews
    {
        // making a list of cases 
        public static List<tbl_Ticket_Case> CaseLsitMaker()
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // selecting cases from the table tbl_Ticket_Case 
                    var caseTicket = from c in context.tbl_Ticket_Case select c;
                    List<tbl_Ticket_Case> myCases = new List<tbl_Ticket_Case>();
                    // adding the cases from database and adding them to a list 
                    foreach (var c in caseTicket)
                    {
                        myCases.Add(c);
                    }
                    // returning the list of cases 
                    return myCases;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        // for getting a single case that matches the selected id
        public static List<tbl_Ticket_Case> FullSingleTicketCase(string caseID)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // selecting case where the caseID matches the parameter
                    var caseTicket = from c in context.tbl_Ticket_Case where c.fld_Case_Ticket_ID.Equals(caseID) select c;
                    List<tbl_Ticket_Case> myCases = new List<tbl_Ticket_Case>();
                    // adding the case to a list
                    foreach (var c in caseTicket)
                    {
                        myCases.Add(c);
                    }
                    // returning case 
                    return myCases;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        // fro getting a list of all the employee names  
        public static List<string> EmployeeNameList()
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // getting all the names from the database 
                    var emps = from e in context.tbl_Claimy_Employee select e.fld_Name;
                    List <string> myEmps = new List<string>();
                    // adding to a list
                    foreach (var e in emps)
                    {
                        myEmps.Add(e);
                    }
                    // reutrning líst
                    return myEmps;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        // getting info of a specific employee 
        public static List<tbl_Claimy_Employee> SingleEmployeeDataList(string name)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // getting the employee where name matches the name parameter
                    var emps = from e in context.tbl_Claimy_Employee where e.fld_Name.Equals(name) select e;
                    List<tbl_Claimy_Employee> myEmps = new List<tbl_Claimy_Employee>();
                    // addin the employee to a list
                    foreach (var e in emps)
                    {
                        myEmps.Add(e);
                    }

                    return myEmps;

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
