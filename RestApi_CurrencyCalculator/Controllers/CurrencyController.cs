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
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Currency>> GetAllCurrencies()
        {
            return Ok(_unitOfWork.Currencies.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Currency> GetCurrencyById(int id)
        {
            return null;
        }
    }
}
