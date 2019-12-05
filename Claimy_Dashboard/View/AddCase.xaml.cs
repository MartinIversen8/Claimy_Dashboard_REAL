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
            

            Precedens.Text = "";
            CaseNo.Text = "";
            StatusCombo.Text = "";
            fine_reason.Text = "";

        }
    }
}
