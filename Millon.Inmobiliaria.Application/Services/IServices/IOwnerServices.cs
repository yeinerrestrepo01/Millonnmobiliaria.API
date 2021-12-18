using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Application.Services.IServices
{
    public interface IOwnerServices
    {
        List<OwnerDto> GetAll();
        ResponseDto<OwnerDto> GetById(int idOwner);
        Task<ResponseDto<bool>> AddOwnerAsync(OwnerResquest Owner);
    }
}
