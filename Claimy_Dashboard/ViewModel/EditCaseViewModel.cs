using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claimy_Dashboard.EF;

namespace Claimy_Dashboard.ViewModel
{
    class EditCaseViewModel
    {

        public static List<string> CaseIDList()
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // getting all the case id's from the database 
                    var cas = from c in context.tbl_Ticket_Case select c.fld_Case_Ticket_ID;
                    List<string> myCases = new List<string>();
                    // adding to the list
                    foreach (var c in cas)
                    {
                        myCases.Add(c);
                    }
                    // reutrning líst
                    return myCases;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public static List<tbl_Ticket_Case> SingleCaseTicket(string caseID)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // getting all the case id's from the database 
                    var cas = from c in context.tbl_Ticket_Case where c.fld_Case_Ticket_ID.Equals(caseID) select c;
                    List<tbl_Ticket_Case> myCases = new List<tbl_Ticket_Case>();
                    // adding to the list
                    foreach (var c in cas)
                    {
                        myCases.Add(c);
                    }
                    // reutrning líst
                    return myCases;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        // this method is for updating the database table tbl_Ticket_Case
        public static bool IsSavedToDB(string caseID, string parkingFineReason, string precedens, string status, string lawViolation, string taxnumber, string dateTime, string carRegNo,
             int parkingspaceID, int trafficWardenID, string amount, string paymentInfo, string carBrand, string cvrnr)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {   // getting all the case id's from the database 
                    var cas = from c in context.tbl_Ticket_Case where c.fld_Case_Ticket_ID.Equals(caseID) select c;
                    
                    // changeing values to the input from the parameters
                    foreach (var c in cas)
                    {
                        c.fld_amount = amount;
                        c.fld_car_brand = carBrand;
                        c.fld_car_reg_no = carRegNo;
                        c.fld_CVRNumber = cvrnr;
                        c.fld_date_time = dateTime;
                        c.fld_Law_Violation = lawViolation;
                        c.fld_ParkingFine_Reason = parkingFineReason;
                        c.fld_parkingspace_id = parkingspaceID;
                        c.fld_payment_info = paymentInfo;
                        c.fld_Precedens = precedens;
                        c.fld_Status = status;
                        c.fld_tax_number = taxnumber;
                        c.fld_traffic_warden_no = trafficWardenID;                       
                    }

                    context.SaveChanges();

                    return true;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }

        }

        public static void RemoveTicketCase(string caseID)
        {
            using (var context = new ClaimyEntities())
            {
                try
                {
                    
                    var cas = from c in context.tbl_Ticket_Case where c.fld_Case_Ticket_ID.Equals(caseID) select c;
                                       

                    foreach (var c in cas)
                    {
                        context.tbl_Ticket_Case.Remove(c);

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
