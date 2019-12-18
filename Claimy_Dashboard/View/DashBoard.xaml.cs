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
        }

        private void CloseDashBoard(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowCases(object sender, MouseButtonEventArgs e)
        {
            // show caselistview that has data about caseses
            caseListView.Visibility = Visibility.Visible;
            homePage.Visibility = Visibility.Hidden;
            // This is for "updating" the listview when a change happens
            // first we set the source to null
            caseListView.ItemsSource = null;
            // then we clear the listview
            caseListView.Items.Clear();
            // then we fill the list with data
            CasesTickets = ViewModel.ListsForListviews.CaseLsitMaker();
            // then we set the source to the list
            caseListView.ItemsSource = CasesTickets;            
            DataContext = this;

        }
        private void ShowHomePage(object sender, MouseButtonEventArgs e)
        {
            // hide the list view 
            caseListView.Visibility = Visibility.Hidden;
            homePage.Visibility = Visibility.Visible;
           
        }

        private void CalledHelp(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Why do you need help?\n call IT-supprot");

        }

        private void OpenEditCase(object sender, MouseButtonEventArgs e)
        {
            AddCase popUp = new AddCase();
            popUp.Show();
            
        }

        private void ShowSelectedCase(object sender, MouseButtonEventArgs e)
        {
            tbl_Image image = new tbl_Image();
            List<byte[]> images = new List<byte[]>();
            Full_Case_Ticket_View fctw = new Full_Case_Ticket_View();
            // shows the window where all info about a case is stored. 
            fctw.Show();
            var selectedItem = caseListView.SelectedItem as tbl_Ticket_Case;
            // getting the id of the selected case. 
            var caseID = selectedItem.fld_Case_Ticket_ID;            
            CasesTickets = new List<tbl_Ticket_Case>();
            CasesTickets = ViewModel.ListsForListviews.FullSingleTicketCase(caseID);
            //for displaying data from the selected 
            fctw.fullView.ItemsSource = CasesTickets;
            // making the list of images that are connected to the selected caseID
            images = ViewModel.ImageFromDB.ListOfImages(caseID);
            if (images.Count >0)
            {            
            // converting the binary "image" to a real image and showing it 
            fctw.iShowImage1.Source = ViewModel.ImageFromDB.ConvertToImage(images[0]);
            // if there is more than one iamge to the case. there can only be two
            if (images.Count >1)
            {
                if (images[1] != null)
                {
                    fctw.iShowImage2.Source = ViewModel.ImageFromDB.ConvertToImage(images[1]);
                }
            }
            }

        }

        private void EditEmployeesBtn(object sender, MouseButtonEventArgs e)
        {
            EditEmployees editEmployees = new EditEmployees();
            editEmployees.Show();
        }

        private void EditCustomerBtn(object sender, MouseButtonEventArgs e)
        {
            EditCustomerView editCustomer = new EditCustomerView();
            editCustomer.Show();
        }

    }
}
