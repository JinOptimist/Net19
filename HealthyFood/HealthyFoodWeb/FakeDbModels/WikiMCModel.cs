using Data.Interface.Models;

namespace HealthyFoodWeb.FakeDbModels
{
    public class WikiMCModel : IWikiMCModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
    }
}
