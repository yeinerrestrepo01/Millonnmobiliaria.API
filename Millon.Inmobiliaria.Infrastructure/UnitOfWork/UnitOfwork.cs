using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.DBContext;
using Millon.Inmobiliaria.Infrastructure.Repository;
using System;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.UnitOfWork
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly MillonInmobiliariaDbContext _MillonInmobiliariaDbContext;

        private Repository<Owner> RepositoryOwner;

        private Repository<Property> RepositoryProperty;
        public UnitOfwork(MillonInmobiliariaDbContext MillonInmobiliariaDbContext)
        {
            _MillonInmobiliariaDbContext = MillonInmobiliariaDbContext;
        }

        /// <summary>
        /// Unidad de trabajo Repository<Owner> 
        /// </summary>
        public Repository<Owner> Owner
        {
            get
            {
                if (RepositoryOwner == null)
                    RepositoryOwner = new Repository<Owner>(_MillonInmobiliariaDbContext);

                return RepositoryOwner;
            }
        }

        /// <summary>
        /// Unidad de tranajo Repository<Property> 
        /// </summary>
        public Repository<Property> Property
        {
            get
            {
                if (RepositoryProperty == null)
                    RepositoryProperty = new Repository<Property>(_MillonInmobiliariaDbContext);

                return RepositoryProperty;
            }
        }

        public int Save() => _MillonInmobiliariaDbContext.SaveChanges();
        public async Task<int> SaveAsync() => await _MillonInmobiliariaDbContext.SaveChangesAsync();

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _MillonInmobiliariaDbContext.Dispose();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
