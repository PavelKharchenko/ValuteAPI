using System.Net;
using ValuteAPI.BLL.Exeption;

namespace ValuteAPI.BLL.Middleware
{
    /// <summary>
    /// Кастомный middleware для обработки исключений
    /// </summary>
    public class CustomMiddlewareExeption
    {
        private RequestDelegate _next;
        
        /// <summary>
        /// Реализация делегата
        /// </summary>
        /// <param name="next"></param>
        public CustomMiddlewareExeption(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Перехват ошибок в контексте приложения
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
               await  HandlerExeptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Метод для обработки полученного в контексте исключения и отправки 
        /// сообщения об ошибке клиенту
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private Task HandlerExeptionAsync(HttpContext context,Exception ex)
        {
            var message = string.Empty;
            int code = 0;
            
            switch (ex)
            {
                case RequestCBRExeption rCBREx:

                    if(rCBREx.Code == (int)HttpStatusCode.InternalServerError)
                    {
                        message = "Сервис ЦБ РФ не доступен!";
                        code =  rCBREx.Code;
                    }

                    if(rCBREx.Code == (int)HttpStatusCode.BadRequest)
                    {
                        message = "Сформирован не верный запрос";
                        code = rCBREx.Code;
                    }

                    if(rCBREx.Code == (int)HttpStatusCode.RequestTimeout)
                    {
                        message = "Тайм-аут запроса";
                        code = rCBREx.Code;
                    }
                    break;

                case GetValuteExeption gValuteEx:

                    message = "Не удалось получить курс валют!";
                    code = (int)HttpStatusCode.BadRequest;

                    break;

                case Exception:
                    
                    message = "Ошибка в работе сервера!";
                    code = (int)HttpStatusCode.BadRequest;

                    break;
            }

            context.Response.StatusCode = code;
            context.Response.ContentType = "application/json";
            

            return context.Response.WriteAsJsonAsync(new ResponseError() { Message = message});
        }
    }

    
}
