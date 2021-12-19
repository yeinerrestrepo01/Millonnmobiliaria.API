using Millon.Inmobiliaria.Domain.Emun;
namespace Millon.Inmobiliaria.Domain.Entities
{
    /// <summary>
    ///  entidad Property
    /// </summary>
    public  class PropertyDto
    {
        /// <summary>
        ///  PropertyDto
        /// </summary>
        public PropertyDto()
        {
            Status = (int)StatatusPropertysEmun.Disponible;
        }
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
