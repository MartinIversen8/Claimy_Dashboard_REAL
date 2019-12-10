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
        public AddCase()
        {
            
            InitializeComponent();
        }

       

        private void SubmitCase(object sender, RoutedEventArgs e)
        {
            
            using (var context = new ClaimyEntities())
            {
                try
                {
                    // prøv at få fine-reason og case_no til at komme automatisk 
                    //var @case = new tbl_Case() { fld_Case_NO = 898990, fld_ParkingFine_Reason = fine_reason.Text, fld_Precedens = Precedens.Text, fld_Status = StatusCombo.Text, fld_EMP_ID = 999999999 };
                    //context.tbl_Case.Add(@case);
                    //context.SaveChanges();
                    // Is it successfull maybe
                    //Console.WriteLine("" + @case.fld_Case_NO);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.InnerException.Message);
                }
            
            }

            Precedens.Text = "";
            CaseNo.Text = "";
            StatusCombo.Text = "";
            fine_reason.Text = "";

        }

        
    }
}
