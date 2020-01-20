using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CRUD_Personas_netcore_UI.Models
{
    public class ConvertirImagenAByte
    {

        public byte[] ConvertToBytes(IFormFile file)
        {
            var ms = new MemoryStream();
            file.OpenReadStream().CopyTo(ms);
            byte[] Value = ms.ToArray();

            return Value;
        }
    }
}