using AutoMapper;
using ValuteAPI.BLL.DTO;
using ValuteAPI.BLL.Model;
using ValuteAPI.BLL.Models;

namespace ValuteAPI.BLL.ValuteProfile
{
    /// <summary>
    /// Создание маппинга оббектов валюты
    /// </summary>
    public class ValuteProfile : Profile
    {
        /// <summary>
        /// Создание маппинга
        /// </summary>
        public ValuteProfile()
        {
            CreateMap<RequestValute,RequestValuteDTO>();
            CreateMap<CurrencyValutes, RequestValutesDTO>();
        }
    }
}
