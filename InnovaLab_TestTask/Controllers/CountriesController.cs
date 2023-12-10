using InnovaLab_TestTask.Models;
using Microsoft.AspNetCore.Mvc;
using InnovaLab_TestTask.Services.Abstract;
using Serilog;

namespace InnovaLab_TestTask.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CountriesController : ControllerBase
	{
		private readonly ICountriesService _countriesService;
		public CountriesController(ICountriesService countriesService)
		{
			_countriesService = countriesService;
		}
		[HttpGet]
		public async Task<IActionResult> GetCountries()
		{
			Log.Information("GetCountries method called");
			var countries = await _countriesService.GetCountriesAsync();

			return Ok(countries);
		}

		[HttpGet]
		public async Task<IActionResult> GetCountry(string name)
		{
			Log.Information("GetCountry method called");
			var country = await _countriesService.GetCountryAsync(name);

			return Ok(country);
		}
	}
}
