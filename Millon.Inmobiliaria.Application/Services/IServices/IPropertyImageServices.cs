using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Application.Services.IServices
{
    public interface IPropertyImageServices
    {
        List<PropertyImageDto> GetAll();
        ResponseDto<PropertyImageDto> GetById(int idPropertyImage);
        Task<ResponseDto<bool>> AddPropertyImageAsync(PropertyImageRequest Property);
        Task<ResponseDto<bool>> UpddatePropertyImageAsync(int idPropertyImage, PropertyImageUpdateRequest Property);
    }
}
