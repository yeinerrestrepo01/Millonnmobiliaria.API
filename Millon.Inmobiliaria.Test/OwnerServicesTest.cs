using Millon.Inmobiliaria.Application.Services;
using Millon.Inmobiliaria.Domain.Entities;
using Millon.Inmobiliaria.Infrastructure.GenericRepository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Millon.Inmobiliaria.Test
{
    [TestFixture]
    public class OwnerServicesTest
    {
        private MockRepository mockRepository;

        private Mock<IOwnerRepository> mockOwnerRepository;

        [SetUp]
        public void Setup()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockOwnerRepository = this.mockRepository.Create<IOwnerRepository>();
        }

        public OwnerServices CreateService()
        {
            return new OwnerServices(mockOwnerRepository.Object);
        }

        [Test]
        [Author("Jhoel Aicardi")]
        public void GetAll_Owner()
        {
            // Arrange
            var service = this.CreateService();

            List<Owner> dbList = new List<Owner>()
            {
                new Owner()
                {
                    IdOwner = 1,
                    Address ="Calle 14 via al mar",
                    Name ="Jose Luis",
                    Birthday = DateTime.Now.AddYears(-30)
                },
            };

            this.mockOwnerRepository.Setup(s => s.GetAll()).Returns(dbList);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.AreEqual(1, result.Count);
            this.mockRepository.VerifyAll();
        }
    }
}