using Millon.Inmobiliaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository
{
    public interface IPropertyImageRepository
    {
        List<PropertyImage> GetAll();
        PropertyImage GetById(int idPropertyImage);
        Task<int> AddAsync(PropertyImage PropertyImage);
    }
}
