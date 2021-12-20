using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyRequest
    {
        public PropertyRequest()
        {
            Status = 1;
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int Status { get; set; }
        [Required]
        public int IdOwner { get; set; }
    }
}
