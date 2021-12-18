using System;
using System.Collections.Generic;
using System.Text;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyRequest
    {
        public PropertyRequest()
        {
            Status = 1;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int Status { get; set; }
        public int IdOwner { get; set; }
    }
}
