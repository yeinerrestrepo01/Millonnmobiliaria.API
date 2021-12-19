using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Millon.Inmobiliaria.Domain.Entities
{
    /// <summary>
    ///  entidad PropertyTrace
    /// </summary>
    public partial class PropertyTrace
    {
        [Key]
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string NameSale { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }
        public int IdMoneyType { get; set; }

        [ForeignKey("IdProperty")]
        public virtual Property IdPropertyNavegation { get; set; }

        [ForeignKey("IdMoneyType")]
        public virtual MoneyType MoneyTypeNavegation { get; set; }
    }
}
