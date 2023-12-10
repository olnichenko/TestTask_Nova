using System.Text.Json;
using InnovaLab_TestTask.Models;
using InnovaLab_TestTask.Services.Abstract;

namespace InnovaLab_TestTask.Services
{
    public class CountriesService : ICountriesService
    {
	    private readonly ICacheService _cacheService;
		private readonly IHttpClientService _httpClientService;

		public CountriesService(ICacheService cacheService, IHttpClientService httpClientService)
		{
			_cacheService = cacheService;
			_httpClientService = httpClientService;
		}

		public async Task<IEnumerable<Country>?> GetCountriesAsync()
		{
			var countries = _cacheService.Get<IEnumerable<Country>>("countries");
			if (countries == null)
			{
				countries = await _httpClientService.GetFromJsonAsync<Country[]>(
										"https://restcountries.com/v3.1/all?fields=name,capital,currencies,languages,region",
															new JsonSerializerOptions(JsonSerializerDefaults.Web));

				_cacheService.Set("countries", countries, TimeSpan.FromMinutes(15));
			}

			return countries;
		}

		public async Task<CountryDetailInfo?> GetCountryAsync(string name)
		{
			var url =
				$"https://restcountries.com/v3.1/name/{name}?fields=name,capital,currencies,languages,region,flags,maps";
			var country = await _httpClientService.GetFromJsonAsync<CountryDetailInfo[]>(
				url,
				new JsonSerializerOptions(JsonSerializerDefaults.Web));
			return country?.FirstOrDefault();
		}
	}
}
