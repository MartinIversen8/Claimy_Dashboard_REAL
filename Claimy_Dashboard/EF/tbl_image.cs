namespace Claimy_Dashboard.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Windows.Media.Imaging;
    public partial class tbl_Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fld_Image_ID { get; set; }

        public byte[] fld_image { get; set; }

        [StringLength(50)]
        public string fld_Ticket_ID { get; set; }

        public virtual tbl_Ticket_Case tbl_Ticket_Case { get; set; }

        // til at gemme et billede i Database?? 
        public byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder(); // or some other encoder
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }                       
        }

        public  byte[] GetPhotoToBinary(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);

            byte[] photo = reader.ReadBytes((int)stream.Length);

            reader.Close();
            stream.Close();

            return photo;
        }

        public BitmapImage ConvertToImage(byte[] binary)
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
