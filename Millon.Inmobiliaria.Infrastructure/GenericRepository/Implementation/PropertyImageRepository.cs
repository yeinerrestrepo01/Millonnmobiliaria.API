using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.DBContext;
using Millon.Inmobiliaria.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository.Implementation
{
    public class PropertyImageRepository: IPropertyImageRepository
    {
        /// <summary>
        /// Interfaz de unidad de trabajo
        /// </summary>
        private readonly IUnitOfwork _UnitWork;

        /// <summary>
        /// Inicializador de repositorio de  PropertyImage
        /// </summary>
        /// <param name="MillonInmobiliariaDbContext"></param>
        public PropertyImageRepository(MillonInmobiliariaDbContext MillonInmobiliariaDbContext)
        {
            _UnitWork = new UnitOfwork(MillonInmobiliariaDbContext);
        }

        public async Task<int> AddAsync(PropertyImage PropertyImage)
        {
            await _UnitWork.PropertyImage.InsertAsync(PropertyImage);
            return await _UnitWork.SaveAsync();
        }

        /// <summary>
        /// obtiene el listados de PropertyImage registrados en el sistema
        /// </summary>
        /// <returns></returns>
        public List<PropertyImage> GetAll()
        {
            return _UnitWork.PropertyImage.AsQueryable().Where(t=> t.Enabled.Equals(true)).ToList();
        }

        /// <summary>
        /// Busca un PropertyImage en especifico
        /// </summary>
        /// <param name="idPropertyImage"></param>
        /// <returns></returns>
        public PropertyImage GetById(int idPropertyImage)
        {
            return _UnitWork.PropertyImage.FirstOrDefault(o => o.IdPropertyImage == idPropertyImage);
        }

        /// <summary>
        /// Realiza la actualizando del objeto PropertyImage
        /// </summary>
        /// <param name="PropertyImage"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(PropertyImage PropertyImage)
        {
            _UnitWork.PropertyImage.Update(PropertyImage);
            return await _UnitWork.SaveAsync();
        }
    }
}
