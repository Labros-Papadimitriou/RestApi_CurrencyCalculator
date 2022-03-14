using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestApi_CurrencyCalculator.AutoMapper.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CurrencyDtos;
using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApi_CurrencyCalculator.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CurrencyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CurrencyReadDto>> GetAllCurrencies()
        {
            var currencies = _unitOfWork.Currencies.GetAll();
            return Ok(_mapper.Map<IEnumerable<CurrencyReadDto>>(currencies));
        }


        [HttpGet("{id}", Name="GetCurrencyById")]
        public ActionResult<CurrencyReadDto> GetCurrencyById(int id)
        {
            var currencyItem = _unitOfWork.Currencies.Get(id);
            if (currencyItem != null)
            {
                return Ok(_mapper.Map<CurrencyReadDto>(currencyItem));
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<CurrencyReadDto> CreateCurrency(CurrencyUpsertDto currencyUpsertDto)
        {
            if (currencyUpsertDto is null)
            {
                return BadRequest();
            }
            var currencyModel = _mapper.Map<Currency>(currencyUpsertDto);
            _unitOfWork.Currencies.Create(currencyModel);
            _unitOfWork.Complete();

            var currencyReadDto = _mapper.Map<CurrencyReadDto>(currencyModel);
            return CreatedAtRoute(nameof(GetCurrencyById), new { Id = currencyReadDto.CurrencyId }, currencyReadDto);
        }


        [HttpPatch("{id}")]
        public ActionResult UpdateCurrency(int id, JsonPatchDocument<CurrencyUpsertDto> patchDoc)
        {
            var currencyModelFromRepo = _unitOfWork.Currencies.Get(id);
            if (currencyModelFromRepo is null)
            {
                return NotFound();
            }

            var currencyToPatch = _mapper.Map<CurrencyUpsertDto>(currencyModelFromRepo);
            patchDoc.ApplyTo(currencyToPatch, ModelState);

            if (!TryValidateModel(currencyToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(currencyToPatch, currencyModelFromRepo);
            _unitOfWork.Currencies.Modified(currencyModelFromRepo);
            _unitOfWork.Complete();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult DeleteCurrency(int id)
        {
            var currencyModelFromRepo = _unitOfWork.Currencies.Get(id);
            if (currencyModelFromRepo is null)
            {
                return NotFound();
            }
            var calculatorsFromRepo = _unitOfWork.Calculators.GetAll()
                .Where(x=>x.BaseCurrencyId == currencyModelFromRepo.CurrencyId
                            || x.TargetCurrencyId == currencyModelFromRepo.CurrencyId)
                .ToList();
            foreach (var calculator in calculatorsFromRepo)
            {
                _unitOfWork.Calculators.Delete(calculator);
                _unitOfWork.Complete();
            }
            _unitOfWork.Currencies.Delete(currencyModelFromRepo);
            _unitOfWork.Complete();

            return NoContent();
        } 
    }
}
