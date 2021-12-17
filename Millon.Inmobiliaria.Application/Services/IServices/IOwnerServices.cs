using Millon.Inmobiliaria.Domain.Entities;
using System.Collections.Generic;

namespace Millon.Inmobiliaria.Application.Services.IServices
{
    public interface IOwnerServices
    {
        List<OwnerDto> GetAll();
    }
}
