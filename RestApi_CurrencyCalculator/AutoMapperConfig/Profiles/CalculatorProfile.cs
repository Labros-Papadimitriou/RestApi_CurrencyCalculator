using AutoMapper;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CalculatorDtos;
using RestApi_CurrencyCalculator.Core.Models;

namespace RestApi_CurrencyCalculator.AutoMapperConfig.Profiles
{
    public class CalculatorProfile : Profile
    {
        public CalculatorProfile()
        {
            //Sourse --> Target
            CreateMap<Calculator, CalculatorReadDto>();
            CreateMap<CalculatorCreateDto, Calculator>();
        }
    }
}
