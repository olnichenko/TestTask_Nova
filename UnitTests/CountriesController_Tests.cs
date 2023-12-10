using InnovaLab_TestTask.Controllers;
using InnovaLab_TestTask.Models;
using InnovaLab_TestTask.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTests
{
	public class CountriesController_Tests
	{
		private CountriesController _controller;
		private Mock<ICountriesService> _mockCountriesService;

		[SetUp]
		public void Setup()
		{
			_mockCountriesService = new Mock<ICountriesService>();
			_controller = new CountriesController(_mockCountriesService.Object);
		}

		[Test]
		public void GetCountries_ShouldReturnOkCountries()
		{
			var country = new Country
			{
				Capital = new[] { "London" },
				Region = "Europe"
			};
			var countries = new List<Country> { country };
			_mockCountriesService.Setup(x => x.GetCountriesAsync()).ReturnsAsync(countries);

			var result = _controller.GetCountries().Result;

			Assert.That(result, Is.InstanceOf<OkObjectResult>());
			var okResult = result as OkObjectResult;
			Assert.That(okResult.Value, Is.EqualTo(countries));
		}

		[Test]
		public void GetCountry_ShouldReturnOkCountry()
		{
			var countryDetail = new CountryDetailInfo
			{
				Capital = new[] { "London" },
				Region = "Europe"
			};
			_mockCountriesService.Setup(x => x.GetCountryAsync(It.IsAny<string>())).ReturnsAsync(countryDetail);

			var result = _controller.GetCountry("england").Result;

			_mockCountriesService.Verify(x => x.GetCountryAsync("england"), Times.Once);
			Assert.That(result, Is.InstanceOf<OkObjectResult>());
			var okResult = result as OkObjectResult;
			Assert.That(okResult.Value, Is.EqualTo(countryDetail));
		}
	}
}