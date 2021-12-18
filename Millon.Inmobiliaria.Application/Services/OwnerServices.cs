using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Common;
using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Application.Services
{
    public class OwnerServices : IOwnerServices
    {
        /// <summary>
        /// Implementaciones de Owner services
        /// </summary>
        private readonly IOwnerRepository RepositoryOwner;

        private readonly MapperMillon<Owner, OwnerDto> MapperOwnerToOwnerDto;

        private readonly MapperMillon<OwnerResquest, Owner> MapperOwnerDtoToOwner;

        /// <summary>
        /// Inicializador de clase OwnerServices
        /// </summary>
        /// <param name="repositoryOwner"></param>
        public OwnerServices(IOwnerRepository repositoryOwner)
        {
            RepositoryOwner = repositoryOwner;
            MapperOwnerToOwnerDto = new MapperMillon<Owner, OwnerDto>();
            MapperOwnerDtoToOwner = new MapperMillon<OwnerResquest, Owner>();
        }

        public async Task<ResponseDto<bool>> AddOwnerAsync(OwnerResquest Owner)
        {
            var Response = new ResponseDto<bool>();
            var MapperOwner = MapperOwnerDtoToOwner.CrearMapper(Owner);
            var ResultAdd = await RepositoryOwner.AddAsync(MapperOwner);

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
            return Response;
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
