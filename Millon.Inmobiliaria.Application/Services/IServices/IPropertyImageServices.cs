using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Application.Services.IServices
{
    interface IPropertyImageServices
    {
        List<PropertyImageDto> GetAll();
        ResponseDto<PropertyImageDto> GetByIdProperty(int idProperty);
        Task<ResponseDto<bool>> AddPropertyImageAsync(PropertyImageRequest Property);
    }
}
