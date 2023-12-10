using InnovaLab_TestTask.Services.Abstract;
using Moq;
using InnovaLab_TestTask.Models;
using InnovaLab_TestTask.Services;
using System.Text.Json;

namespace UnitTests
{
	public class CountriesService_Tests
	{
		private Mock<ICacheService> _mockCacheService;
		private Mock<IHttpClientService> _mockHttpClientService;
		private CountriesService _countriesService;

		[SetUp]
		public void Setup()
		{
			_mockCacheService = new Mock<ICacheService>();
			_mockHttpClientService = new Mock<IHttpClientService>();
			_countriesService = new CountriesService(_mockCacheService.Object, _mockHttpClientService.Object);
		}

		[Test]
		public void GetCountriesAsync_ShouldReturnCountriesFromCache()
		{
			var countries = new Country[]
			{
				new Country
				{
					Capital = new[] { "London" },
					Region = "Europe"
				}
			};
			_mockCacheService.Setup(x => x.Get<IEnumerable<Country>>("countries")).Returns(countries);
			var result = _countriesService.GetCountriesAsync().Result;

			Assert.That(result, Is.EqualTo(countries));
			_mockHttpClientService.Verify(x => x.GetFromJsonAsync<Country[]>(It.IsAny<string>(), It.IsAny<JsonSerializerOptions>()), Times.Never);
			_mockCacheService.Verify(x => x.Get<IEnumerable<Country>>("countries"), Times.Once);
			_mockCacheService.Verify(x => x.Set(It.IsAny<string>(), It.IsAny<IEnumerable<Country>>(), It.IsAny<TimeSpan>()), Times.Never);
		}

		[Test]
		public void GetCountriesAsync_ShouldReturnCountriesFromApi()
		{
			var countries = new Country[]
			{
				new Country
				{
					Capital = new[] { "London" },
					Region = "Europe"
				}
			};
			_mockCacheService.Setup(x => x.Get<IEnumerable<Country>>("countries")).Returns((IEnumerable<Country>)null);
			_mockHttpClientService.Setup(x => x.GetFromJsonAsync<Country[]>(It.IsAny<string>(), It.IsAny<JsonSerializerOptions>()))
				.ReturnsAsync(countries);

			var result = _countriesService.GetCountriesAsync().Result;

			Assert.That(result, Is.EqualTo(countries));
			_mockCacheService.Verify(x => x.Get<IEnumerable<Country>>("countries"), Times.Once);
			_mockHttpClientService.Verify(x => x.GetFromJsonAsync<Country[]>(It.IsAny<string>(), It.IsAny<JsonSerializerOptions>()), Times.Once);
			_mockCacheService.Verify(x => x.Set("countries", result, It.IsAny<TimeSpan>()), Times.Once);
		}

		[Test]
		public void GetCountryAsync_ShouldReturnCountryFromApi()
		{
			var country = new CountryDetailInfo
			{
				Capital = new[] { "London" },
				Region = "Europe"
			};
			_mockHttpClientService.Setup(x => x.GetFromJsonAsync<CountryDetailInfo[]>(It.IsAny<string>(), It.IsAny<JsonSerializerOptions>()))
				.ReturnsAsync(new CountryDetailInfo[] { country });

			var result = _countriesService.GetCountryAsync("United Kingdom").Result;

			Assert.That(result, Is.EqualTo(country));
			_mockHttpClientService.Verify(x => x.GetFromJsonAsync<CountryDetailInfo[]>(It.IsAny<string>(), It.IsAny<JsonSerializerOptions>()), Times.Once);
		}
	}
}
