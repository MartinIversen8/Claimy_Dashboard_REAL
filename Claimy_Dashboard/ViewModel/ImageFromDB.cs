using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Claimy_Dashboard.EF;
using System.Windows.Media.Imaging;

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

        public static byte[] GetPhotoToBinary(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        public static BitmapImage ConvertToImage(byte[] binary)
        {
            byte[] buffer = binary;
            MemoryStream stream = new MemoryStream(buffer);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
    }
}
