using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.AutoMapper.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CurrencyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CurrencyReadDto>> GetAllCurrencies()
        {
            var currencies = _unitOfWork.Currencies.GetAll();
            return Ok(_mapper.Map<IEnumerable<CurrencyReadDto>>(currencies));
        }

        [HttpGet("{id}", Name="GetCurrencyById")]
        public ActionResult<CurrencyReadDto> GetCurrencyById(int id)
        {
            var currencyItem = _unitOfWork.Currencies.Get(id);
            if (currencyItem != null)
            {
                return Ok(_mapper.Map<CurrencyReadDto>(currencyItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CurrencyReadDto> CreateCurrency(CurrencyCreateDto currencyCreateDto)
        {
            if (currencyCreateDto is null)
            {
                return BadRequest();
            }
            var currencyModel = _mapper.Map<Currency>(currencyCreateDto);
            _unitOfWork.Currencies.Create(currencyModel);
            _unitOfWork.Complete();

            var currencyReadDto = _mapper.Map<CurrencyReadDto>(currencyModel);

            return CreatedAtRoute(nameof(GetCurrencyById), new { Id = currencyReadDto.CurrencyId }, currencyReadDto);
        }
    }
}
