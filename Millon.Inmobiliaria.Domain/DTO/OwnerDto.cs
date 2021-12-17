using System;
namespace Millon.Inmobiliaria.Domain.Entities
{
    public class OwnerDto
    {
        public int IdOwner { get; set; }
        public string Nambe { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
