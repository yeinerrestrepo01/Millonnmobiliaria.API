using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyImageRequest
    {
        public PropertyImageRequest()
        {
            Enabled = true;
        }
        [Required]
        public int IdProperty { get; set; }
        [Required]
        public IFormFile File { get; set; }
        public bool Enabled { get; set; }
    }
}
