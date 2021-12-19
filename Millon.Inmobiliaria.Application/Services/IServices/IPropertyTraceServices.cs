using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Application.Services.IServices
{
    public interface IPropertyTraceServices
    {
        List<PropertyTraceDto> GetAll();
        ResponseDto<PropertyTraceDto> GetById(int idProperty);
        Task<ResponseDto<bool>> AddPropertyAsync(PropertyTraceRequest Property);
    }
}
