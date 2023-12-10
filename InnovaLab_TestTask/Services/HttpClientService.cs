using System.Text.Json;
using InnovaLab_TestTask.Services.Abstract;

namespace InnovaLab_TestTask.Services
{
	public class HttpClientService : IHttpClientService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public HttpClientService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		private HttpClient GetClient()
		{
			return _httpClientFactory.CreateClient();
		}

		public async Task<T?> GetFromJsonAsync<T>(string url, JsonSerializerOptions? options = null)
		{
			using var client = GetClient();
			return await client.GetFromJsonAsync<T>(url, options);
		}
	}
}
