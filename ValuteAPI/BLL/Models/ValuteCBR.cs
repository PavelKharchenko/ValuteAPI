using System.Xml.Serialization;

namespace ValuteAPI.BLL.Model
{
   
        /// <summary>
        /// Объект Valute получаемый от ЦБ РФ
        /// </summary>
        [Serializable]
        [XmlRoot(ElementName = "ValCurs", Namespace = "")]
        public class ValuteCBR
        {
            /// <summary>
            /// Числовой код валюты
            /// </summary>
            [XmlIgnore]
            public string NumCode { get; set; }

            /// <summary>
            /// Код валюты
            /// </summary>
            public string CharCode { get; set; }

            /// <summary>
            /// Номинал валюты
            /// </summary>
            [XmlIgnore]
            public string Nominal { get; set; }

            /// <summary>
            /// Наименование валюты
            /// </summary>
            [XmlIgnore]
            public string Name { get; set; }

            /// <summary>
            /// Стоимость 1 номинала валюты
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// Создание объекта Valute
            /// </summary>
            /// <param name="numCode"></param>
            /// <param name="charCode"></param>
            /// <param name="nominal"></param>
            /// <param name="name"></param>
            /// <param name="value"></param>
            public ValuteCBR(string numCode, string charCode, string nominal, string name, string value)
            {
                NumCode = numCode;
                CharCode = charCode;
                Nominal = nominal;
                Name = name;
                Value = value;
            }
        }
}
