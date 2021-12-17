using Microsoft.EntityFrameworkCore;
using Millon.Inmobiliaria.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.Repository
{
        public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            /// <summary>
            /// The dbcontext
            /// </summary>
            private readonly MillonInmobiliariaDbContext _dbcontext;
            /// <summary>
            /// The entities
            /// </summary>
            private readonly DbSet<TEntity> _entities;

            /// <summary>
            /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
            /// </summary>
            /// <param name="dbcontext">The dbcontext.</param>
            public Repository(MillonInmobiliariaDbContext dbcontext)
            {
                this._dbcontext = dbcontext;
                this._entities = dbcontext.Set<TEntity>();
            }

        #region IRepository<TEntity> Members
        /// <summary>
        /// Ases the queryable.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        /// Retorna un objeto del tipo AsQueryable
        public IQueryable<TEntity> AsQueryable()
        {
            return _entities.AsQueryable<TEntity>();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// Registra una entidad
        public void Insert(TEntity entity)
            {
                _entities.Add(entity);
            }

            /// <summary>
            /// Inserts the specified entities.
            /// </summary>
            /// <param name="entities">The entities.</param>
            /// Registra varias entidades
            public void Insert(IEnumerable<TEntity> entities)
            {
                foreach (var e in entities)
                {
                    _dbcontext.Entry(e).State = EntityState.Added;
                }
            }

            /// <summary>
            /// insert as an asynchronous operation.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// <returns>Task.</returns>
            public async Task InsertAsync(TEntity entity)
            {
                await _entities.AddAsync(entity);
            }

            /// <summary>
            /// insert as an asynchronous operation.
            /// </summary>
            /// <param name="entities">The entities.</param>
            /// <returns>Task.</returns>
            public async Task InsertAsync(IEnumerable<TEntity> entities)
            {

                foreach (var e in entities)
                {
                    await _entities.AddAsync(e);
                }
            }
            /// <summary>
            /// Updates the specified entity.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// Actualiza una entidad
            public void Update(TEntity entity)
            {
                _entities.Attach(entity);
                _dbcontext.Entry(entity).State = EntityState.Modified;
            }

            /// <summary>
            /// Updates the specified entities.
            /// </summary>
            /// <param name="entities">The entities.</param>
            /// Actualiza varias entidades
            public void Update(IEnumerable<TEntity> entities)
            {
                foreach (var e in entities)
                {
                    _dbcontext.Entry(e).State = EntityState.Modified;
                }
            }

            /// <summary>
            /// Truncates the table.
            /// </summary>
            /// <param name="tableName">Name of the table.</param>
            public void TruncateTable(string tableName)
            {
                _dbcontext.Database.ExecuteSqlRaw($"TRUNCATE TABLE {tableName}");
            }

            /// <summary>
            /// Deletes the specified identifier.
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// Elimina por Id
            public void Delete(object id)
            {
                TEntity entityToDelete = _entities.Find(id);
                _entities.Remove(entityToDelete);
            }

            /// <summary>
            /// Deletes the specified entity.
            /// </summary>
            /// <param name="entity">The entity.</param>
            /// Elimina una entidad
            public void Delete(TEntity entity)
            {
                if (_dbcontext.Entry(entity).State == EntityState.Detached)
                {
                    _entities.Attach(entity);
                }
                _entities.Remove(entity);
            }

            /// <summary>
            /// Deletes the specified entities.
            /// </summary>
            /// <param name="entities">The entities.</param>
            /// Elimina un conjuto de entidades
            public void Delete(IEnumerable<TEntity> entities)
            {
                foreach (var e in entities)
                {
                    _dbcontext.Entry(e).State = EntityState.Deleted;
                }
            }
            #endregion
        }
    }