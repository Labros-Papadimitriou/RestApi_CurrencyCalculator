﻿using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConverterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetExchange(
            string baseCurrency, string targetCurrency, decimal value)
        {
            var calculator = _unitOfWork.Calculators.FindCalculator(baseCurrency, targetCurrency);
            if (calculator is null)
            {
                return BadRequest("Unfortunatelly, we couldnt make this convertion :(");
            }
            var exchangeValue = calculator.GetEquivalence(value);

            return Ok(exchangeValue);
        }
    }
}
