using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Common;
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

        /// <summary>
        /// Interface RepositoryPropertyImage
        /// </summary>
        private readonly IPropertyImageRepository RepositoryPropertyImage;

        /// <summary>
        /// objeto mapper MapperPropertyPropertyDto
        /// </summary>
        private readonly MapperMillon<PropertyImage, PropertyImageDto> MapperPropertyImagePropertyImageDto;

        /// <summary>
        /// objeto mapper MapperPropertyImageRequestToPropertyImage
        /// </summary>
        private readonly MapperMillon<PropertyImageRequest, PropertyImage> MapperPropertyImageRequestToPropertyImage;

        /// <summary>
        /// Objeto para manejador de archivos
        /// </summary>
        private readonly FileUpload FileUpload;

        /// <summary>
        /// Objeto de respuesta genreico
        /// </summary>
        private   ResponseDto<bool> ResponseDto;

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
            MapperPropertyImagePropertyImageDto = new MapperMillon<PropertyImage, PropertyImageDto>();
            MapperPropertyImageRequestToPropertyImage = new MapperMillon<PropertyImageRequest, PropertyImage>();
            FileUpload = new FileUpload();
            ResponseDto = new ResponseDto<bool>();
        }

        /// <summary>
        /// Realiza la orquestacion de creacion de nuevo registro para dPropertyImage
        /// </summary>
        /// <param name="Property"></param>
        /// <returns></returns>
        public async Task<ResponseDto<bool>> AddPropertyImageAsync(PropertyImageRequest Property)
        {
            var Message = string.Empty;
            
            var IsPropertyValid = RepositoryProperty.GetById(Property.IdProperty);
            if (IsPropertyValid == null)
            {
                ResponseDto.Message = Messages.No_Existe_Registro_Property;
                ResponseDto.StatusCode = 204;
            }
            else
            {
                var ResulFile = FileUpload.SenFile(Property.File, FilePath.PathFileProperty, ref Message);
                ResponseDto = await AddInformacionPropertyImageRequest(Property, Message, ResulFile);
                
            }
            return ResponseDto;
        }

        /// <summary>
        /// Obtiene el listado de Imaganes asociados a una Property
        /// </summary>
        /// <returns></returns>
        public List<PropertyImageDto> GetAll()
        {
            var ResulQuery = RepositoryPropertyImage.GetAll();
            return MapperPropertyImagePropertyImageDto.CrearMapper(ResulQuery);
        }

        /// <summary>
        /// obtiene el listado de imagenes asociados a una PropertyImage en especifico
        /// </summary>
        /// <param name="idPropertyImage"></param>
        /// <returns></returns>
        public ResponseDto<PropertyImageDto> GetById(int idPropertyImage)
        {
            var GetEntity = RepositoryPropertyImage.GetById(idPropertyImage);
            return  ValidationQuery(GetEntity);
        }

        /// <summary>
        /// Valida el resultado de la busquedad de una propiedad o property Image
        /// </summary>
        /// <param name="PropertyImage"></param>
        /// <returns></returns>
        private ResponseDto<PropertyImageDto> ValidationQuery(PropertyImage PropertyImage) 
        {
            var ResponseValidation = new ResponseDto<PropertyImageDto>();
            if (PropertyImage == null)
            {
                ResponseValidation.Message = Messages.No_Existe_Registro;
                ResponseValidation.StatusCode = 204;
            }
            else
            {
                ResponseValidation.Message = Messages.Consulta_Exitosa;
                ResponseValidation.IsSuccess = true;
                ResponseValidation.Data = MapperPropertyImagePropertyImageDto.CrearMapper(PropertyImage);
            }

            return ResponseValidation;
        }

        /// <summary>
        /// Realiza la adicion de un nuevo registro de Property Image
        /// </summary>
        /// <param name="Property"></param>
        /// <param name="Message"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        private async Task<ResponseDto<bool>> AddInformacionPropertyImageRequest(PropertyImageRequest Property, string Message, string FilePath)
        {
            var MapperPropeertyImage = MapperPropertyImageRequestToPropertyImage.CrearMapper(Property);
            MapperPropeertyImage.File = FilePath;
            var ResultAdd = await RepositoryPropertyImage.AddAsync(MapperPropeertyImage);

            if (ResultAdd.Equals(0))
            {
                ResponseDto.StatusCode = 202;
            }
            else
            {
                ResponseDto.Message = Messages.Registro_Exitoso + Message; ;
                ResponseDto.Data = true;
                ResponseDto.IsSuccess = true;
            }
            return ResponseDto;
        }

        /// <summary>
        /// Realiza la actualizacion de una imagen en especifico asociada a una poperty
        /// </summary>
        /// <param name="Property"></param>
        /// <returns></returns>
        public async Task<ResponseDto<bool>> UpddatePropertyImageAsync(int idPropertyImage,PropertyImageUpdateRequest Property)
        {
            var Message = string.Empty;
            var IsPropertyValid = RepositoryPropertyImage.GetById(idPropertyImage);
            if (IsPropertyValid == null)
            {
                ResponseDto.Message = Messages.No_Existe_Registro_Property;
                ResponseDto.StatusCode = 204;
            }
            else
            {
                var ResulFile = FileUpload.SenFile(Property.File, FilePath.PathFileProperty, ref Message);
                IsPropertyValid.File = ResulFile;
                await RepositoryPropertyImage.UpdateAsync(IsPropertyValid);
                ResponseDto.Message = Messages.Actualizacion_Exitosa;
                ResponseDto.IsSuccess = true;
                ResponseDto.Data = true;
            }
            return ResponseDto;
        }
    }
}
