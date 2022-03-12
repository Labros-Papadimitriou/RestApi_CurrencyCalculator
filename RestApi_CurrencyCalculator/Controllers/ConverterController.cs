using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Controllers
{
    [Route("/api/converter")]
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
            string baseCurrency, string targetCurrency, int value)
        {
            return null;
        }
    }
}
