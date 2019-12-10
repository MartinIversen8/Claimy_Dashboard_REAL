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
            CasesTickets = CaseLsitMaker();            
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

        private static List<tbl_Ticket_Case> CaseLsitMaker()
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
    }
}
