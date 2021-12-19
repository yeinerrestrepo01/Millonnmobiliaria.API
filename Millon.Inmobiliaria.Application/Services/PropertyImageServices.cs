using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Application.Services
{
    public class PropertyImageServices: IPropertyImageServices
    {
        /// <summary>
        /// Interface de IPropertyRepository
        /// </summary>
        private readonly IPropertyRepository RepositoryProperty;

        private readonly IPropertyImageRepository RepositoryPropertyImage;

        /// <summary>
        /// Inicializador de clase PropertyImageServices
        /// </summary>
        /// <param name="repositoryProperty"></param>
        /// <param name="repositoryPropertyImage"></param>
        public PropertyImageServices(IPropertyRepository repositoryProperty,
            IPropertyImageRepository repositoryPropertyImage)
        {
            RepositoryProperty = repositoryProperty;
            RepositoryPropertyImage = repositoryPropertyImage;
        }

        public Task<ResponseDto<bool>> AddPropertyImageAsync(PropertyImageRequest Property)
        {
            throw new NotImplementedException();
        }

        public List<PropertyImageDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ResponseDto<PropertyImageDto> GetByIdProperty(int idProperty)
        {
            throw new NotImplementedException();
        }
    }
}
