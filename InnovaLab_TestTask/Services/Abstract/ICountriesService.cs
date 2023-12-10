using InnovaLab_TestTask.Models;

namespace InnovaLab_TestTask.Services.Abstract;

public interface ICountriesService
{
    Task<IEnumerable<Country>?> GetCountriesAsync();
    Task<CountryDetailInfo?> GetCountryAsync(string name);
}