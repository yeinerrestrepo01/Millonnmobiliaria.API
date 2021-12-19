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
            var resultadoQueryDeatil = _UnitWork.Property.AsQueryable().ToList()
                                    .Where(r => r.IdProperty == idProperty)
                                    .Select(t => new PropertyDetailDto
                                    {
                                        IdProperty = t.IdProperty,
                                        Address = t.Address,
                                        CodeInternal = t.CodeInternal,
                                        Name = t.Name,
                                        OwnerName = _UnitWork.Owner.AsQueryable().Where(o=> o.IdOwner == t.IdOwner).FirstOrDefault().Name,
                                        Photo = _UnitWork.PropertyImage.AsQueryable().Where(t => t.IdProperty == idProperty).Select(t => t.File).ToList(),
                                        Price = t.Price,
                                        Year = t.Year
                                    }).FirstOrDefault();
            return resultadoQueryDeatil;
        }

        /// <summary>
        /// Actualiaza el objeto Property
        /// </summary>
        /// <param name="Property"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(Property Property)
        {
            _UnitWork.Property.Update(Property);
            return await _UnitWork.SaveAsync();
        }
    }
}

