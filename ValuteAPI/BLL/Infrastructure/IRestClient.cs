using ValuteAPI.BLL.Models;

namespace ValuteAPI.BLL.Infrastructure
{
    /// <summary>
    /// Контракты по реализации запросов к ЦБ РФ
    /// </summary>
    public interface IRestClient
    {
        /// <summary>
        /// Запрос к ЦБ РФ
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public extern static HttpResponseMessage RequestToCBR(string date);
    }
}
