using AutoMapper;
using System.Collections.Generic;

namespace Millon.Inmobiliaria.Common
{
    /// <summary>
    /// Mapper de entidades generico
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public class MapperMillon<TSource, TDestination>
    {

        /// <summary>
        /// Objeto de configuracion de mapper
        /// </summary>
        private readonly MapperConfiguration ConfigurationProvider;

        /// <summary>
        /// Inicializador de clase MapperMillon
        /// </summary>
        public MapperMillon()
        {
            ConfigurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<TSource, TDestination>();
            });
        }

        /// <summary>
        /// Inializacion de creacion de Mapper para una entidad
        /// </summary>
        /// <param name="Source">entidad origen</param>
        /// <returns>entidad destino</returns>
        public TDestination CrearMapper(TSource Source)
        {
            var MapperEntity = new Mapper(ConfigurationProvider);
            var ResultMapper = MapperEntity.Map<TSource, TDestination>(Source);
            return ResultMapper;
        }

        public List<TDestination> CrearMapper(List<TSource> Source)
        {
            var MapperEntity = new Mapper(ConfigurationProvider);
            var ResultMapper = MapperEntity.Map<List<TDestination>>(Source);
            return ResultMapper;
        }
    }
}
