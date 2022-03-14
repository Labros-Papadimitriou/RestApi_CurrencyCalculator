using System.ComponentModel.DataAnnotations;

namespace RestApi_CurrencyCalculator.AutoMapperConfig.Dtos.CurrencyDtos
{
    public class CurrencyUpsertDto
    {
        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
