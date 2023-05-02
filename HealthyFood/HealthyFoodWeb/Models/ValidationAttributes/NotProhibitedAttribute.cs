using System.ComponentModel.DataAnnotations;

namespace HealthyFoodWeb.Models.ValidationAttributes
{
    public class NotProhibitedAttribute : ValidationAttribute
    {
         public override string FormatErrorMessage(string name)
        {
            return string.IsNullOrEmpty(ErrorMessage)
                ? $"Вам комментарий содержит запрещенные слова {name}"
                : ErrorMessage;
        }

        //public override bool IsValid(object? value)
        //{
        //  switch (value)
        //    {
        //        case 
        //    }
        //}
    }
}
