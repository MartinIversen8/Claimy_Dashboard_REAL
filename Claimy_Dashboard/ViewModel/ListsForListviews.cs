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

    }
}
