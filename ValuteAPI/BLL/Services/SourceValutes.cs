using System.Text;
using System.Xml.Serialization;
using ValuteAPI.BLL.Exeption;
using ValuteAPI.BLL.Infrastructure;
using ValuteAPI.BLL.Model;
using ValuteAPI.BLL.Models;
using ValuteAPI.BLL.Models.Response;

namespace ValuteAPI.BLL.Services
{
    /// <summary>
    /// Получение курса заданной валюты  или всех вылют по дате
    /// </summary>
    public class SourceValutes : ISourceValutes
    {

        private static RestClient RestClient = new RestClient();

        /// <summary>
        /// Десерелизация объекта ValCurs с ЦБ РФ
        /// </summary>
        /// <returns>Валюты </returns>
        private static ValuteCBR[] getData(string date)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "ValCurs";

            xRoot.IsNullable = true;

            XmlSerializer formatter = new XmlSerializer(typeof(ValuteCBR[]), xRoot);


               var resp = RestClient.RequestToCBR(date);

                var valutesCBR = (ValuteCBR[])formatter.Deserialize(resp.Content.ReadAsStreamAsync().Result);

                if (valutesCBR == null)
                {
                    throw new GetValuteExeption("Не удалось получить валюту!");
                }

                resp.Content.Dispose();

            return valutesCBR;

        }

        /// <summary>
        /// Получение стоимости 1 - го номиналоа валюты
        /// </summary>
        /// <param name="code">Код валюты</param>
        /// <param name="date">Дата за которую необходимо получить стоимость валюты</param>
        /// <returns>Стоимость валюты</returns>
        public Valute getValute(string code, string date)
        {
            if(code == null)
            {
                throw new ArgumentNullException("Необходимо передать код валюты");
            }

            if(date == null)
            {
                throw new ArgumentNullException("Не обходимо передать дату!");
            }

            var valutesCBR = getData(date);

            foreach (var valuteCBR in valutesCBR)
            {
                if(valuteCBR.CharCode == code)
                {
                    return new Valute()
                    {
                        Code = valuteCBR.CharCode,
                        Value = valuteCBR.Value,
                        Date = date
                    };
                }
            }

            return new Valute();
        }

        /// <summary>
        /// Получения стоимость валют от ЦБ РФ
        /// </summary>
        /// <param name="date">Дата за которую необходимо получить стоимость валют</param>
        /// <returns>Стоимость валют</returns>
        public Valutes getValutes(string date)
        {
            if (date == null)
            {
                throw new ArgumentNullException("Не обходимо передать дату!");
            }

            var valutesCBR = getData(date);

            return new Valutes() { Date = date,ValutesCBR = valutesCBR};
        }
    }
}
