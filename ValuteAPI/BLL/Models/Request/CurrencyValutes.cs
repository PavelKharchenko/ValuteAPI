using System.ComponentModel.DataAnnotations;
using ValuteAPI.BLL.Models.CustomValidateAttribute;

namespace ValuteAPI.BLL.Models
{
    /// <summary>
    /// Объект для получения валюты
    /// </summary>
    public class RequestValutes
    {
        /// <summary>
        /// Дата за конторую необходимо получить валюты
        /// </summary>
        [Required]
        [DataType(DataType.DateTime)]
        [DateFormat]
        public string? Date { get; set; }
    }
}
