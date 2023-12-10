using System.Text.Json.Serialization;

namespace InnovaLab_TestTask.Models
{
	public class Country
	{
		[JsonPropertyName("name")]
		public CountryName Name { get; set; }

		[JsonPropertyName("currencies")]
		public Dictionary<string, Currency>? Currencies { get; set; }

		[JsonPropertyName("capital")]
		public string[] Capital { get; set; }

		[JsonPropertyName("region")]
		public string Region { get; set; }

		[JsonPropertyName("languages")]
		public Dictionary<string, string>? Languages { get; set; }
	}
}
