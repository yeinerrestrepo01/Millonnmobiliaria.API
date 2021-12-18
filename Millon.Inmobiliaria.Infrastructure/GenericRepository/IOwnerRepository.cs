using Millon.Inmobiliaria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Infrastructure.GenericRepository
{
    public interface IOwnerRepository
    {
        List<Owner> GetAll();
        Owner GetById(int idOwner);
        Task<int> AddAsync(Owner Owner);
    }
}
