using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Interface.Models
{
    public enum ImgTypeEnum
    {
        [Display(Name = "")]
        Null = 0,
        Proteins = 1,
        Fats = 2,
        Carbs = 3,
    }
}