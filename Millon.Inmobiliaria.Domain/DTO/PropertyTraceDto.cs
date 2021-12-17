using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Millon.Inmobiliaria.Domain.Entities
{
    /// <summary>
    ///  entidad PropertyTrace
    /// </summary>
    public class PropertyTraceDto
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }
    }
}
