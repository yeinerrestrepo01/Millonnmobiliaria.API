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
        public void GetBy_Owner_OK()
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

    }
}