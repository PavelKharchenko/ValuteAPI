using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ValuteAPI.BLL.Models.CustomValidateAttribute
{
    /// <summary>
    /// Аттрибут проверки даты на правельный формат
    /// </summary>
    public class DateFormatAttribute : ValidationAttribute
    {
        /// <summary>
        /// Реализация метода проверки даты на соответствие формату
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value is string)
            {
               return DateTime.TryParseExact((string?)value, "dd/MM/yyyy", null,
                DateTimeStyles.AllowWhiteSpaces, out _);
            }
            else
            {
                ErrorMessage = $"{nameof(DateFormatAttribute)}| Дата должна быть в формате = dd/MM/yyyy";
                return false;
            }
        }
    }
}
