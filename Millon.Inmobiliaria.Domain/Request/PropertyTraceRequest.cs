using Millon.Inmobiliaria.Domain.Emun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyTraceRequest
    {
        public PropertyTraceRequest()
        {
            IdMoneyType = (int)MoneyTypeEmun.USD;
        }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        [Required]
        public double Value { get; set; }
        public double Tax { get; set; }
        [Required]
        public int IdProperty { get; set; }
        [Required]
        public int IdMoneyType { get; set; }
    }
}
