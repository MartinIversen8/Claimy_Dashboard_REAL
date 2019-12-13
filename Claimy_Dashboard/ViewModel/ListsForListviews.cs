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
        public static List<tbl_Ticket_Case> CaseLsitMaker()
        {
            using (var context = new ClaimyEntities())
            {
                try
                {
                    var caseTicket = from c in context.tbl_Ticket_Case select c;
                    List<tbl_Ticket_Case> myCases = new List<tbl_Ticket_Case>();
                    foreach (var c in caseTicket)
                    {
                        myCases.Add(c);
                    }

                    return myCases;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public static List<tbl_Ticket_Case> FullSingleTicketCase(string caseID)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {
                    var caseTicket = from c in context.tbl_Ticket_Case where c.fld_Case_Ticket_ID.Equals(caseID) select c;
                    List<tbl_Ticket_Case> myCases = new List<tbl_Ticket_Case>();
                    foreach (var c in caseTicket)
                    {
                        myCases.Add(c);
                    }

                    return myCases;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public static List<string> EmployeeNameList()
        {
            using (var context = new ClaimyEntities())
            {
                try
                {
                    var emps = from e in context.tbl_Claimy_Employee select e.fld_Name;
                    List <string> myEmps = new List<string>();
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

        public static List<tbl_Claimy_Employee> SingleEmployeeDataList(string name)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {
                    var emps = from e in context.tbl_Claimy_Employee where e.fld_Name.Equals(name) select e;
                    List<tbl_Claimy_Employee> myEmps = new List<tbl_Claimy_Employee>();
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
