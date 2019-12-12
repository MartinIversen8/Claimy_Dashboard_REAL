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
    /// Interaction logic for Full_Case_Ticket_View.xaml
    /// </summary>
    public partial class Full_Case_Ticket_View : Window
    {
        public Full_Case_Ticket_View()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tbl_Image image = new tbl_Image();
            byte[]  binaryImage = null;

            using (var context = new ClaimyEntities())
            {
                try
                {
                    

                    var imageBinary = from i in context.tbl_Image where i.fld_Image_ID.Equals(9999119) select i.fld_image;

                    foreach (var item in imageBinary)
                    {
                        binaryImage = item;
                    }

                    //image.ConvertToImage(binaryImage);
                    Console.WriteLine("DET HER ER THE BINARYIMAGE " + binaryImage);
                    iShowImage.Source= image.ConvertToImage(binaryImage);
                }
                catch (Exception ex)
                {

                    //Console.WriteLine(ex.InnerException.Message);
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
