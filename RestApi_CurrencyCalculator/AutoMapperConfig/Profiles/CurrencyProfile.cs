using AutoMapper;
using RestApi_CurrencyCalculator.AutoMapper.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.AutoMapperConfig.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            //Sourse --> Target
            CreateMap<Currency, CurrencyReadDto>();
            CreateMap<CurrencyCreateDto, Currency>();
        }
    }
}
