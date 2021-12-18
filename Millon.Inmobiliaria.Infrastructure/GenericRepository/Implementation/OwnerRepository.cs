using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.DBContext;
using Millon.Inmobiliaria.Infrastructure.UnitOfWork;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository.Implementation
{
    public class OwnerRepository : IOwnerRepository
    {
        /// <summary>
        /// Interfaz de unidad de trabajo
        /// </summary>
        private readonly IUnitOfwork _UnitWork;

        /// <summary>
        /// Inicializador de repositorio de Owner
        /// </summary>
        /// <param name="MillonInmobiliariaDbContext"></param>
        public OwnerRepository(MillonInmobiliariaDbContext MillonInmobiliariaDbContext)
        {
            _UnitWork = new UnitOfwork(MillonInmobiliariaDbContext);
        }

        public async Task<int> AddAsync(Owner Owner)
        {
            await _UnitWork.Owner.InsertAsync(Owner);
            return await _UnitWork.SaveAsync();
        }

        /// <summary>
        /// obtiene el listados de owner registrados en el sistema
        /// </summary>
        /// <returns></returns>
        public List<Owner> GetAll()
        {
            return _UnitWork.Owner.AsQueryable().ToList();
        }

        /// <summary>
        /// Busca un Owner en especifico
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public Owner GetById(int idOwner)
        {
            return _UnitWork.Owner.FirstOrDefault(o => o.IdOwner == idOwner);
        }
    }
}
