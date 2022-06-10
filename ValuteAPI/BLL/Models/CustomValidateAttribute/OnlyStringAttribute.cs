using System.ComponentModel.DataAnnotations;

namespace ValuteAPI.BLL.Models.CustomValidateAttribute
{
   /// <summary>
   /// Кастомный аттрибут валидации
   /// </summary>
    public class OnlyStringAttribute : ValidationAttribute
    {
        /// <summary>
        /// Реализация метода проверки на валидность поля
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value is string s)
            {
                return s.All(char.IsLetter);
            }
            else
            {
                ErrorMessage = $"{nameof(OnlyStringAttribute)}| Код валюты должен состоять из букв!";
                return false;
            }
        }
    }
}

