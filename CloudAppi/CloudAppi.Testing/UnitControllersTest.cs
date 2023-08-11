using CloudAppi.Controllers;
using CloudAppi.Models;
using CloudAppi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CloudAppi.Testing
{
    public class Tests
    {
        private CountriesController _controller;
        private Mock<ICountriesService> _serviceMock;
        private Mock<ILogger<CountriesController>> _loggerMock;
        private Country CountryForTest;
        private List<Country> ListOfCountriesForTest = new List<Country>();


        //Para crear test para el resto de endpoints bastaria con seguir el mismo patron de comprobar todos los resultados posibles
        //La falta de tiempo me impide realizarlos y ya que serian muy parecidos a los que ya hay,se pueden sobreentender para evaluarlos
        //Ademas esto se puede complementar con la colección de test de integracion de Postman que hay en la carpeta "Test" en GIT
        //Aclaración: La colección de test de Postman esta hecha para ser ejecutada secuencialmente con la función de Postman "Run Collection"

        [SetUp]
        public void SetUp()
        {
            _serviceMock = new Mock<ICountriesService>();
            _loggerMock = new Mock<ILogger<CountriesController>>();
            _controller = new CountriesController(_loggerMock.Object, _serviceMock.Object);

            CountryForTest = new Country()
            {
                Name = "Name for test",
                Capital = "Capital for test",
                Alpha2Code = "cca2",
                Alpha3Code = "cca3",
                NativeName = "Native name for test",
                Region = "Region for test"
            };

            ListOfCountriesForTest.Add(CountryForTest);
        }

        [Test]
        public void Get_AllCountries_ReturnsOkResult()
        {
            // Arrange
            var countries = ListOfCountriesForTest;
            _serviceMock.Setup(s => s.GetAllCountries()).Returns(countries);

            // Act
            var Result = _controller.GetAllCountries().Value;

            // Assert
            Assert.AreEqual(Result.Count(), 1);
        }

        [Test]
        public void Get_AllCountries_NotFoundResult()
        {
            // Arrange
            var countries = new List<Country>();
            _serviceMock.Setup(s => s.GetAllCountries()).Returns(countries);

            // Act
            var actionResult = _controller.GetAllCountries().Result;

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }
        [Test]
        public void Get_Country_ReturnsOkResult()
        {
            // Arrange
            _serviceMock.Setup(s => s.GetCountryByName(It.IsAny<string>())).Returns(CountryForTest);

            // Act
            var Result = _controller.GetAllCountries().Value;

            // Assert
            Assert.IsInstanceOf<Country>(Result);
        }

        [Test]
        public void Get_Country_ReturnsNotFoundResult()
        {
            // Arrange
            _serviceMock.Setup(s => s.GetCountryByName(It.IsAny<string>())).Returns((Country)null);

            // Act
            var actionResult = _controller.GetAllCountries().Result;

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(actionResult);
        }
    }
}