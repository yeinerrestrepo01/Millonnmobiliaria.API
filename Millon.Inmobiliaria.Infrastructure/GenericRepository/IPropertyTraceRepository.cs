using Millon.Inmobiliaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository
{
    public interface IPropertyTraceRepository
    {
        List<PropertyTrace> GetAll();
        PropertyTrace GetById(int idPropertyTrace);
        Task<int> AddAsync(PropertyTrace PropertyTrace);
    }
}
