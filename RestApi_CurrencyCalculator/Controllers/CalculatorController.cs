using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CalculatorDtos;
using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfwork;

        public CalculatorController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Calculator>> GetAllCalculators()
        {
            var calculators = _unitOfwork.Calculators.GetAllCalculatorsWithCurrencies();
            return Ok(calculators);
        }


        [HttpGet("{id}", Name = "GetCalculatorById")]
        public ActionResult<Calculator> GetCalculatorById(int id)
        {
            var calculatorItem = _unitOfwork.Calculators.GetCalculatorByIdWithCurrencies(id);
            if (calculatorItem != null)
            {
                return Ok(calculatorItem);
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<Calculator> CreateCalculator(CalculatorCreateDto calculatorCreateDto)
        {
            if (calculatorCreateDto is null)
            {
                return BadRequest();
            }
            int baseCurrId = 0;
            int targetCurrId = 0;

            var baseCurrencyItem = _unitOfwork.Currencies
                .Find(x => x.Name == calculatorCreateDto.BaseCurrencyName && x.Code == calculatorCreateDto.BaseCurrencyCode)
                .FirstOrDefault();
            if (baseCurrencyItem is null)
            {
                Currency baseCurrNew = new Currency() { Code = calculatorCreateDto.BaseCurrencyCode, Name = calculatorCreateDto.BaseCurrencyName };
                _unitOfwork.Currencies.Create(baseCurrNew);
                _unitOfwork.Complete();
                baseCurrId = _unitOfwork.Currencies.Find(x => x.Name == calculatorCreateDto.BaseCurrencyName).FirstOrDefault().CurrencyId;
            }
            else
            {
                baseCurrId = baseCurrencyItem.CurrencyId;
            }


            var targetCurrencyItem = _unitOfwork.Currencies
                .Find(x => x.Name == calculatorCreateDto.TargetCurrencyName && x.Code == calculatorCreateDto.TargetCurrencyCode)
                .FirstOrDefault();
            if (targetCurrencyItem is null)
            {
                Currency targetCurrNew = new Currency() { Code = calculatorCreateDto.TargetCurrencyCode, Name = calculatorCreateDto.TargetCurrencyName };
                _unitOfwork.Currencies.Create(targetCurrNew);
                _unitOfwork.Complete();
                targetCurrId = _unitOfwork.Currencies.Find(x => x.Name == calculatorCreateDto.TargetCurrencyName).FirstOrDefault().CurrencyId;
            }
            else
            {
                targetCurrId = targetCurrencyItem.CurrencyId;
            }

            Calculator calculatorModel = new Calculator() { ExchangeRate = calculatorCreateDto.ExchangeRate, BaseCurrencyId = baseCurrId, TargetCurrencyId = targetCurrId };
            _unitOfwork.Calculators.Create(calculatorModel);
            _unitOfwork.Complete();

            return Ok(calculatorModel); 
        }


        //[HttpPatch("{id}")]
        //public ActionResult UpdateCurrency(int id, JsonPatchDocument<CurrencyUpsertDto> patchDoc)
        //{
        //    var currencyModelFromRepo = _unitOfWork.Currencies.Get(id);
        //    if (currencyModelFromRepo is null)
        //    {
        //        return NotFound();
        //    }

        //    var currencyToPatch = _mapper.Map<CurrencyUpsertDto>(currencyModelFromRepo);
        //    patchDoc.ApplyTo(currencyToPatch, ModelState);

        //    if (!TryValidateModel(currencyToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(currencyToPatch, currencyModelFromRepo);
        //    _unitOfWork.Currencies.Modified(currencyModelFromRepo);
        //    _unitOfWork.Complete();

        //    return NoContent();
        //}


        //[HttpDelete("{id}")]
        //public ActionResult DeleteCalculator(int id)
        //{
        //    var currencyModelFromRepo = _unitOfWork.Currencies.Get(id);
        //    if (currencyModelFromRepo is null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Currencies.Delete(currencyModelFromRepo);
        //    _unitOfWork.Complete();

        //    return NoContent();
        //}
    }
}