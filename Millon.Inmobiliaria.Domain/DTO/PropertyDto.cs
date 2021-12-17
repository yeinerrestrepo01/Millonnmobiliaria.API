using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Millon.Inmobiliaria.Domain.Entities
{
    /// <summary>
    ///  entidad Property
    /// </summary>
    public partial class PropertyDto
    {
        public int IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public int Status { get; set; }
        public int IdOwner { get; set; }
    }
}
