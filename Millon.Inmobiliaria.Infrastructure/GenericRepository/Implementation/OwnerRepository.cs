using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.DBContext;
using Millon.Inmobiliaria.Infrastructure.UnitOfWork;
using System.Linq;
using System.Collections.Generic;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository.Implementation
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IUnitOfwork _UnitWork;
        public OwnerRepository(MillonInmobiliariaDbContext MillonInmobiliariaDbContext)
        {
            _UnitWork = new UnitOfwork(MillonInmobiliariaDbContext);
        }
        public List<Owner> GetAll()
        {
            return _UnitWork.Owner.AsQueryable().ToList();
        }
    }
}
