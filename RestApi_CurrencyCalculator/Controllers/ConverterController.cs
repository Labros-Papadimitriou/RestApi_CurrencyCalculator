using Microsoft.AspNetCore.Mvc;
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
    public class ConverterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConverterController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetExchange(
            string baseCurrencyCode, string targetCurrencyCode, decimal value)
        {
            Calculator calculator;
            bool isStraightSide;
            try
            {
                calculator = _unitOfWork.Calculators.FindCalculator(baseCurrencyCode, targetCurrencyCode, out isStraightSide);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            if (isStraightSide)
            {
                return Ok(calculator.GetEquivalence(value).ToString("0.0000"));
            }
            return Ok(calculator.GetInverseEquivalence(value).ToString("0.0000"));
        }
    }
}
