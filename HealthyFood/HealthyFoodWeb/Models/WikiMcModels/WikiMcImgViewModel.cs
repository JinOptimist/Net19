using Data.Interface.Models.WikiMc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWeb.Models.WikiMcModels
{
    public class WikiMcImgViewModel
    {
        [Required(ErrorMessage = "Введите количество полных лет.")]
		[Range(1,100,ErrorMessage = "Недопустимый возраст.")]
		public int? Age { get; set; }

		[Required(ErrorMessage = "Введите вес в кг.")]
		[Range(1.0f, float.MaxValue, ErrorMessage = "Недопустимый вес.")]
		public float? Weight { get; set; }

		[Required(ErrorMessage = "Введите рост в см.")]
		[Range(3.0f,250.0f, ErrorMessage = "Укажите рост в см, чтобы воспользоваться калькулятором КБЖУ.")]
		public float? Height { get; set; }

		[Required(ErrorMessage = "Введите желаемый процент дефицита/профицита.")]
		[Range(0, 30, ErrorMessage = "Для осуществления целей с соблюдением здорового подхода, процент дефицита/профицита не должен превышать 30%.")]
		public int? Percent { get; set; }

		[Required(ErrorMessage = "Введите желаемый процент белка в рационе.")]
		[Range(0, 100, ErrorMessage = "а")]
		public int? PercentOfProteins { get; set; } = 30;

		[Required(ErrorMessage = "Введите желаемый процент жира в рационе.")]
		[Range(0, 100, ErrorMessage = "п")]
		public int? PercentOfFats { get; set; } = 30;

		[Required(ErrorMessage = "Введите желаемый процент углеводов в рационе.")]
		[Range(0, 100, ErrorMessage = "г")]
		public int? PercentOfCarbs { get; set; } = 40;

		public SexEnum Sex { get; set; } = SexEnum.Male;
		public GoalEnum Goal { get; set; } = GoalEnum.Weight_loss;
		public ActivityRatioEnum ActivityRatio { get; set; }
		public int HarrisBenedictAns { get; set; }
		public int MifflinStJeorAns { get; set; }
		public int WhoAns { get; set; }
		public int AverageAns { get; set; }
		public int GramsOfProteins { get; set; }
		public int GramsOfFats { get; set; }
		public int GramsOfCarbs { get; set; }
		[ValidateNever]
		public List<WikiMcViewModel> ImgByYear { get; set; }
		[ValidateNever]
		public List<WikiMcViewModel> ImgByType { get; set; }
	}
}
