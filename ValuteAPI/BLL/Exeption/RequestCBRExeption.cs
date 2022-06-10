namespace ValuteAPI.BLL.Exeption
{
    public class RequestCBRExeption : Exception
    {
        public int Code { get; }

        public RequestCBRExeption(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}
