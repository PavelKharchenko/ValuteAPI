using ValuteAPI.BLL.Model;

namespace ValuteAPI.BLL.Models.Response
{
    /// <summary>
    /// Объект для отправки валют 
    /// </summary>
    public class Valutes
    {
        /// <summary>
        /// Дата запрашиваемой стомости валют
        /// </summary>
        public string? Date { get; set; }

        /// <summary>
        /// Валюты
        /// </summary>
       public ValuteCBR[]? ValutesCBR { get; set; }

    }
}
