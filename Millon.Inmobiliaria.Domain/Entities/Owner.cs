using System;
using System.ComponentModel.DataAnnotations;
namespace Millon.Inmobiliaria.Domain.Entities
{
    public partial class Owner
    {
        [Key]
        public int IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
