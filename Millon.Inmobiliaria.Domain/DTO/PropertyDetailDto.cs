using System;
using System.Collections.Generic;
using System.Text;

namespace Millon.Inmobiliaria.Domain.DTO
{
    public class PropertyDetailDto
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public List<string> Photo { get; set; }
        public string Owner { get; set; }
       
    }
}
