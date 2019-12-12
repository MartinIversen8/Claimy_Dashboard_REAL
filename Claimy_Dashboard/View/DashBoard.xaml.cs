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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Claimy_Dashboard.EF;
using Claimy_Dashboard.View;

namespace Claimy_Dashboard.View
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public List<tbl_Ticket_Case> CasesTickets { get; set; }
        
        public DashBoard()
        {
            InitializeComponent();
            // loading data from database int a list so it can be shown in the listview. 
            caseListView.Visibility = Visibility.Hidden;
            CasesTickets = new List<tbl_Ticket_Case>();
            CasesTickets = ViewModel.ListsForListviews.CaseLsitMaker();            
            DataContext = this;
            
        }

        private void CloseDashBoard(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowCases(object sender, MouseButtonEventArgs e)
        {
            // show caselistview that has data about caseses
            caseListView.Visibility = Visibility.Visible;            
           
        }
        private void HideAll(object sender, MouseButtonEventArgs e)
        {
            // hide the list view 
            caseListView.Visibility = Visibility.Hidden;
        }

        private void CalledHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Why do you need help?\n call IT-supprot");

        }

        private void OpenAddCase(object sender, MouseButtonEventArgs e)
        {
            AddCase popUp = new AddCase();
            popUp.Show();
            tbl_Image image = new tbl_Image();
            byte[] photo = image.GetPhotoToBinary(@"C:\\Users\Marti\Desktop\P-Bøde.png");

            //using (var context = new ClaimyEntities())
            //{
            //    try
            //    {
            //        // prøv at få fine-reason og case_no til at komme automatisk 
            //        //var @case = new tbl_Case() { fld_Case_NO = 898990, fld_ParkingFine_Reason = fine_reason.Text, fld_Precedens = Precedens.Text, fld_Status = StatusCombo.Text, fld_EMP_ID = 999999999 };
            //        //context.tbl_Case.Add(@case);
            //        //context.SaveChanges();
            //        // Is it successfull maybe
            //        //Console.WriteLine("" + @case.fld_Case_NO);

            //        var photoToDB = new tbl_Image() { fld_Image_ID=9999119,fld_image=photo,fld_Ticket_ID="C20-1" };
            //        context.tbl_Image.Add(photoToDB);
            //        context.SaveChanges();
            //        Console.WriteLine("Det virkede "+photoToDB.fld_Image_ID);
            //    }
            //    catch (Exception ex)
            //    {

            //        Console.WriteLine(ex.InnerException.Message);
            //    }

            //}


        }

        private void ShowSelectedCase(object sender, MouseButtonEventArgs e)
        {
            Full_Case_Ticket_View fctw = new Full_Case_Ticket_View();
            // shows the window where all info about a case is stored. 
            fctw.Show();
            var selectedItem = caseListView.SelectedItem as tbl_Ticket_Case;
            // getting the id of the selected case. 
            var caseID = selectedItem.fld_Case_Ticket_ID;
            View.Full_Case_Ticket_View fct = new Full_Case_Ticket_View();
            CasesTickets = new List<tbl_Ticket_Case>();
            CasesTickets = ViewModel.ListsForListviews.FullSingleTicketCase(caseID);
            //for displaying data from the selected 
            fctw.fullView.ItemsSource = CasesTickets;
        }

    }
}
