using System.ComponentModel.DataAnnotations;

namespace Data.Interface.Models.WikiMc
{
    public enum ImgTypeEnum
    {
        [Display(Name = "")]
        None = 0,
        Proteins = 1,
        Fats = 2,
        Carbs = 3,
    }
}