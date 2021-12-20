using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class PropertyImageUpdateRequest
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
