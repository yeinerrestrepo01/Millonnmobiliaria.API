using Microsoft.Extensions.DependencyInjection;
using Millon.Inmobiliaria.Application.Services;
using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using Millon.Inmobiliaria.Infrastructure.GenericRepository.Implementation;
using Millon.Inmobiliaria.Infrastructure.Repository;
using Millon.Inmobiliaria.Infrastructure.UnitOfWork;

namespace Millon.Inmobiliaria.API.Middleware
{
    public static class IoC
    {
        /// <summary>
        ///  Adds the dependency.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Infrastructure
            #region Infrastructure
            services.AddTransient<IUnitOfwork, UnitOfwork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            //Services
            #region Services
            services.AddTransient<IOwnerServices, OwnerServices>();
            services.AddTransient<IPropertyServices, PropertyServices>();
            services.AddTransient<IPropertyImageServices, PropertyImageServices>();
            services.AddTransient<IPropertyTraceServices, PropertyTraceServices>();
            #endregion

            #region Repository
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IPropertyRepository, PropertyRepository>();
            services.AddTransient<IPropertyImageRepository, PropertyImageRepository>();
            services.AddTransient<IPropertyTraceRepository, PropertyTraceRepository>();
            #endregion

            return services;
        }
    }
}
