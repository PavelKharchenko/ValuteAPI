namespace ValuteAPI.BLL.Models
{
    /// <summary>
    /// Объект для отправки валюты клтенту
    /// </summary>
    public class Valute
    {
        /// <summary>
        /// Код валюты
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// Стоимость 1 - го номинала валюты в рублях
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Стоимость валюты на запращиваемую дату 
        /// </summary>
        public string? Date { get; set; }

    }
}
