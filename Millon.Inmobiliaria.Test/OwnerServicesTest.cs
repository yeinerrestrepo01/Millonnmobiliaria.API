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
        [Author("Yeiner Merino")]
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

        [Test]
        [Author("Yeiner Merino")]
        public void GetBy_Owner_OK()
        {
            // Arrange
            var service = this.CreateService();

            var dbOwner =
                 new Owner()
                 {
                     IdOwner = 4,
                     Address = "Calle 14 via al mar",
                     Name = "Jose Luis",
                     Birthday = DateTime.Now.AddYears(-30)
                 };

            this.mockOwnerRepository.Setup(s => s.GetById(1)).Returns(dbOwner);

            var dbOwnerValid =
                 new Owner()
                 {
                     IdOwner = 4,
                     Address = "Calle 14 via al mar",
                     Name = "Jose Luis",
                     Birthday = DateTime.Now.AddYears(-30)
                 };
            // Act
            var result = service.GetById(1);

            // Assert
            Assert.AreEqual(dbOwnerValid.IdOwner, result.Data.IdOwner);
            this.mockRepository.VerifyAll();
        }


        [Test]
        [Author("Yeiner Merino")]
        public async Task Add_Owner_OK()
        {

            // Arrange
            var service = this.CreateService();
            var FileMock = new Mock<IFormFile>();
            // Arrange

            var Content = "q1w2ert56tregfidvmiunv9fviufd";
            var FileName = "Owner.jpg";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(Content);
            writer.Flush();
            ms.Position = 0;
            FileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            FileMock.Setup(_ => _.FileName).Returns(FileName);
            FileMock.Setup(_ => _.Length).Returns(ms.Length);
            var file = FileMock.Object;

            var dbOwner =
                 new OwnerResquest()
                 {
                     Address = "Calle 14 via al mar",
                     Name = "Jose Luis",
                     Birthday = DateTime.Now.AddYears(-30),
                     Photo = file
                 };

            this.mockOwnerRepository.Setup(s => s.AddAsync(It.IsAny<Owner>())).ReturnsAsync(1);

            var AddOwner = await service.AddOwnerAsync(dbOwner);

            Assert.AreEqual(true, AddOwner.IsSuccess);
            this.mockRepository.VerifyAll();
        }
    }
}