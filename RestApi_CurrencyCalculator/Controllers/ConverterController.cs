using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.ConvertionStrategy;
using RestApi_CurrencyCalculator.Core.Models;
using System;

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
                calculator.SetConvertionType(new NormalConversion());
                return Ok(calculator.Convert(value).ToString("0.0000"));
            }
            calculator.SetConvertionType(new InverseConvertion());
            return Ok(calculator.Convert(value).ToString("0.0000"));
        }
    }
}
