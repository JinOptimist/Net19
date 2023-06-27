using System.ComponentModel.DataAnnotations;

namespace Data.Interface.Models.WikiMc
{
	public enum ActivityRatioEnum
	{
		[Display(Name = "1,20 – минимальная активность")]
		Minimum = 1,
		[Display(Name = "1,375 – небольшая активность")]
		Low = 2,
		[Display(Name = "1,46 – средняя активность ")]
		Average = 3,
		[Display(Name = "1,55 – активность выше среднего")]
		AboveAverage = 4,
		[Display(Name = "1,64 – повышенная активность")]
		Increased = 5,
		[Display(Name = "1,72 – высокая активность")]
		High = 6,
		[Display(Name = "1,90 – очень высокая активность")]
		VeryHigh = 7,
	}
}
