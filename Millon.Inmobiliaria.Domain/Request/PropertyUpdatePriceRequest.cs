using System.ComponentModel.DataAnnotations;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyUpdatePriceRequest
    {
        [Required]
        public long NewPrice { get; set; }
    }
}
