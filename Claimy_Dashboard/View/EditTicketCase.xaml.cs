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
    /// Interaction logic for AddCase.xaml
    /// </summary>
    public partial class AddCase : Window
    {
        List<string> caseNo = new List<string>();
        List<tbl_Ticket_Case> ticketCaseList = new List<tbl_Ticket_Case>();
        //List<tbl_Country_List> country_Lists = new List<tbl_Country_List>();
        public AddCase()
        {
            
            InitializeComponent();
            caseNo = ViewModel.EditCaseViewModel.CaseIDList();
        }          
            

        private void CaseNumberEdit_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = caseNo;
        }

        private void CaseNumberEdit_DropDownClosed(object sender, EventArgs e)
        {
            ticketCaseList = ViewModel.EditCaseViewModel.SingleCaseTicket(CaseNumberEditCombo.Text);

            foreach (var c in ticketCaseList)
            {
                ParkingFineReasonEdit.Text = c.fld_ParkingFine_Reason;
                PrecedensEdit.Text = c.fld_Precedens;
                StatusComboEdit.Text = c.fld_Status;
                LawViolationEdit.Text = c.fld_Law_Violation;
                TaxNumberEdit.Text = c.fld_tax_number;
                DateTimeEdit.Text = c.fld_date_time;
                CarRegEdit.Text = c.fld_car_reg_no;
                ParkingSpaceIDEdit.Text = ""+c.fld_parkingspace_id;
                TrafficWardenID.Text = "" + c.fld_traffic_warden_no;
                AmountEdit.Text = c.fld_amount;
                PaymentInfoEdit.Text = c.fld_payment_info;
                CarBrandEdit.Text = c.fld_car_brand;
                CvrnrEdit.Text = c.fld_CVRNumber;
            }
        }

        private void EditCaseTicketOptions(object sender, MouseButtonEventArgs e)
        {
            ChoiceCase.Visibility = Visibility.Hidden;
            TicketCaseEditGrid.Visibility = Visibility.Visible;
            BottomGrid.Visibility = Visibility.Visible;
        }

        private void RemoveCaseTicketOption(object sender, MouseButtonEventArgs e)
        {
            ChoiceCase.Visibility = Visibility.Hidden;
            RemoveCaseGrid.Visibility = Visibility.Visible;
        }

        private void CaseToRemoveCombobox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = caseNo;
        }

        private void SaveChangesToDB(object sender, RoutedEventArgs e)
        {
            string caseID = CaseNumberEditCombo.Text;
            string parkingFineReason = ParkingFineReasonEdit.Text;
            string precedens = PrecedensEdit.Text;
            string status = StatusComboEdit.Text;
            string lawViolation = LawViolationEdit.Text;
            string taxnumber = TaxNumberEdit.Text;
            string dateTime = DateTimeEdit.Text;
            string carRegNo = CarRegEdit.Text;
            int parkingspaceID = Int32.Parse(ParkingSpaceIDEdit.Text); 
            int trafficWardenID = Int32.Parse(TrafficWardenID.Text); 
            string amount = AmountEdit.Text;
            string paymentInfo = PaymentInfoEdit.Text;
            string carBrand = CarBrandEdit.Text;
            string cvrnr = CvrnrEdit.Text;
            if (ViewModel.EditCaseViewModel.IsSavedToDB(caseID, parkingFineReason,precedens,status,lawViolation,taxnumber,dateTime,carRegNo,parkingspaceID,trafficWardenID,amount,paymentInfo,carBrand,cvrnr))
            {
                CaseNumberEditCombo.Text = "";
                ParkingFineReasonEdit.Text = "";
                PrecedensEdit.Text = "";
                StatusComboEdit.Text = "";
                LawViolationEdit.Text = "";
                TaxNumberEdit.Text = "";
                DateTimeEdit.Text = "";
                CarRegEdit.Text = "";
                ParkingSpaceIDEdit.Text = "";
                TrafficWardenID.Text = "";
                AmountEdit.Text = "";
                PaymentInfoEdit.Text = "";
                CarBrandEdit.Text = "";
                CvrnrEdit.Text = "";
            }
            


        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            string caseID =  CaseToRemoveCombobox.Text;
            ViewModel.EditCaseViewModel.RemoveTicketCase(caseID);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            ChoiceCase.Visibility = Visibility.Visible;
            RemoveCaseGrid.Visibility = Visibility.Hidden;
        }

        private void CancelEditBtn(object sender, RoutedEventArgs e)
        {
            ChoiceCase.Visibility = Visibility.Visible;
            TicketCaseEditGrid.Visibility = Visibility.Hidden;
            BottomGrid.Visibility = Visibility.Hidden;
        }
    }
}
