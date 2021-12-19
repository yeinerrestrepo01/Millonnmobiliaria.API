using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Common;
using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
namespace Millon.Inmobiliaria.Application.Services
{
    /// <summary>
    /// Implementacion de Property
    /// </summary>
    public class PropertyServices: IPropertyServices
    {
        /// <summary>
        /// Interface de IPropertyRepository
        /// </summary>
        private readonly IPropertyRepository RepositoryProperty;

        /// <summary>
        /// Interface IOwnerRepository
        /// </summary>
        private readonly IOwnerRepository RepositoryOwner;

        /// <summary>
        /// objeto mapper MapperPropertyPropertyDto
        /// </summary>
        private readonly MapperMillon<Property, PropertyDto> MapperPropertyPropertyDto;

        /// <summary>
        /// objeto mapper MapperPropertyRequestToProperty
        /// </summary>
        private readonly MapperMillon<PropertyRequest, Property> MapperPropertyRequestToProperty;

        /// <summary>
        /// Inicializador de clase PropertyServices
        /// </summary>
        /// <param name="repositoryProperty"></param>
        public PropertyServices(IPropertyRepository repositoryProperty, IOwnerRepository repositoryOwner)
        {
            RepositoryProperty = repositoryProperty;
            MapperPropertyPropertyDto = new MapperMillon<Property, PropertyDto>();
            MapperPropertyRequestToProperty = new MapperMillon<PropertyRequest, Property>();
            RepositoryOwner = repositoryOwner;
        }

        /// <summary>
        /// Obtiene un listado de Property
        /// </summary>
        /// <param name="idProperty"></param>
        /// <returns></returns>
        public List<PropertyDto> GetAll()
        {
            var ResultQuery = RepositoryProperty.GetAll();
            return MapperPropertyPropertyDto.CrearMapper(ResultQuery);
        }

        /// <summary>
        /// Realzia la insercion de una Property
        /// </summary>
        /// <param name="Property"></param>
        /// <returns></returns>
        public async Task<ResponseDto<bool>> AddPropertyAsync(PropertyRequest Property)
        {
            var Response = new ResponseDto<bool>();
            var IsOwnerValid = RepositoryOwner.GetById(Property.IdOwner);
            if (IsOwnerValid == null)
            {
                Response.Message = Messages.No_Existe_Registro_Owner;
                Response.StatusCode = 204;
            }
            else
            {
                var MapperOwner = MapperPropertyRequestToProperty.CrearMapper(Property);
                var ResultAdd = await RepositoryProperty.AddAsync(MapperOwner);

                if (ResultAdd.Equals(0))
                {
                    Response.StatusCode = 202;
                }
                else
                {
                    Response.Message = Messages.Registro_Exitoso;
                    Response.Data = true;
                    Response.IsSuccess = true;
                }
            }
            return Response;
        }

        /// <summary>
        /// Obtiene el detalle de parametrizacion de una property, Image, Owner
        /// </summary>
        /// <param name="idProperty"></param>
        /// <returns></returns>
        public ResponseDto<PropertyDetailDto> GetByPropertyDetail(int idProperty)
        {
            var Response = new ResponseDto<PropertyDetailDto>();
            var ResponsePropertyDetail = RepositoryProperty.GetByPropertyDetail(idProperty);
            if (ResponsePropertyDetail == null)
            {
                Response.Message = Messages.No_Existe_Registro;
                Response.StatusCode = 204;
            }
            else
            {
                Response.Message = Messages.Consulta_Exitosa;
                Response.IsSuccess = true;
                Response.Data = ResponsePropertyDetail;
            }
            return Response;
        }

        /// <summary>
        /// consulta una Property por un Id especidicado
        /// </summary>
        /// <param name="idProperty"></param>
        /// <returns></returns>
        public ResponseDto<PropertyDto> GetById(int idProperty)
        {
            var Response = new ResponseDto<PropertyDto>();
            var GetEntity = RepositoryProperty.GetById(idProperty);
            if (GetEntity == null)
            {
                Response.Message = Messages.No_Existe_Registro;
                Response.StatusCode = 204;
            }
            else
            {
                Response.Message = Messages.Consulta_Exitosa;
                Response.IsSuccess = true;
                Response.Data = MapperPropertyPropertyDto.CrearMapper(GetEntity);
            }
            return Response;
        }

        public async Task<ResponseDto<bool>> UpdatePrice(int idProPerty,PropertyUpdatePriceRequest Property)
        {
            var Response = new ResponseDto<bool>();
            var GetEntity = RepositoryProperty.GetById(idProPerty);
            if (GetEntity == null)
            {
                Response.Message = Messages.No_Existe_Registro;
                Response.StatusCode = 204;
            }
            else
            {
                GetEntity.Price = Property.NewPrice;
                await RepositoryProperty.UpdateAsync(GetEntity);
                Response.Message = Messages.Consulta_Exitosa;
                Response.IsSuccess = true;
                Response.Data = true;
            }
            return Response;
        }
    }
}
