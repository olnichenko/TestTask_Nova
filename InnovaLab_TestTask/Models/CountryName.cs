using System.Text.Json.Serialization;

namespace InnovaLab_TestTask.Models
{
	public class CountryName
	{
		[JsonPropertyName("official")]
		public string Official { get; set; }

		[JsonPropertyName("common")]
		public string Common { get; set; }
	}
}
