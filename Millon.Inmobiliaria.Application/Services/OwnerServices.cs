using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Common;
using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using System.Collections.Generic;

namespace Millon.Inmobiliaria.Application.Services
{
    public class OwnerServices : IOwnerServices
    {
        private readonly IOwnerRepository RepositoryOwner;

        private readonly MapperMillon<Owner, OwnerDto> MapperOwnerToOwnerDto;

        /// <summary>
        /// Inicializador de clase OwnerServices
        /// </summary>
        /// <param name="repositoryOwner"></param>
        public OwnerServices(IOwnerRepository repositoryOwner)
        {
            RepositoryOwner = repositoryOwner;
            MapperOwnerToOwnerDto = new MapperMillon<Owner, OwnerDto>();
        }

        /// <summary>
        /// Obtiene un listado de los owner registrados
        /// </summary>
        /// <returns>List : OwnerDto</returns>
        public List<OwnerDto> GetAll()
        {
           var ResulQuery = RepositoryOwner.GetAll();
           return MapperOwnerToOwnerDto.CrearMapper(ResulQuery);
        }

        /// <summary>
        /// Obtiene un owner filtrado por Id
        /// </summary>
        /// <param name="idOwner">idOwner</param>
        /// <returns>OwnerDto</returns>
        public ResponseDto<OwnerDto> GetById(int idOwner)
        {
            var Response = new ResponseDto<OwnerDto>();
            var GetEntity = RepositoryOwner.GetById(idOwner);
            if (GetEntity == null)
            {
                Response.Message = Messages.No_Existe_Registro;
                Response.StatusCode = 204;
            }
            else
            {
                Response.Message = Messages.Consulta_Exitosa;
                Response.IsSuccess = true;
                Response.Data = MapperOwnerToOwnerDto.CrearMapper(GetEntity);
            }
            return Response;
        }
    }
}
