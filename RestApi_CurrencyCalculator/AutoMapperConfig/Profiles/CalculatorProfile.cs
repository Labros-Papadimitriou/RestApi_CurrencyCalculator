using AutoMapper;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CalculatorDtos;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
