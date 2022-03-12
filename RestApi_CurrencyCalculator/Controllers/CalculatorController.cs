using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public ActionResult<IEnumerable<Calculator>> GetAllCurrencies()
        {
            return null;
        }

        [HttpGet("{id}")]
        public ActionResult<Calculator> GetCurrencyById(int id)
        {
            return null;
        }


    }
}
