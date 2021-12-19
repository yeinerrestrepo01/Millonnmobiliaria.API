using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.DBContext;
using Millon.Inmobiliaria.Infrastructure.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository.Implementation
{
    public class PropertyRepository : IPropertyRepository
    {
        /// <summary>
        /// Interfaz de unidad de trabajo
        /// </summary>
        private readonly IUnitOfwork _UnitWork;

        /// <summary>
        /// Inicializador de repositorio de Owner
        /// </summary>
        /// <param name="MillonInmobiliariaDbContext"></param>
        public PropertyRepository(MillonInmobiliariaDbContext MillonInmobiliariaDbContext)
        {
            _UnitWork = new UnitOfwork(MillonInmobiliariaDbContext);
        }

        /// <summary>
        /// Realiza la creacion de una Property
        /// </summary>
        /// <param name="Owner"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(Property Property)
        {
            await _UnitWork.Property.InsertAsync(Property);
            return await _UnitWork.SaveAsync();
        }

        /// <summary>
        /// obtiene el listados de Property registrados en el sistema
        /// </summary>
        /// <returns>List<Property> </returns>
        public List<Property> GetAll()
        {
            return _UnitWork.Property.AsQueryable().ToList();
        }

        /// <summary>
        /// Busca un Property en especifico
        /// </summary>
        /// <param name="idProperty"></param>
        /// <returns>Property</returns>
        public Property GetById(int idProperty)
        {
            return _UnitWork.Property.FirstOrDefault(o => o.IdProperty == idProperty);
        }

        /// <summary>
        /// Obtiene el detalle relacionado a la Property
        /// </summary>
        /// <param name="idProperty"></param>
        /// <returns></returns>
        public PropertyDetailDto GetByPropertyDetail(int idProperty)
        {
            var resultadoQueryDeatil = (from property in _UnitWork.Property.AsQueryable()
                                        join owner in _UnitWork.Owner.AsQueryable() on property.IdOwner equals owner.IdOwner
                                        join propertyImage in _UnitWork.PropertyImage.AsQueryable() on property.IdProperty equals propertyImage.IdProperty
                                        where propertyImage.Enabled.Equals(true)
                                        select new PropertyDetailDto
                                        {
                                            IdProperty = property.IdProperty,
                                            Address = property.Address,
                                            CodeInternal = property.CodeInternal,
                                            Name = property.Name,
                                            Owner = owner.Name,
                                            Photo = _UnitWork.PropertyImage.AsQueryable().Where(t=> t.IdProperty == property.IdProperty).Select(t=> t.File).ToList(),
                                            Price = property.Price,
                                            Year = property.Year,
                                        }
                                       ).FirstOrDefault();
            return resultadoQueryDeatil;
        }
    }
}
