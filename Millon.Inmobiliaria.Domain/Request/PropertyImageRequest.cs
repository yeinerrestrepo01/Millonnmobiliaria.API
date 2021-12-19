using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyImageRequest
    {
        public PropertyImageRequest()
        {
            Enabled = true;
        }
        public int IdProperty { get; set; }
        public IFormFile File { get; set; }
        public bool Enabled { get; set; }
    }
}
