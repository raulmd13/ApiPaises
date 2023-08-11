using AutoMapper;
using CloudAppi.Controllers;
using CloudAppi.Models;
using CloudAppi.Models.DTO;
using CloudAppi.Repository;
using CloudAppi.Service;
using CloudAppi.Service.Helpers;
using Elfie.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq.Expressions;

namespace CloudAppi.Testing
{
    public class UnitRestServiceTest
    {
        private Mock<ICountriesRepository> MockcountriesRepository;
        private IMapper Mapper;
        private Mock<RestCountriesService> Service;
        private CountryApiDTO CountryForTest;

        [SetUp]
        public void SetUp()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile( new MappingProfiles()));
            Mapper = configuration.CreateMapper();

            MockcountriesRepository = new Mock<ICountriesRepository>();
            Service = new Mock<RestCountriesService>(new ExternalServices(), MockcountriesRepository.Object, Mapper);
            Service.CallBase = true;

            CountryForTest = new CountryApiDTO()
            {
                name = new NameDTO() { common = "Name for test" },
                cca2 = "cca2",
                cca3 = "cca3",
                region = "Region for test"
            };
        }

        [Test]
        public void Save_RestCountry_Correctly()
        {
            // Arrange
            Service.Setup(x => x.GetCountryByName(It.IsAny<string>())).Returns(CountryForTest);
            //MockcountriesRepository.Setup(s => s.SaveCountry(It.IsAny<Country>()));

            // Act
            var country = Service.Object.SaveRestCountry("Name for test");

            // Assert
            Assert.IsInstanceOf<Country>(country);
            Assert.AreEqual(country.Name, "Name for test");
        }
    }
}
