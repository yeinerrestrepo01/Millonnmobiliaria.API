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
    /// <summary>
    /// clase de servicio OwnerServices
    /// </summary>
    public class OwnerServices : IOwnerServices
    {
        /// <summary>
        /// Implementaciones de Owner services
        /// </summary>
        private readonly IOwnerRepository RepositoryOwner;

        /// <summary>
        /// objeto mapper MapperOwnerToOwnerDto
        /// </summary>
        private readonly MapperMillon<Owner, OwnerDto> MapperOwnerToOwnerDto;

        /// <summary>
        /// objeto mapper MapperOwnerDtoToOwner
        /// </summary>
        private readonly MapperMillon<OwnerResquest, Owner> MapperOwnerDtoToOwner;

        /// <summary>
        /// Objeto para manejador de archivos
        /// </summary>
        private readonly FileUpload FileUpload;

        /// <summary>
        /// Inicializador de clase OwnerServices
        /// </summary>
        /// <param name="repositoryOwner"></param>
        public OwnerServices(IOwnerRepository repositoryOwner)
        {
            RepositoryOwner = repositoryOwner;
            MapperOwnerToOwnerDto = new MapperMillon<Owner, OwnerDto>();
            MapperOwnerDtoToOwner = new MapperMillon<OwnerResquest, Owner>();
            FileUpload = new FileUpload();
        }

        public async Task<ResponseDto<bool>> AddOwnerAsync(OwnerResquest Owner)
        {
            var Message = string.Empty;
            var ResulFile =  FileUpload.SenFile(Owner.Photo, FilePath.PathFileOwner, ref Message);
            var MapperOwner = MapperOwnerDtoToOwner.CrearMapper(Owner);
            MapperOwner.Photo = ResulFile;
            var ResulAddOwner = await AddInformacionOwner(MapperOwner, Message);
            return ResulAddOwner;
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
                Response.Message = Messages.No_Existe_Registro_Owner;
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

        private async Task<ResponseDto<bool>> AddInformacionOwner(Owner Owner, string Message)
        {
            var ResultAddOwner = await RepositoryOwner.AddAsync(Owner);
            var Response = new ResponseDto<bool>();
            if (ResultAddOwner.Equals(0))
            {
                Response.StatusCode = 202;
                Response.Message = Messages.Registro_No_Exitoso;
            }
            else
            {
                Response.Message = Messages.Registro_Exitoso + Message;
                Response.Data = true;
                Response.IsSuccess = true;
            }
            return Response;
        }
    }
}
