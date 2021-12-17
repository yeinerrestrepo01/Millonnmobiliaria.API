using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region IRepository<T> Members

        /// Retorna un objeto del tipo AsQueryable       
        IQueryable<TEntity> AsQueryable();

        /// Registra una entidad       
        void Insert(TEntity entity);


        /// Registra varias entidades       
        void Insert(IEnumerable<TEntity> entities);

        Task InsertAsync(TEntity entity);

        Task InsertAsync(IEnumerable<TEntity> entities);

        /// Actualiza una entidad      
        void Update(TEntity entity);


        /// Actualiza varias entidades      
        void Update(IEnumerable<TEntity> entities);


        /// Elimina una entidad       
        void Delete(TEntity entity);


        /// Elimina por Id   
        void Delete(object id);


        /// Elimina un conjuto de entidades       
        void Delete(IEnumerable<TEntity> entities);

        #endregion

    }
}
