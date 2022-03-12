using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi_CurrencyCalculator.Controllers
{
    [Route("/api/calculator")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfwork;

        public CalculatorController(IUnitOfWork unitOfWork)
        {
            _unitOfwork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Calculator>> GetAllCurrencies()
        {
            return Ok(_unitOfwork.Calculators.GetAllCalculatorsWithCurrencies());
        }

        [HttpGet("{id}")]
        public ActionResult<Calculator> GetCurrencyById(int id)
        {
            return null;
        }


    }
}
