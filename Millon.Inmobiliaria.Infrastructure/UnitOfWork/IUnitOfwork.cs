using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.Repository;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.UnitOfWork
{
    public interface IUnitOfwork
    {
        Repository<Owner> Owner { get; }
        void Dispose();
        int Save();
        Task<int> SaveAsync();
    }
}
