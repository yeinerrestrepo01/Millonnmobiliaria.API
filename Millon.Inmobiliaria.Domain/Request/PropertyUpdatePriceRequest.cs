using System.ComponentModel.DataAnnotations;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyUpdatePriceRequest
    {
        [Required]
        public double NewPrice { get; set; }
    }
}
