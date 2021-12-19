using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Application.Services.IServices
{
    public interface IPropertyServices
    {
        
        ResponseDto<PropertyDto> GetById(int idProperty);
        Task<ResponseDto<bool>> AddPropertyAsync(PropertyRequest Property);
        Task<ResponseDto<bool>> UpdatePrice(int idProPerty,PropertyUpdatePriceRequest Property);
        ResponseDto<PropertyDetailDto> GetByPropertyDetail(int idProperty);
        List<PropertyDto> GetAll();
    }
}
