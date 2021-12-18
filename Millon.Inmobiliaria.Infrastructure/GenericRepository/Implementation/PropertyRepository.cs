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
        public async Task<int> AddAsync(Property Owner)
        {
            await _UnitWork.Property.InsertAsync(Owner);
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
    }
}
