using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.DBContext;
using Millon.Inmobiliaria.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository.Implementation
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        /// <summary>
        /// Interfaz de unidad de trabajo
        /// </summary>
        private readonly IUnitOfwork _UnitWork;

        /// <summary>
        /// Inicializador de clase repositorio PropertyTraceRepository
        /// </summary>
        /// <param name="MillonInmobiliariaDbContext"></param>
        public PropertyTraceRepository(MillonInmobiliariaDbContext MillonInmobiliariaDbContext)
        {
            _UnitWork = new UnitOfwork(MillonInmobiliariaDbContext);
        }

        /// <summary>
        ///  Realiza el registro de un  property trace
        /// </summary>
        /// <param name="PropertyTrace"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(PropertyTrace PropertyTrace)
        {
            await _UnitWork.PropertyTrace.InsertAsync(PropertyTrace);
            return await _UnitWork.SaveAsync();
        }

        /// <summary>
        /// Obtiene todos los Property trace
        /// </summary>
        /// <returns></returns>
        public List<PropertyTrace> GetAll()
        {
            return _UnitWork.PropertyTrace.AsQueryable().ToList();
        }

        /// <summary>
        /// Obtiene un Property Trace en especifico
        /// </summary>
        /// <param name="idPropertyTrace"></param>
        /// <returns></returns>
        public PropertyTrace GetById(int idPropertyTrace)
        {
            return _UnitWork.PropertyTrace.FirstOrDefault(o => o.IdPropertyTrace == idPropertyTrace);
        }
    }
}
