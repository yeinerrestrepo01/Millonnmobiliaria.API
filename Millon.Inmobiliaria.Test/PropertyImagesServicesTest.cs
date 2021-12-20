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
    public class PropertyImagesServicesTest
    {
        private MockRepository mockRepository;

        private Mock<IPropertyImageRepository> mockPropertyImageRepos;
        private Mock<IPropertyRepository> mockOwnerProperty;


        [SetUp]
        public void Setup()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
            mockPropertyImageRepos = this.mockRepository.Create<IPropertyImageRepository>();
            mockOwnerProperty = this.mockRepository.Create<IPropertyRepository>();
        }

        public PropertyImageServices CreateService()
        {
            return new PropertyImageServices(mockOwnerProperty.Object,mockPropertyImageRepos.Object);
        }

        [Test]
        [Author("Yeiner Merino")]
        public void GetAll_Owner()
        {
            // Arrange
            var service = this.CreateService();

            var dbList = new List<PropertyImage>()
            {
                new PropertyImage()
                {
                    IdPropertyImage = 1,
                    IdProperty = 1,
                    File = "https://caselink-files-dev.s3.amazonaws.com/descarga.jpg",
                    Enabled = true
                },
            };

            this.mockPropertyImageRepos.Setup(s => s.GetAll()).Returns(dbList);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.AreEqual(1, result.Count);
            this.mockRepository.VerifyAll();
        }

        [Test]
        [Author("Yeiner Merino")]
        public void GetBy_ProperyImage_OK()
        {
            // Arrange
            var service = this.CreateService();

            var dbList =
                new PropertyImage()
                {
                    IdPropertyImage = 1,
                    IdProperty = 1,
                    File = "https://caselink-files-dev.s3.amazonaws.com/descarga.jpg",
                    Enabled = true
                };

            this.mockPropertyImageRepos.Setup(s => s.GetById(1)).Returns(dbList);

            var DbPropertyImageValid = new PropertyImage()
            {
                IdPropertyImage = 1,
                IdProperty = 1,
                File = "https://caselink-files-dev.s3.amazonaws.com/descarga.jpg",
                Enabled = true
            }; 
            // Act
            var result = service.GetById(1);

            // Assert
            Assert.AreEqual(DbPropertyImageValid.IdPropertyImage, result.Data.IdPropertyImage);
            this.mockRepository.VerifyAll();
        }

        [Test]
        [Author("Yeiner Merino")]
        public async Task Add_PropertyImage_OK()
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

            var dbPropertyImage =
                 new PropertyImageRequest()
                 {
                     File = file,
                     IdProperty = 4
                 };

            var dbmockOwnerProperty =
                new Property()
                {
                    IdOwner = 4,
                    Address = "Calle 14 via al mar",
                    Name = "New Miami",
                    CodeInternal = "123-44",
                    IdProperty = 1,
                    Price =1200000,
                    Year = 2020
                };

            this.mockOwnerProperty.Setup(s => s.GetById(4)).Returns(dbmockOwnerProperty);

            this.mockPropertyImageRepos.Setup(s => s.AddAsync(It.IsAny<PropertyImage>())).ReturnsAsync(1);

            var AddOwner = await service.AddPropertyImageAsync(dbPropertyImage);

            Assert.AreEqual(true, AddOwner.IsSuccess);
            this.mockRepository.VerifyAll();
        }

    }
}