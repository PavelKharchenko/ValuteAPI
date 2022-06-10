namespace ValuteAPI.BLL.Middleware
{
    /// <summary>
    /// Реализация расширения для middleware
    /// </summary>
    public static  class CustomExeptionMiddlewareExtensions
    {
        /// <summary>
        /// Подключение кастомного middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExeptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddlewareExeption>();
        }
    }
}
