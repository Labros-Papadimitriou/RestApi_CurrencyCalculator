using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CalculatorDtos;
using RestApi_CurrencyCalculator.Controllers.HelperClasses;
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

            int baseCurrId = calculatorCreateDto.BaseCurrCreateIfNotExists(_unitOfwork);
            int targetCurrId = calculatorCreateDto.TargetCurrCreateIfNotExists(_unitOfwork);

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