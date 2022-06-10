using System.ComponentModel.DataAnnotations;
using ValuteAPI.BLL.Models.CustomValidateAttribute;

namespace ValuteAPI.BLL.Model
{
    
    /// <summary>
    /// Модель запроса валюты клиентом
    /// </summary>
    public class RequestValute
    {
        /// <summary>
        /// Код валюты
        /// </summary>
        [Required]
        [OnlyString]
        [StringLength(3)]
        public string? Code { get; set; }

        /// <summary>
        /// Дата за конторую необходимо получить валюту
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        [DateFormat]
        public string? Date { get; set; }
    }
}


