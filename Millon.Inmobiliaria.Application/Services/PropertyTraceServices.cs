using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Common;
using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Emun;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Application.Services
{
    public class PropertyTraceServices : IPropertyTraceServices
    {

        /// <summary>
        /// Iterface RepositoryPropertyTrace
        /// </summary>
        public IPropertyTraceRepository RepositoryPropertyTrace;

        /// <summary>
        /// Interface de IPropertyRepository
        /// </summary>
        private readonly IPropertyRepository RepositoryProperty;

        /// <summary>
        /// objeto mapper MapperPropertyTraceToPropertyTraceDto
        /// </summary>
        private readonly MapperMillon<PropertyTrace, PropertyTraceDto> MapperPropertyTraceToPropertyTraceDto;

        /// <summary>
        /// objeto mapper MapperPropertyTraceRequestToPropertyTrace
        /// </summary>
        private readonly MapperMillon<PropertyTraceRequest, PropertyTrace> MapperPropertyTraceRequestToPropertyTrace;

        /// <summary>
        /// Inicializadir de clase de servicio PropertyTraceServices
        /// </summary>
        public PropertyTraceServices(IPropertyTraceRepository repositoryPropertyTrace, IPropertyRepository repositoryProperty)
        {
            RepositoryPropertyTrace = repositoryPropertyTrace;
            RepositoryProperty = repositoryProperty;
            MapperPropertyTraceToPropertyTraceDto = new MapperMillon<PropertyTrace, PropertyTraceDto>();
            MapperPropertyTraceRequestToPropertyTrace = new MapperMillon<PropertyTraceRequest, PropertyTrace>();
        }

        /// <summary>
        /// Inserta re informacion relacionada con sale propety
        /// </summary>
        /// <param name="Property"></param>
        /// <returns></returns>
        public async Task<ResponseDto<bool>> AddPropertyAsync(PropertyTraceRequest Property)
        {
            var Response = new ResponseDto<bool>();
            var IsPropertyValid = RepositoryProperty.GetById(Property.IdProperty);
            if (IsPropertyValid == null)
            {
                Response.Message = Messages.No_Existe_Registro_Property;
                Response.StatusCode = 204;
            }
            else
            {
                var MapperPropertyTrace = MapperPropertyTraceRequestToPropertyTrace.CrearMapper(Property);
                var ResultAdd = await RepositoryPropertyTrace.AddAsync(MapperPropertyTrace);

                if (ResultAdd.Equals(0))
                {
                    Response.StatusCode = 202;
                }
                else
                {
                    IsPropertyValid.Status = (int)StatatusPropertysEmun.Vendido;
                    await RepositoryProperty.UpdateAsync(IsPropertyValid);
                    Response.Message = Messages.Registro_Exitoso;
                    Response.Data = true;
                    Response.IsSuccess = true;
                }
            }
            return Response;
        }

        /// <summary>
        /// Obtiene el listado de Property Sale
        /// </summary>
        /// <returns></returns>
        public List<PropertyTraceDto> GetAll()
        {
            var QueryResult = RepositoryPropertyTrace.GetAll();
            return MapperPropertyTraceToPropertyTraceDto.CrearMapper(QueryResult);
        }

        /// <summary>
        /// Obtiene la informacon relacionada con con una property Sale
        /// </summary>
        /// <param name="idProperty"></param>
        /// <returns></returns>
        public ResponseDto<PropertyTraceDto> GetById(int idProperty)
        {
            var Response = new ResponseDto<PropertyTraceDto>();
            var GetEntity = RepositoryPropertyTrace.GetById(idProperty);
            if (GetEntity == null)
            {
                Response.Message = Messages.No_Existe_Registro;
                Response.StatusCode = 204;
            }
            else
            {
                Response.Message = Messages.Consulta_Exitosa;
                Response.IsSuccess = true;
                Response.Data = MapperPropertyTraceToPropertyTraceDto.CrearMapper(GetEntity);
            }
            return Response;
        }
    }
}
