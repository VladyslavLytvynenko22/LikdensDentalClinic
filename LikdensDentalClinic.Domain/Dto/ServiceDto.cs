using System.ComponentModel.DataAnnotations;

namespace LikdensDentalClinic.Domain.Dto
{
    public class ServiceDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double? CostInUSD { get; set; }

        public double? CostInUAH { get; set; }

        public string Description { get; set; }
    }
}
