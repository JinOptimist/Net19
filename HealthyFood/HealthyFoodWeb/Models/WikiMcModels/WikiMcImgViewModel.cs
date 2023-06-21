using Data.Interface.Models.WikiMc;

namespace HealthyFoodWeb.Models.WikiMcModels
{
    public class WikiMcImgViewModel
    {
        public List<WikiMcViewModel> AllImgByYear { get; set; }
        public List<WikiMcViewModel> AllImgByType { get; set; } 
        public int Age { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public int Percent { get; set; }
		public SexEnum Sex{ get; set; }
        public GoalEnum Goal { get; set; }
        public ActivityRatioEnum ActivityRatio { get; set;}
        public int HarrisBenedictAns { get; set; }
        public int MifflinStJeorAns { get; set; }  
        public int WhoAns { get; set; }
        public int AverageAns { get; set; }
        public int GramsOfProteins { get; set; }
        public int GramsOfFats { get; set; }
        public int GramsOfCarbs { get; set; }
		public int PercentOfProteins { get; set; }
		public int PercentOfFats { get; set; }
		public int PercentOfCarbs { get; set; }
	}
}
