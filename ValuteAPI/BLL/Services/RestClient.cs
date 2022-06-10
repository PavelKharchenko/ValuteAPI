using ValuteAPI.BLL.Infrastructure;

namespace ValuteAPI.BLL.Services
{
    /// <summary>
    /// Реализация запроса к ЦБ РФ
    /// </summary>
    public class RestClient : IRestClient
    {
        private static readonly string _currentDate = DateTime.Now.Date.ToString("dd/MM/yyyy");
        private static readonly string _url = @"http://www.cbr.ru/scripts/XML_daily.asp?date_req=";
      
      /// <summary>
      /// Позволяет создавать и кастомить httpClient
      /// </summary>
      /// <returns>Созданный http client </returns>
        private static HttpClient GetClient()
        {
            var client = new HttpClient();

            return client;
        }

        /// <summary>
        /// Запрос к ЦБ РФ для получения курса валют по дате
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static HttpResponseMessage RequestToCBR(string date)
        {
            if (String.IsNullOrEmpty(date))
            {
                date = _currentDate;
            }

          var client = GetClient();

           var response = client.GetAsync(_url + date).Result;

            return response;
        }


    }
}
