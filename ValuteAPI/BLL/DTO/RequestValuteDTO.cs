namespace ValuteAPI.BLL.DTO
{
    /// <summary>
    /// DTO объект RequestValute
    /// </summary>
    public class RequestValuteDTO
    {
        /// <summary>
        /// Код валюты
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Дата за конторую необходимо получить валюту
        /// </summary>
        public string? Date { get; set; }
    }
}
