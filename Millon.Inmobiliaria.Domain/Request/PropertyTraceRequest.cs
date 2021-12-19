using Millon.Inmobiliaria.Domain.Emun;
using System;
using System.Collections.Generic;
using System.Text;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyTraceRequest
    {
        public PropertyTraceRequest()
        {
            MoneyType = (int)MoneyTypeEmun.USD;
        }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }
        public int? MoneyType { get; set; }
    }
}
