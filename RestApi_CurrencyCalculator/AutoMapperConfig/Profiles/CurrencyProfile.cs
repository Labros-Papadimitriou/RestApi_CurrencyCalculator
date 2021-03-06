using AutoMapper;
using RestApi_CurrencyCalculator.AutoMapper.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.Core.Models;

namespace RestApi_CurrencyCalculator.AutoMapperConfig.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            //Sourse --> Target
            CreateMap<Currency, CurrencyReadDto>();
            CreateMap<CurrencyUpsertDto, Currency>();
            CreateMap<Currency, CurrencyUpsertDto>();
        }
    }
}
