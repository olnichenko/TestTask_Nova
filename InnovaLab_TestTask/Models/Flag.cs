﻿using System.Text.Json.Serialization;

namespace InnovaLab_TestTask.Models
{
	public class Flag
	{
		[JsonPropertyName("png")]
		public string Png { get; set; }

		[JsonPropertyName("svg")]
		public string Svg { get; set; }

		[JsonPropertyName("alt")]
		public string Alt { get; set; }
	}
}
