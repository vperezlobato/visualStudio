using _07_CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _07_CRUD_Personas_UI.Models
{
    public class ConvertirImagenAByte
    {

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;

        }
    }
}