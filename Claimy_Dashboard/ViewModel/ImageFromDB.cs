using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Claimy_Dashboard.EF;

namespace Claimy_Dashboard.ViewModel
{
    public class ImageFromDB 
    {
        // converting a image from binary to an actual image
        public static List<byte[]> ListOfImages(string caseID)
        {
            tbl_Image image = new tbl_Image();
            byte[] binaryImage = null;
            List<byte[]> binaryImages = new List<byte[]>();

            using (var context = new ClaimyEntities())
            {
                try
                {

                    // selecting images where caseId is equal to input
                    var imageBinary = from i in context.tbl_Image where i.fld_Ticket_ID.Equals(caseID) select i.fld_image;
                    // adding images to a list that we return 
                    foreach (var item in imageBinary)
                    {
                        binaryImage = item;
                        binaryImages.Add(item);
                    }

                    // returning list
                    return binaryImages;


                }
                catch (Exception ex)
                {

                    
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }
    }
}
