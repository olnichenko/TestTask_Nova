using System.Text.Json;

namespace InnovaLab_TestTask.Services.Abstract;

public interface IHttpClientService
{
	Task<T?> GetFromJsonAsync<T>(string url, JsonSerializerOptions? options = null);
}