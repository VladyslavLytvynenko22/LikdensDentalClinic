using System.ComponentModel.DataAnnotations;

namespace LikdensDentalClinic.Domain.Dto
{
    public class PriceDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal? CostInUSD { get; set; }

        public decimal? CostInUAH { get; set; }

        public string Description { get; set; }
    }
}