using Data.Interface.Models;

namespace HealthyFoodWeb.FakeDbModels
{
    public class Wiki_MC_Img_Model : IWiki_MC_Img_Model
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
    }
}
