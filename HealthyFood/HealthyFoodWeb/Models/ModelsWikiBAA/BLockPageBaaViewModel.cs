using Data.Interface.Models;

namespace HealthyFoodWeb.Models.ModelsWikiBAA
{
    public class BLockPageBaaViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public string Author { get; set; }

        public string CommentText { get; set; }
        
        public PageBaaViewModel pageBaaViewModel { get; set; }
    }
}

