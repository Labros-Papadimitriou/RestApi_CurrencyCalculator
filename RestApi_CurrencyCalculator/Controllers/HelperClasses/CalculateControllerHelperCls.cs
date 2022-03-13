using RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CalculatorDtos;
using RestApi_CurrencyCalculator.Core;
using RestApi_CurrencyCalculator.Core.Models;
using System.Linq;

namespace RestApi_CurrencyCalculator.Controllers.HelperClasses
{
    public static class CalculateControllerHelperCls
    {
        public static int BaseCurrCreateIfNotExists(this CalculatorCreateDto calculatorCreateDto, IUnitOfWork unitOfWork)
        {
            var baseCurrencyItem = unitOfWork.Currencies
                .Find(x => x.Name == calculatorCreateDto.BaseCurrencyName && x.Code == calculatorCreateDto.BaseCurrencyCode)
                .FirstOrDefault();
            if (baseCurrencyItem is null)
            {
                Currency baseCurrNew = new Currency() { Code = calculatorCreateDto.BaseCurrencyCode, Name = calculatorCreateDto.BaseCurrencyName };
                unitOfWork.Currencies.Create(baseCurrNew);
                unitOfWork.Complete();
                return unitOfWork.Currencies.Find(x => x.Name == calculatorCreateDto.BaseCurrencyName).FirstOrDefault().CurrencyId;
            }
            else
            {
                return baseCurrencyItem.CurrencyId;
            }
        }

        public static int TargetCurrCreateIfNotExists(this CalculatorCreateDto calculatorCreateDto, IUnitOfWork unitOfWork)
        {
            var targetCurrencyItem = unitOfWork.Currencies
                .Find(x => x.Name == calculatorCreateDto.TargetCurrencyName && x.Code == calculatorCreateDto.TargetCurrencyCode)
                .FirstOrDefault();
            if (targetCurrencyItem is null)
            {
                Currency targetCurrNew = new Currency() { Code = calculatorCreateDto.TargetCurrencyCode, Name = calculatorCreateDto.TargetCurrencyName };
                unitOfWork.Currencies.Create(targetCurrNew);
                unitOfWork.Complete();
                return unitOfWork.Currencies.Find(x => x.Name == calculatorCreateDto.TargetCurrencyName).FirstOrDefault().CurrencyId;
            }
            else
            {
                return targetCurrencyItem.CurrencyId;
            }
        }
    }
}
