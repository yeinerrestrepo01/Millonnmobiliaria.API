using Millon.Inmobiliaria.Application.Services.IServices;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Millon.Inmobiliaria.Application.Services
{
    public class OwnerServices : IOwnerServices
    {
        private readonly IOwnerRepository RepositoryOwner;
        public OwnerServices(IOwnerRepository repositoryOwner)
        {
            RepositoryOwner = repositoryOwner;
        }
        public List<OwnerDto> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
