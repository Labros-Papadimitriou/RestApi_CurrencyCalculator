using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.AuthenticationViewModels;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CalculatorDtos;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.Controllers.HelperClasses;
using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Authorize]
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


        [HttpPatch("{id}")]
        public ActionResult UpdateCalculator(int id, JsonPatchDocument<Calculator> patchDoc)
        {
            var calculatorModelFromRepo = _unitOfwork.Calculators.Get(id);
            if (calculatorModelFromRepo is null)
            {
                return NotFound();
            }
            
            patchDoc.ApplyTo(calculatorModelFromRepo, ModelState);

            if (!TryValidateModel(calculatorModelFromRepo))
            {
                return ValidationProblem(ModelState);
            }

            _unitOfwork.Calculators.Modified(calculatorModelFromRepo);
            _unitOfwork.Complete();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCalculator(int id)
        {
            var calculatorModelFromRepo = _unitOfwork.Calculators.Get(id);
            if (calculatorModelFromRepo is null)
            {
                return NotFound();
            }
            _unitOfwork.Calculators.Delete(calculatorModelFromRepo);
            _unitOfwork.Complete();

            return NoContent();
        }
    }
}