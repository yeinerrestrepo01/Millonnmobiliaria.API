using Microsoft.AspNetCore.Http;
using Millon.Inmobiliaria.Application.Services;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Millon.Inmobiliaria.Test
{
    [TestFixture]
    public class PropertyServicesTest
    {
        private MockRepository mockRepository;

        private Mock<IOwnerRepository> mockOwnerRepository;

        private Mock<IPropertyRepository> mockPropertyRepository;

        [SetUp]
        public void Setup()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockOwnerRepository = this.mockRepository.Create<IOwnerRepository>();
            mockPropertyRepository = this.mockRepository.Create<IPropertyRepository>();
        }

        public PropertyServices CreateService()
        {
            return new PropertyServices(mockPropertyRepository.Object,mockOwnerRepository.Object);
        }

        [Test]
        [Author("Yeiner Merino")]
        public void GetAll_Property()
        {
            // Arrange
            var service = this.CreateService();

            var  dbList = new List<Property>()
            {
                new Property()
                {
                    IdOwner = 1,
                    IdProperty = 1,
                    Name ="Prueba carga",
                    Address ="Calle via al mar",
                    CodeInternal = "123-ABC",
                    Price = 1230000,
                    Year = 2019
                },
            };

            this.mockPropertyRepository.Setup(s => s.GetAll()).Returns(dbList);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.AreEqual(1, result.Count);
            this.mockRepository.VerifyAll();
        }
    }
}