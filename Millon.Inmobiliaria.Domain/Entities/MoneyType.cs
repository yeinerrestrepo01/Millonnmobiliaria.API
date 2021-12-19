using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Millon.Inmobiliaria.Domain.Entities
{
    public class MoneyType
    {
        [Key]
        public int IdMoneyType { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
