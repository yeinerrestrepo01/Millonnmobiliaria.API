using Millon.Inmobiliaria.Application.Services;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Domain.Request;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

        [Test]
        [Author("Yeiner Merino")]
        public void GetBy_OK()
        {
            // Arrange
            var service = this.CreateService();

            var Property = new Property()
            {
                IdOwner = 1,
                IdProperty = 1,
                Name = "Prueba carga",
                Address = "Calle via al mar",
                CodeInternal = "123-ABC",
                Price = 1230000,
                Year = 2019
            };

            this.mockPropertyRepository.Setup(s => s.GetById(1)).Returns(Property);

            var PropertyValid = new Property()
            {
                IdOwner = 1,
                IdProperty = 1,
                Name = "Prueba carga",
                Address = "Calle via al mar",
                CodeInternal = "123-ABC",
                Price = 1230000,
                Year = 2019
            };
            // Act
            var result = service.GetById(1);

            // Assert
            Assert.AreEqual(PropertyValid.IdProperty, result.Data.IdProperty);
            this.mockRepository.VerifyAll();
        }

        [Test]
        [Author("Yeiner Merino")]
        public async Task AddProperty_OK() 
        {
            // Arrange
            var service = this.CreateService();

            var Property = new Property()
            {
                IdOwner = 4,
                Name = "Prueba carga",
                Address = "Calle via al mar",
                CodeInternal = "123-ABC",
                Price = 1230000,
                Year = 2019
            };

            var dbOwner =
                new Owner()
                {
                    IdOwner = 4,
                    Address = "Calle 14 via al mar",
                    Name = "Jose Luis",
                    Birthday = DateTime.Now.AddYears(-30)
                };

            this.mockOwnerRepository.Setup(s => s.GetById(4)).Returns(dbOwner);

            this.mockPropertyRepository.Setup(s => s.AddAsync(It.IsAny<Property>())).ReturnsAsync(1);


            var PropertyRequest = new PropertyRequest()
            {
                IdOwner = 4,
                Name = "Prueba carga",
                Address = "Calle via al mar",
                CodeInternal = "123-ABC",
                Price = 1230000,
                Year = 2019
            };
            var AddOwner = await service.AddPropertyAsync(PropertyRequest);

            Assert.AreEqual(true, AddOwner.IsSuccess);
            this.mockRepository.VerifyAll();
        }
    }
}