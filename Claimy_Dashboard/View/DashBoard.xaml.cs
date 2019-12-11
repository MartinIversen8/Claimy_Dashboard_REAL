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
            caseListView.Visibility = Visibility.Visible;            
           
        }
        private void HideAll(object sender, MouseButtonEventArgs e)
        {
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
        }

        private void ShowSelectedCase(object sender, MouseButtonEventArgs e)
        {
            Full_Case_Ticket_View fctw = new Full_Case_Ticket_View();
            fctw.Show();
            var selectedItem = caseListView.SelectedItem as tbl_Ticket_Case;
            var caseID = selectedItem.fld_Case_Ticket_ID;
            View.Full_Case_Ticket_View fct = new Full_Case_Ticket_View();
            CasesTickets = new List<tbl_Ticket_Case>();
            CasesTickets = ViewModel.ListsForListviews.FullSingleTicketCase(caseID);
            Console.WriteLine("VIRKER DET"+caseID);
            //DataContext = CasesTickets;
            fctw.fullView.ItemsSource = CasesTickets;
        }

    }
}
