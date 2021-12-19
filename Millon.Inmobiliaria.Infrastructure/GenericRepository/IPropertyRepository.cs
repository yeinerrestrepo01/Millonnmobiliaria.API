using Millon.Inmobiliaria.Domain.DTO;
using Millon.Inmobiliaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository
{
    public interface IPropertyRepository
    {
        List<Property> GetAll();
        Property GetById(int idProperty);
        PropertyDetailDto GetByPropertyDetail(int idProperty);
        Task<int> AddAsync(Property Property);
    }
}
