using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Millon.Inmobiliaria.Domain.Request
{
    public class OwnerResquest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public IFormFile Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
