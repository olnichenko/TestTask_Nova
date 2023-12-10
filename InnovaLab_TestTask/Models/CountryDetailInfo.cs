using System.Text.Json.Serialization;

namespace InnovaLab_TestTask.Models
{
	public class CountryDetailInfo : Country
	{
		[JsonPropertyName("flags")]
		public Flag? Flag { get; set; }

		[JsonPropertyName("maps")]
		public Maps? Maps { get; set; }
	}
}
