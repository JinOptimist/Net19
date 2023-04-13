
namespace Data.Interface.Models
{
    public class QuizQuestion : BaseModel
    {
        public string Question { get; set; }
        public string VariantOne { get; set; }
        public string VariantTwo { get; set; }
        public string VariatThree { get; set; }
        public string RightAnswer { get; set; }
    }
}
